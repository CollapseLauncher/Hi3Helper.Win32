using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantUnsafeContext

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIFactory3)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIFactory3 : IDXGIFactory2
{
    /// <summary>Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.</summary>
    /// <returns>The creation flags.</returns>
    /// <remarks>The <b>GetCreationFlags</b> method returns flags that were passed to the  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_3/nf-dxgi1_3-createdxgifactory2">CreateDXGIFactory2</a> function, or were implicitly constructed by <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-createdxgifactory">CreateDXGIFactory</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-createdxgifactory1">CreateDXGIFactory1</a>,  <a href="https://docs.microsoft.com/windows/desktop/api/d3d11/nf-d3d11-d3d11createdevice">D3D11CreateDevice</a>, or <a href="https://docs.microsoft.com/windows/desktop/api/d3d11/nf-d3d11-d3d11createdeviceandswapchain">D3D11CreateDeviceAndSwapChain</a>.</remarks>
    [PreserveSig]
    DXGI_CREATE_FACTORY_FLAGS GetCreationFlags();
}
