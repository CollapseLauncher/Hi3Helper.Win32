using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("d2d1.dll", EntryPoint = "D2D1CreateFactory")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult D2D1CreateFactory(
            D2D1_FACTORY_TYPE factoryType,
            in Guid riid,
            in D2D1_FACTORY_OPTIONS pFactoryOptions,
            out nint ppIFactory);
    }
}
