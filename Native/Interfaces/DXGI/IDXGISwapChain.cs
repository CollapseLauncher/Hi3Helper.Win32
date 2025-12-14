using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable GrammarMistakeInComment
// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGISwapChain)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGISwapChain : IDXGIDeviceSubObject
{
    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-present
    void Present(uint SyncInterval, DXGI_PRESENT Flags);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer
    void GetBuffer(uint Buffer, in Guid riid, out nint /* void */ ppSurface);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate
    void SetFullscreenState(BOOL Fullscreen, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIOutput?>))] IDXGIOutput? pTarget);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getfullscreenstate
    void GetFullscreenState(nint /* optional BOOL* */ pFullscreen, nint /* optional IDXGIOutput* */ ppTarget);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getdesc
    void GetDesc(out DXGI_SWAP_CHAIN_DESC pDesc);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ResizeBuffers(uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, uint SwapChainFlags);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizetarget
    void ResizeTarget(in DXGI_MODE_DESC pNewTargetParameters);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getcontainingoutput
    void GetContainingOutput([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIOutput>))] out IDXGIOutput ppOutput);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getframestatistics
    void GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getlastpresentcount
    void GetLastPresentCount(out uint pLastPresentCount);
}