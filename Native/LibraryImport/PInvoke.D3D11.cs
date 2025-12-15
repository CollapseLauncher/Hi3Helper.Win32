using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
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

        [LibraryImport("D2d1.dll", EntryPoint = "D2D1CreateDevice")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult D2D1CreateDevice(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIDevice>))] IDXGIDevice dxgiDevice,
            in D2D1_CREATION_PROPERTIES creationProperties,
            out nint d2dDevice);
    }
}
