using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Interfaces;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.ShellLinkCOM;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;
using Windows.UI.Notifications;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable RedundantStringInterpolation
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    internal class DesktopNotificationManagerCompat
    {
        #region Properties
        public const string ToastActivatedLaunchArg = "-ToastActivated";
        private static readonly Guid ToastG = new("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3");

        private static bool _registeredAumIdAndComServer;
        private static string? _aumId;
        private static bool _registeredActivator;
        #endregion

        #region Methods
        internal static void RegisterAumidAndComServer<T>(T currentInstance, string aumId, string executablePath, string shortcutPath, string? toastIconPngPath, Guid applicationId)
            where T : NotificationActivator
        {
            if (string.IsNullOrWhiteSpace(aumId))
            {
                throw new ArgumentException("You must provide an AUMID.", nameof(aumId));
            }

            // If running as Desktop Bridge
            if (DesktopBridgeHelpers.IsRunningAsUwp())
            {
                _aumId = null;
                _registeredAumIdAndComServer = true;
                return;
            }

            _aumId = aumId;

            // Get the state whether the current process is being run by elevated user.
            WindowsIdentity  currentUserIdentity  = WindowsIdentity.GetCurrent();
            WindowsPrincipal currentUserPrincipal = new WindowsPrincipal(currentUserIdentity);
            bool             asElevatedUser       = currentUserPrincipal.IsInRole(WindowsBuiltInRole.Administrator);

            CreateAumidShortcut(currentInstance, aumId, executablePath, shortcutPath, applicationId, asElevatedUser);
            RegisterComServer(executablePath, applicationId, asElevatedUser);
            RegisterAumid(toastIconPngPath, applicationId);

            _registeredAumIdAndComServer = true;
        }

        private static void CreateAumidShortcut<T>(T currentInstance, string aumid, string executablePath, string shortcutPath, Guid applicationId, bool asElevatedUser)
            where T : NotificationActivator
        {
            bool isFullPath = Path.IsPathFullyQualified(shortcutPath);

            currentInstance.Logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Registering AumId for application name: {aumid} with application id: {applicationId} (Is as elevated user?: {asElevatedUser})");
            currentInstance.Logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Using executable path: {executablePath}");

            // If the shortcut path is not fully qualified, then assign based on elevate state
            if (!isFullPath)
            {
                currentInstance.Logger?.LogWarning($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Shortcut path is not fully qualified: {shortcutPath}");
                string applicationDirPath = Environment.GetFolderPath(asElevatedUser ?
                    Environment.SpecialFolder.CommonApplicationData :
                    Environment.SpecialFolder.ApplicationData);

                string startMenuProgramPath = Path.Combine(applicationDirPath, @"Microsoft\Windows\Start Menu\Programs");
                shortcutPath = Path.Combine(startMenuProgramPath, shortcutPath);
            }

            currentInstance.Logger?.LogInformation($"[DesktopNotificationManagerCompat::CreateAumidShortcut] Shortcut will be written to: {shortcutPath}");
            string executableDirPath = Path.GetDirectoryName(executablePath) ?? "";
            string? temporaryDirectoryPath = Path.GetDirectoryName(shortcutPath);

            if (!shortcutPath.EndsWith(".lnk"))
            {
                shortcutPath += ".lnk";
            }

            ComMarshal.CreateInstance(
                ShellLinkClsId.ClsId_ShellLink,
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
            out IShellLinkW? shellLink
            ).ThrowOnFailure();

            PropVariant aumId = PropVariant.FromString(aumid);
            PropertyKey aumIdPropkey = new()
            {
                formatId = ToastG,
                pid = 5
            };
            PropVariant toastId = PropVariant.FromGuid(applicationId);
            PropertyKey toastIdPropkey = new()
            {
                formatId = ToastG,
                pid = 26
            };

            bool isShortcutExist = File.Exists(shortcutPath);

            try
            {
                IPersistFile? persistFileW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersistFile>(in ShellLinkClsId.IGuid_IPersistFile);
                IPropertyStore? propertyStoreW = shellLink?.CastComInterfaceAs<IShellLinkW, IPropertyStore>(in ShellLinkClsId.IGuid_IPropertyStore);

                try
                {
                    if (isShortcutExist)
                        persistFileW?.Load(shortcutPath, 0);
                }
                catch (Exception ex)
                {
                    currentInstance.Logger?.LogError($"[DesktopNotificationManagerCompat::CreateAumidShortcut] An error has occured while loading existing shortcut: {shortcutPath}\r\n{ex}");
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

        private static void RegisterAumid(string? iconPath, Guid applicationId)
        {
            // Reference:
            // https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/c8f76d072df53d3622fb5440d63afb06cb9e7a10/Microsoft.Toolkit.Uwp.Notifications/Toasts/Compat/ToastNotificationManagerCompat.cs#L153
            // https://learn.microsoft.com/en-us/windows/apps/design/shell/tiles-and-notifications/send-local-toast-other-apps#step-1-register-your-app-in-the-registry

            // Throw if the _aumId is blank
            if (string.IsNullOrEmpty(_aumId))
            {
                throw new InvalidOperationException("Please set the aumid!");
            }

            // Get whether the current process is running as UWP app
            bool isUwp = DesktopBridgeHelpers.IsRunningAsUwp();

            // Create the AUMID key from Current User root key
            using RegistryKey aumidKey = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\Classes\AppUserModelId\{_aumId}", true);
            // If the app is non-UWP app, then set the "Identity" of the app, including the display name of the app.
            if (!isUwp)
            {
                aumidKey.SetValue("DisplayName", _aumId);

                // Set the URI of the icon to be used
                if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
                {
                    aumidKey.SetValue("IconUri", iconPath);
                    aumidKey.SetValue("IconBackgroundColor", "0");
                }
            }

            // Tell the Action Center to use the specific COM Activator when the app is activated
            aumidKey.SetValue("CustomActivator", $"{{{applicationId}}}");
            aumidKey.SetValue("Has7.0.1Fix", 1);
            aumidKey.SetValue("HasSentNotification", 1);
        }

        private static void RegisterComServer(string exePath, Guid applicationId, bool asElevatedUser)
        {
            // Reference:
            // https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/c8f76d072df53d3622fb5440d63afb06cb9e7a10/Microsoft.Toolkit.Uwp.Notifications/Toasts/Compat/ToastNotificationManagerCompat.cs#L285

            // Throw if the _aumId is blank
            if (string.IsNullOrEmpty(_aumId))
            {
                throw new InvalidOperationException("Please set the aumid!");
            }

            // Define root classes key path and the COM activator server path
            const string clsIdKeyPath           = @$"SOFTWARE\Classes";
            string       comActivatorServerPath = $"\"{exePath}\" {ToastActivatedLaunchArg}";

            // Open the root registry key for both local machine and current user
            using RegistryKey? currentUserRootKey  = Registry.CurrentUser.OpenSubKey(clsIdKeyPath, true);
            using RegistryKey? localMachineRootKey = Registry.LocalMachine.OpenSubKey(clsIdKeyPath, true);

            // Create the activator key for the current user
            using RegistryKey? currentUserActivatorKey = currentUserRootKey?.CreateSubKey($@"CLSID\{{{applicationId}}}\LocalServer32", true);
            currentUserActivatorKey?.SetValue(null, comActivatorServerPath);

            // If the process is not running as elevated user, then skip the local machine activator key creation
            // Reference:
            // https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/c8f76d072df53d3622fb5440d63afb06cb9e7a10/Microsoft.Toolkit.Uwp.Notifications/Toasts/Compat/ToastNotificationManagerCompat.cs#L296
            if (!asElevatedUser)
            {
                return;
            }

            // Create the class id key for the COM Activator for the local machine
            using RegistryKey? localMachineActivatorKey = localMachineRootKey?.CreateSubKey($@"CLSID\{{{applicationId}}}", true);
            using RegistryKey? localServerKey           = localMachineActivatorKey?.CreateSubKey("LocalServer32", true);
            localServerKey?.SetValue(null, comActivatorServerPath);

            // Set the reference of the Action Center's App ID to the COM Activator
            localMachineActivatorKey?.SetValue("AppId", $"{{{applicationId}}}");

            // Tell the Action Center to invoke the COM Activator when it's running under elevated user
            // Reference:
            // https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/c8f76d072df53d3622fb5440d63afb06cb9e7a10/Microsoft.Toolkit.Uwp.Notifications/Toasts/Compat/ToastNotificationManagerCompat.cs#L313
            // https://docs.microsoft.com/windows/win32/com/runas
            using RegistryKey? appIDKey = localMachineRootKey?.CreateSubKey(@$"AppID\{{{applicationId}}}", true);
            appIDKey?.SetValue(null,    _aumId);
            appIDKey?.SetValue("RunAs", "Interactive User");
        }

        internal static void RegisterActivator<T>(T currentInstance, Guid applicationId)
            where T : NotificationActivator
        {
            const CLSCTX    classContext = CLSCTX.CLSCTX_LOCAL_SERVER;
            const TagREGCLS registerFlag = TagREGCLS.REGCLS_MULTIPLEUSE;

            NotificationActivatorClassFactory classFactory = new();
            classFactory.UseExistingInstance(currentInstance);

            PInvoke.CoRegisterClassObject(
                in applicationId,
                classFactory,
                classContext,
                registerFlag,
                out currentInstance.CurrentRegisteredClass).ThrowOnFailure();

            _registeredActivator = true;

            currentInstance.Logger?.LogInformation($"[DesktopNotificationManagerCompat::RegisterActivator] Registered Toast Activator for application id: {applicationId} with CLSCTX: {classContext}");
        }

        internal static ToastNotifier? CreateToastNotifier(ILogger? logger, bool throwOnFault)
        {
            try
            {
                EnsureRegistered();

                return _aumId != null ?
                    // Non-Desktop Bridge
                    ToastNotificationManager.CreateToastNotifier(_aumId) :
                    // Desktop Bridge
                    ToastNotificationManager.CreateToastNotifier();
            }
            catch
            {
                if (throwOnFault)
                    throw;

                logger?.LogError("Cannot create a toast notifier as the COM Activator is not registered. Returning null!");
                return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="DesktopNotificationHistoryCompat"/> object. You must have called <see cref="RegisterActivator{T}(T, Guid, bool)"/> first (and also <see cref="RegisterAumidAndComServer{T}(T, string, string, string, Guid, bool)"/> if you're a classic Win32 app), or this will throw an exception.
        /// </summary>
        public static DesktopNotificationHistoryCompat History
        {
            get
            {
                EnsureRegistered();

                return new DesktopNotificationHistoryCompat(_aumId!);
            }
        }

        private static void EnsureRegistered()
        {
            // If not registered AUMID yet
            if (!_registeredAumIdAndComServer)
            {
                // Check if Desktop Bridge
                if (DesktopBridgeHelpers.IsRunningAsUwp())
                {
                    // Implicitly registered, all good!
                    _registeredAumIdAndComServer = true;
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
