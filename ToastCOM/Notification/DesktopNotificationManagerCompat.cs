using Hi3Helper.Win32.FileDialogCOM;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.ManagedTools;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.ShellLinkCOM;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Windows.UI.Notifications;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    internal class DesktopNotificationManagerCompat
    {
        #region Properties
        public const string TOAST_ACTIVATED_LAUNCH_ARG = "-ToastActivated";
        private static readonly Guid TOAST_G = new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3");

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
                shortcutPath = shortcutPath + ".lnk";
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
                IPersist? persistW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersist>(in ShellLinkCOM.CLSIDGuid.IGuid_IPersist);
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
            // We register the EXE to start up when the notification is activated
            string monikerPath = @$"SOFTWARE\Classes\CLSID\{{{applicationId}}}";
            string regLocalServerString = Path.Combine(monikerPath, "LocalServer32");
            RegistryKey localKey = RegistryKey.OpenBaseKey(asElevatedUser ? RegistryHive.LocalMachine : RegistryHive.CurrentUser, RegistryView.Registry64);

            // Add LOCAL_SERVER registration path
            RegistryKey regLocalServerKey = localKey.CreateSubKey(regLocalServerString);
            regLocalServerKey.SetValue(null, '"' + exePath + '"');
            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterComServer] Registered ComServer for toast registration: {(asElevatedUser ? "HKEY_LOCAL_MACHINE" : "HKEY_CURRENT_USER")}\\{regLocalServerString}");

            // If asElevatedUser is enabled, then add "Elevation" key on COM Activator moniker
            if (asElevatedUser)
            {
                bool found = FindResourceNumberOfAumid(exePath, _aumid ?? "", out int resourceNumber);

                RegistryKey monikerKey = localKey.CreateSubKey(monikerPath);
                monikerKey.SetValue(null, _aumid ?? "", RegistryValueKind.String);
                monikerKey.SetValue("AppID", $"{{{applicationId}}}");
                monikerKey.SetValue("LocalizedString", "@C:\\Windows\\system32\\vsjitdebugger.exe,-201");

                string regElevateString = Path.Combine(monikerPath, "Elevation");
                RegistryKey regElevateKey = localKey.CreateSubKey(regElevateString);
                regElevateKey.SetValue("Enabled", 1, RegistryValueKind.DWord);
                currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterComServer] Activator will run under elevated access!");
            }
        }

        // Constants
        private const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        private const int RT_STRING = 6; // Resource type for string tables

        // P/Invoke declarations
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr FindResourceEx(IntPtr hModule, IntPtr lpType, IntPtr lpName, ushort wLanguage);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResource);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LockResource(IntPtr hGlobal);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint SizeofResource(IntPtr hModule, IntPtr hResource);

        private static IntPtr MAKEINTRESOURCE(int id) => (IntPtr)id;

        private static bool FindResourceNumberOfAumid(string executablePath, string aumidToSearch, out int resourceNumber)
        {
            const ushort languageId = 0;
            IntPtr hModule = LoadLibraryEx(executablePath, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);

            bool resourceFound = false;
            resourceNumber = -1;
            try
            {
                for (int resourceId = 0; resourceId < 2000; resourceId++)
                {
                    IntPtr hResource = FindResourceEx(nint.Zero, MAKEINTRESOURCE(RT_STRING), MAKEINTRESOURCE(resourceId), languageId);
                    if (hResource != IntPtr.Zero)
                    {
                        Console.WriteLine($"Found LocalizedString resource with ID: {resourceId}");
                        resourceFound = true;

                        // Load and view resource data
                        IntPtr hResourceData = LoadResource(hModule, hResource);
                        if (hResourceData != IntPtr.Zero)
                        {
                            IntPtr pResource = LockResource(hResourceData);
                            uint size = SizeofResource(hModule, hResource);

                            if (pResource != IntPtr.Zero && size > 0)
                            {
                                Console.WriteLine($"Resource data found with size: {size} bytes.");
                                // Additional logic to interpret string data can be added here
                            }
                        }
                    }
                }
            }
            finally
            {
                FreeLibrary(hModule);
            }

            return resourceFound;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BIND_OPTS3
        {
            public uint cbStruct;          // DWORD
            public uint grfFlags;          // DWORD
            public uint grfMode;           // DWORD
            public uint dwTickCountDeadline; // DWORD
            public uint dwTrackFlags;      // DWORD
            public uint dwClassContext;    // DWORD
            public uint locale;            // LCID (equivalent to uint in .NET)
            public IntPtr pServerInfo;     // COSERVERINFO*, use IntPtr for pointer to unmanaged struct
            public IntPtr hwnd;            // HWND, use IntPtr to represent window handles
        }

        [DllImport("ole32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int CoGetObject(
            string pszName,
            ref BIND_OPTS3 pBindOptions,
            in Guid riid,
            out nint ppv);

        internal static unsafe void RegisterActivator<T>(T currentInstance, Guid applicationId, bool asElevatedUser)
            where T : NotificationActivator
        {
            Guid guid = applicationId;

            CLSCTX classContext = CLSCTX.CLSCTX_LOCAL_SERVER;

            NotificationActivatorClassFactory classFactory = new NotificationActivatorClassFactory();
            classFactory.UseExistingInstance(currentInstance, asElevatedUser);

            PInvoke.CoRegisterClassObject(
                in guid,
                classFactory,
                (uint)classContext,
                0,
                out uint id).ThrowOnFailure();
            _registeredActivator = true;

            currentInstance._logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterActivator] Registered Toast Activator for application id: {guid} with CLSCTX: {classContext}");
        }


        internal static ToastNotifier CreateToastNotifier()
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
