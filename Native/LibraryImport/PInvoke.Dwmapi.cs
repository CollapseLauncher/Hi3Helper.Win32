using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Structs;
// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedMethodReturnValue.Global

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dwmapi.dll", EntryPoint = "DwmExtendFrameIntoClientArea")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult DwmExtendFrameIntoClientArea(nint windowHandle, ref MARGINS pMarInset);
    }
}
