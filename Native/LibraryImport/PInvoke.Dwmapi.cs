using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
// ReSharper disable StringLiteralTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dwmapi.dll", EntryPoint = "DwmExtendFrameIntoClientArea")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult DwmExtendFrameIntoClientArea(nint windowHandle, ref MARGINS pMarInset);
    }
}
