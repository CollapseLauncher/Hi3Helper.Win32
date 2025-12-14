using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Enums.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("94d99bdb-f1f8-4ab0-b236-7da0170edab1")]
public partial interface IDXGISwapChain3 : IDXGISwapChain2
{
    // https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-getcurrentbackbufferindex
    [PreserveSig]
    uint GetCurrentBackBufferIndex();

    // https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-checkcolorspacesupport
    void CheckColorSpaceSupport(DXGI_COLOR_SPACE_TYPE ColorSpace, out uint pColorSpaceSupport);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-setcolorspace1
    void SetColorSpace1(DXGI_COLOR_SPACE_TYPE ColorSpace);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-resizebuffers1
    void ResizeBuffers1(uint BufferCount, uint Width, uint Height, DXGI_FORMAT Format, uint SwapChainFlags, [In][MarshalUsing(CountElementName = nameof(BufferCount))] uint[] pCreationNodeMask, [In][Out][MarshalUsing(CountElementName = nameof(BufferCount))] nint[] ppPresentQueue);
}
