using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable GrammarMistakeInComment

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid(DXGIClsId.IDXGISwapChain1)]
public partial interface IDXGISwapChain1 : IDXGISwapChain
{
    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1
    void GetDesc1(out DXGI_SWAP_CHAIN_DESC1 pDesc);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getfullscreendesc
    void GetFullscreenDesc(out DXGI_SWAP_CHAIN_FULLSCREEN_DESC pDesc);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-gethwnd
    void GetHwnd(out nint pHwnd);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getcorewindow
    void GetCoreWindow(in Guid refiid, out nint /* void */ ppUnk);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1
    void Present1(uint SyncInterval, DXGI_PRESENT PresentFlags, in DXGI_PRESENT_PARAMETERS pPresentParameters);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-istemporarymonosupported
    BOOL IsTemporaryMonoSupported();

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrestricttooutput
    void GetRestrictToOutput([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIOutput>))] out IDXGIOutput ppRestrictToOutput);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setbackgroundcolor
    void SetBackgroundColor(in DXGI_RGBA pColor);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getbackgroundcolor
    void GetBackgroundColor(out DXGI_RGBA pColor);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setrotation
    void SetRotation(DXGI_MODE_ROTATION Rotation);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrotation
    void GetRotation(out DXGI_MODE_ROTATION pRotation);
}
