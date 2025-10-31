using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("Dxgi.dll", EntryPoint = "CreateDXGIFactory2")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult CreateDXGIFactory2(uint flags, in Guid riid, out nint ppFactory);
    }
}
