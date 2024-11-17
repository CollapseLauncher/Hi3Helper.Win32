using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        [LibraryImport("dwmapi.dll", EntryPoint = "DwmExtendFrameIntoClientArea")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult DwmExtendFrameIntoClientArea(nint hWnd, ref MARGINS pMarInset);
    }
}
