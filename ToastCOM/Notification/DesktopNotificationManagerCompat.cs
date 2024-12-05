using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.ManagedTools;
using Hi3Helper.Win32.ShellLinkCOM;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Windows.UI.Notifications;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public class DesktopNotificationManagerCompat
    {
        #region Properties
        public const string TOAST_ACTIVATED_LAUNCH_ARG = "-ToastActivated";
        private static readonly Guid TOAST_G = new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3");

        private static bool _registeredAumidAndComServer;
        private static string? _aumid;
        private static bool _registeredActivator;
        #endregion

        #region Methods
        public static void RegisterAumidAndComServer<T>(string aumid, string executablePath, string shortcutPath)
            where T : NotificationActivator
        {
            if (string.IsNullOrWhiteSpace(aumid))
            {
                throw new ArgumentException("You must provide an AUMID.", nameof(aumid));
            }

            // If running as Desktop Bridge
            if (DesktopBridgeHelpers.IsRunningAsUwp())
            {
                _aumid = null;
                _registeredAumidAndComServer = true;
                return;
            }

            _aumid = aumid;

            CreateAumidTemporaryShortcut<T>(aumid, executablePath, shortcutPath);
            RegisterComServer<T>(executablePath);

            _registeredAumidAndComServer = true;
        }

        private static void CreateAumidTemporaryShortcut<T>(string aumid, string executablePath, string shortcutPath)
            where T : NotificationActivator
        {
            string executableDirPath = Path.GetDirectoryName(executablePath) ?? "";
            string? temporaryDirectoryPath = Path.GetDirectoryName(shortcutPath);

            ComMarshal.CreateInstance(
                ShellLinkCOM.CLSIDGuid.ClsId_ShellLink,
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
            out IShellLinkW? shellLink
            ).ThrowOnFailure();

            PropVariant aumId = PropVariant.FromString(aumid);
            PropertyKey aumIdPropkey = new PropertyKey
            {
                fmtid = TOAST_G,
                pid = 5
            };
            PropVariant toastId = PropVariant.FromGuid(typeof(T).GUID);
            PropertyKey toastIdPropkey = new PropertyKey
            {
                fmtid = TOAST_G,
                pid = 26
            };

            bool isShortcutExist = File.Exists(shortcutPath);

            try
            {
                IPersistFile? persistFileW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersistFile>(in ShellLinkCOM.CLSIDGuid.IGuid_IPersistFile);
                IPersist? persistW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersist>(in ShellLinkCOM.CLSIDGuid.IGuid_IPersist);
                IPropertyStore? propertyStoreW = shellLink?.CastComInterfaceAs<IShellLinkW, IPropertyStore>(in ShellLinkCOM.CLSIDGuid.IGuid_IPropertyStore);

                if (isShortcutExist)
                    persistFileW?.Load(executablePath, 0);

                shellLink?.SetPath(executablePath);
                shellLink?.SetWorkingDirectory(executableDirPath);

                propertyStoreW?.SetValue(ref aumIdPropkey, ref aumId);
                propertyStoreW?.SetValue(ref toastIdPropkey, ref toastId);
                propertyStoreW?.Commit();

                persistFileW?.Save(shortcutPath, true);
            }
            finally
            {
                aumId.Clear();
                toastId.Clear();
            }
        }

        /// <summary>
        /// 使应用程序可以从toast启动
        /// </summary>
        private static void RegisterComServer<T>(string exePath)
        {
            // We register the EXE to start up when the notification is activated
            string regString = $"SOFTWARE\\Classes\\CLSID\\{{{typeof(T).GUID}}}\\LocalServer32";
            RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);

            var key = localKey.CreateSubKey(regString);

            key.SetValue(null, '"' + exePath + '"');
        }

        public static unsafe void RegisterActivator<T>(T instance)
            where T : NotificationService
        {
            Guid guid = typeof(T).GUID;

            NotificationServiceClassFactory classFactory = new NotificationServiceClassFactory();
            classFactory.UseExistingInstance(instance);

            PInvoke.CoRegisterClassObject(
                in guid,
                classFactory,
                (int)CLSCTX.CLSCTX_LOCAL_SERVER,
                0,
                out uint id).ThrowOnFailure();
            _registeredActivator = true;
        }

        /// <summary>
        /// 创建通知
        /// </summary>
        public static ToastNotifier CreateToastNotifier()
        {
            EnsureRegistered();

            if (_aumid != null)
            {
                // Non-Desktop Bridge
                return ToastNotificationManager.CreateToastNotifier(_aumid);
            }
            else
            {
                // Desktop Bridge
                return ToastNotificationManager.CreateToastNotifier();
            }
        }

        /// <summary>
        /// Gets the <see cref="DesktopNotificationHistoryCompat"/> object. You must have called <see cref="RegisterActivator"/> first (and also <see cref="RegisterAumidAndComServer(string)"/> if you're a classic Win32 app), or this will throw an exception.
        /// </summary>
        public static DesktopNotificationHistoryCompat History
        {
            get
            {
                EnsureRegistered();

                return new DesktopNotificationHistoryCompat(_aumid!);
            }
        }

        private static void EnsureRegistered()
        {
            // If not registered AUMID yet
            if (!_registeredAumidAndComServer)
            {
                // Check if Desktop Bridge
                if (DesktopBridgeHelpers.IsRunningAsUwp())
                {
                    // Implicitly registered, all good!
                    _registeredAumidAndComServer = true;
                }
                else
                {
                    // Otherwise, incorrect usage
                    throw new Exception("You must call RegisterAumidAndComServer first.");
                }
            }

            // If not registered activator yet
            if (!_registeredActivator)
            {
                // Incorrect usage
                throw new Exception("You must call RegisterActivator first.");
            }
        }

        /// <summary>
        /// Gets a boolean representing whether http images can be used within toasts. This is true if running under Desktop Bridge.
        /// </summary>
        public static bool CanUseHttpImages { get { return DesktopBridgeHelpers.IsRunningAsUwp(); } }

        /// <summary>
        /// Code from https://github.com/qmatteoq/DesktopBridgeHelpers/edit/master/DesktopBridge.Helpers/Helpers.cs
        /// </summary>
        private class DesktopBridgeHelpers
        {
            const long APPMODEL_ERROR_NO_PACKAGE = 15700L;

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder packageFullName);

            private static bool? _isRunningAsUwp;
            public static bool IsRunningAsUwp()
            {
                if (_isRunningAsUwp == null)
                {
                    if (IsWindows7OrLower)
                    {
                        _isRunningAsUwp = false;
                    }
                    else
                    {
                        int length = 0;
                        StringBuilder sb = new StringBuilder(0);
                        int result = GetCurrentPackageFullName(ref length, sb);

                        sb = new StringBuilder(length);
                        result = GetCurrentPackageFullName(ref length, sb);

                        _isRunningAsUwp = result != APPMODEL_ERROR_NO_PACKAGE;
                    }
                }

                return _isRunningAsUwp.Value;
            }

            private static bool IsWindows7OrLower
            {
                get
                {
                    int versionMajor = Environment.OSVersion.Version.Major;
                    int versionMinor = Environment.OSVersion.Version.Minor;
                    double version = versionMajor + (double)versionMinor / 10;
                    return version <= 6.1;
                }
            }
        }
        #endregion

    }
}
