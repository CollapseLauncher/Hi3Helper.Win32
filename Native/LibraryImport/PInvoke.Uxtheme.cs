using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
// ReSharper disable StringLiteralTypo
#pragma warning disable CA1401

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("uxtheme.dll", EntryPoint = "#132")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ShouldAppsUseDarkMode();

        // Note: Can only use "Default" and "AllowDark" to support Windows 10 1809
        [LibraryImport("uxtheme.dll", EntryPoint = "#135")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial PreferredAppMode SetPreferredAppMode(PreferredAppMode preferredAppMode);
    }
}
