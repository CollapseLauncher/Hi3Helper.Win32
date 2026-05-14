using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("Dxgi.dll", EntryPoint = "CreateDXGIFactory2")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult CreateDXGIFactory2(uint flags, in Guid riid, [MarshalUsing(typeof(ComInterfaceMarshaller<IDXGIFactory2>))] out IDXGIFactory2? ppFactory);
    }
}
