using Hi3Helper.Win32.Native.LibraryImport;
using System;

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    /// <summary>
    /// Code from https://github.com/qmatteoq/DesktopBridgeHelpers/edit/master/DesktopBridge.Helpers/Helpers.cs
    /// </summary>
    internal class DesktopBridgeHelpers
    {
        private const long AppModelErrorNoPackage = 15700L;

        private static bool? _isRunningAsUwp;
        public static bool IsRunningAsUwp()
        {
            if (_isRunningAsUwp != null)
            {
                return _isRunningAsUwp.Value;
            }

            if (IsWindows7OrLower)
            {
                _isRunningAsUwp = false;
            }
            else
            {
                int len    = 0;
                int result = PInvoke.GetCurrentPackageFullName(ref len, out _);
                _isRunningAsUwp = result != AppModelErrorNoPackage;
            }

            return _isRunningAsUwp.Value;
        }

        private static bool IsWindows7OrLower
        {
            get
            {
                int    versionMajor = Environment.OSVersion.Version.Major;
                int    versionMinor = Environment.OSVersion.Version.Minor;
                double version      = versionMajor + (double)versionMinor / 10;
                return version <= 6.1;
            }
        }
    }
}
