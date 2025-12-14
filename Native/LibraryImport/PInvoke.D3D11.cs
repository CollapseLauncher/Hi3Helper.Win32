using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("d3d11.dll", EntryPoint = "D3D11CreateDevice")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult D3D11CreateDevice(
            nint pAdapter,
            D3D_DRIVER_TYPE driverType,
            HMODULE software,
            D3D11_CREATE_DEVICE_FLAG flags,
            D3D_FEATURE_LEVEL[]? pFeatureLevels,
            int featureLevels,
            uint sdkVersion,
            out nint ppDevice,
            D3D_FEATURE_LEVEL featureLevel,
            out nint ppImmediateContext);

        [LibraryImport("d3d11.dll", EntryPoint = "CreateDirect3D11SurfaceFromDXGISurface")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult CreateDirect3D11SurfaceFromDXGISurface(
            nint dgxiSurface,
            out nint ppGraphicsSurface);
    }
}
