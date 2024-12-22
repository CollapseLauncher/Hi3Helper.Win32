using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.ManagedTools;
using Hi3Helper.Win32.ShellLinkCOM;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.IO;
using Windows.UI.Notifications;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    internal class DesktopNotificationManagerCompat
    {
        #region Properties
        public const string TOAST_ACTIVATED_LAUNCH_ARG = "-ToastActivated";
        private static readonly Guid TOAST_G = new("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3");

        private static bool _registeredAumidAndComServer;
        private static string? _aumid;
        private static bool _registeredActivator;
        #endregion

        #region Methods
        internal static void RegisterAumidAndComServer<T>(T currentInstance, string aumid, string executablePath, string shortcutPath, Guid applicationId, bool asElevatedUser)
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

            CreateAumidShortcut(currentInstance, aumid, executablePath, shortcutPath, applicationId, asElevatedUser);
            RegisterComServer(currentInstance, executablePath, applicationId, asElevatedUser);

            _registeredAumidAndComServer = true;
        }

        private static void CreateAumidShortcut<T>(T currentInstance, string aumid, string executablePath, string shortcutPath, Guid applicationId, bool asElevatedUser)
            where T : NotificationActivator
        {
            bool isFullPath = Path.IsPathFullyQualified(shortcutPath);

            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Registering AumId for application name: {aumid} with application id: {applicationId} (Is as elevated user?: {asElevatedUser})");
            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Using executable path: {executablePath}");

            // If the shortcut path is not fully qualified, then assign based on elevate state
            if (!isFullPath)
            {
                currentInstance._logger?.LogWarning($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Shortcut path is not fully qualified: {shortcutPath}");
                string applicationDirPath = Environment.GetFolderPath(asElevatedUser ?
                    Environment.SpecialFolder.CommonApplicationData :
                    Environment.SpecialFolder.ApplicationData);

                string startMenuProgramPath = Path.Combine(applicationDirPath, @"Microsoft\Windows\Start Menu\Programs");
                shortcutPath = Path.Combine(startMenuProgramPath, shortcutPath);
            }

            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Shortcut will be written to: {shortcutPath}");
            string executableDirPath = Path.GetDirectoryName(executablePath) ?? "";
            string? temporaryDirectoryPath = Path.GetDirectoryName(shortcutPath);

            if (!shortcutPath.EndsWith(".lnk"))
            {
                shortcutPath += ".lnk";
            }

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
            PropVariant toastId = PropVariant.FromGuid(applicationId);
            PropertyKey toastIdPropkey = new PropertyKey
            {
                fmtid = TOAST_G,
                pid = 26
            };

            bool isShortcutExist = File.Exists(shortcutPath);

            try
            {
                IPersistFile? persistFileW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersistFile>(in ShellLinkCOM.CLSIDGuid.IGuid_IPersistFile);
                IPropertyStore? propertyStoreW = shellLink?.CastComInterfaceAs<IShellLinkW, IPropertyStore>(in ShellLinkCOM.CLSIDGuid.IGuid_IPropertyStore);

                try
                {
                    if (isShortcutExist)
                        persistFileW?.Load(shortcutPath, 0);
                }
                catch (Exception ex)
                {
                    currentInstance._logger?.LogError($"[DesktopNotificationManagerCompat::CreateAumidShortcut] An error has occured while loading existing shortcut: {shortcutPath}\r\n{ex}");
                }

                shellLink?.SetPath(executablePath);
                shellLink?.SetWorkingDirectory(executableDirPath);

                propertyStoreW?.SetValue(ref aumIdPropkey, ref aumId);
                propertyStoreW?.SetValue(ref toastIdPropkey, ref toastId);
                propertyStoreW?.Commit();

                if (!string.IsNullOrEmpty(temporaryDirectoryPath) && !Directory.Exists(temporaryDirectoryPath))
                    Directory.CreateDirectory(temporaryDirectoryPath);

                persistFileW?.Save(shortcutPath, true);
            }
            finally
            {
                aumId.Clear();
                toastId.Clear();
            }
        }

        private static void RegisterComServer<T>(T currentInstance, string exePath, Guid applicationId, bool asElevatedUser)
            where T : NotificationActivator
        {
            // Throw if the _aumid is blank
            if (string.IsNullOrEmpty(_aumid))
            {
                throw new InvalidOperationException("Please set the ApplicationId!");
            }

            // We register the EXE to start up when the notification is activated
            string monikerPath = @$"SOFTWARE\Classes\CLSID\{{{applicationId}}}";
            string regLocalServerString = Path.Combine(monikerPath, "LocalServer32");
            RegistryKey localKey = RegistryKey.OpenBaseKey(asElevatedUser ? RegistryHive.LocalMachine : RegistryHive.CurrentUser, RegistryView.Registry64);

            // Add LOCAL_SERVER registration path
            RegistryKey regLocalServerKey = localKey.CreateSubKey(regLocalServerString);
            regLocalServerKey.SetValue(null,             '"' + exePath + '"' + $" {TOAST_ACTIVATED_LAUNCH_ARG}", RegistryValueKind.ExpandString);
            regLocalServerKey.SetValue("ServerExecutable", exePath, RegistryValueKind.ExpandString);
            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterComServer] Registered ComServer for toast registration: {(asElevatedUser ? "HKEY_LOCAL_MACHINE" : "HKEY_CURRENT_USER")}\\{regLocalServerString}");

            // If asElevatedUser is enabled, then add "Elevation" key on COM Activator moniker
            if (asElevatedUser)
            {
                // Remove one if the duplicated key from non-elevated user exist
                RegistryKey  localKeyNonElevated = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey? regLocalServerKeyNonElevated = localKeyNonElevated.OpenSubKey(regLocalServerString);
                if (regLocalServerKeyNonElevated != null)
                {
                    localKey.DeleteSubKeyTree(regLocalServerString);
                }

                RegistryKey monikerKey = localKey.CreateSubKey(monikerPath);
                monikerKey.SetValue(null, _aumid, RegistryValueKind.String);
                monikerKey.SetValue("AppID", $"{{{applicationId}}}");
                monikerKey.SetValue("LocalizedString", _aumid);

                string regElevateString = Path.Combine(monikerPath, "Elevation");
                RegistryKey regElevateKey = localKey.CreateSubKey(regElevateString);
                regElevateKey.SetValue("Enabled", 1, RegistryValueKind.DWord);
                currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterComServer] Activator will run under elevated access!");
            }
        }

        internal static void RegisterActivator<T>(T currentInstance, Guid applicationId, bool asElevatedUser)
            where T : NotificationActivator
        {
            Guid guid = applicationId;

            CLSCTX    classContext = CLSCTX.CLSCTX_LOCAL_SERVER;
            TagREGCLS registerFlag = TagREGCLS.REGCLS_MULTIPLEUSE;

            NotificationActivatorClassFactory classFactory = new NotificationActivatorClassFactory();
            classFactory.UseExistingInstance(currentInstance, asElevatedUser);

            PInvoke.CoRegisterClassObject(
                in guid,
                classFactory,
                classContext,
                registerFlag,
                out currentInstance._currentRegisteredClass).ThrowOnFailure();

            _registeredActivator = true;

            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterActivator] Registered Toast Activator for application id: {guid} with CLSCTX: {classContext}");
        }


        internal static ToastNotifier CreateToastNotifier()
        {
            EnsureRegistered();

            return _aumid != null ?
                // Non-Desktop Bridge
                ToastNotificationManager.CreateToastNotifier(_aumid) :
                // Desktop Bridge
                ToastNotificationManager.CreateToastNotifier();
        }

        /// <summary>
        /// Gets the <see cref="DesktopNotificationHistoryCompat"/> object. You must have called <see cref="RegisterActivator"/> first (and also <see cref="RegisterAumidAndComServer"/> if you're a classic Win32 app), or this will throw an exception.
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
        #endregion
    }
}
