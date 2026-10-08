using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Enums;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("Shcore.dll", EntryPoint = "GetDpiForMonitor")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int GetDpiForMonitor(nint monitorHandle, Monitor_DPI_Type dpiType, out uint dpiX, out uint dpiY);
    }
}
