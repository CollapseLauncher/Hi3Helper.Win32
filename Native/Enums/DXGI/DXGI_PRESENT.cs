using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Enums.DXGI;

/// <summary>The DXGI\_PRESENT constants specify options for presenting frames to the output.</summary>
/// <remarks>
/// <para>Presentation options are supplied during the [**IDXGISwapChain::Present**](/windows/desktop/api/DXGI/nf-dxgi-idxgiswapchain-present) or [**IDXGISwapChain1::Present1**](/windows/desktop/api/DXGI1_2/nf-dxgi1_2-idxgiswapchain1-present1) call. The buffers are specified in the swap chain description (see [**DXGI\_SWAP\_CHAIN\_DESC**](/windows/desktop/api/DXGI/ns-dxgi-dxgi_swap_chain_desc) or [**DXGI\_SWAP\_CHAIN\_DESC1**](/windows/desktop/api/DXGI1_2/ns-dxgi1_2-dxgi_swap_chain_desc1)). DXGI\_PRESENT\_RESTART is valid only for flip-model swap chains and full screen. Applications can use DXGI\_PRESENT\_RESTART to recover from glitches in playback, as well as to discard previously queued presentations. Discarding previously queued presentations is useful if those queued presentations are windowed scenarios. In particular, the previously queued presentation might have assumed that the window is an old size (that is, a resize operation occurred after submission). DXGI\_PRESENT\_RESTRICT\_TO\_OUTPUT is valid only for swap chains that specified a particular output to restrict content to when those swap chains were created ([**IDXGIFactory2::CreateSwapChainForHwnd**](/windows/desktop/api/DXGI1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd)). If there is no output to restrict to, the flag is invalid. DXGI\_PRESENT\_STEREO\_PREFER\_RIGHT indicates that if the stereo present must be reduced to mono the right eye should be used rather than the left (default) eye. You can use this flag if one side is higher quality (for example, if the stereo pair is synthesized from a standard image.) DXGI\_PRESENT\_STEREO\_TEMPORARY\_MONO indicates that the present should use the left buffer as a mono buffer. You can use this flag to avoid updating the right buffer when an application temporarily has no stereo content. You should use this flag whenever possible because it enables significant optimization by the operating system and under some circumstances it can avoid visible mode change artifacts. You should use the DXGI\_PRESENT\_STEREO\_TEMPORARY\_MONO flag in preference to switching to a mono swap chain for most applications that you anticipate will use stereo again. You need to balance the use of this flag in applications that are extremely long running or that rarely display stereo against the disadvantage of unused memory. > [!Note] > Full-screen applications that switch to a mono swap chain cause a mode change that generally has visible artifacts (for example, "flashing”). However, temporary mono might not be supported for full-screen swap chains.</para>
/// <para>The DXGI\_PRESENT\_STEREO\_PREFER\_RIGHT and DXGI\_PRESENT\_STEREO\_TEMPORARY\_MONO flags apply only to stereo swap chains. If you use them when you present mono swap chains, an invalid operation occurs. If you use the DXGI\_PRESENT\_STEREO\_TEMPORARY\_MONO flag when you present a stereo swap chain that does not support temporary mono, an error occurs, the swap chain does not display, and the presentation returns [DXGI\_ERROR\_INVALID\_CALL](dxgi-error.md).</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/direct3ddxgi/dxgi-present#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
[Flags]
public enum DXGI_PRESENT : uint
{
    DXGI_PRESENT_TEST = 0x00000001,
    DXGI_PRESENT_DO_NOT_SEQUENCE = 0x00000002,
    DXGI_PRESENT_RESTART = 0x00000004,
    DXGI_PRESENT_DO_NOT_WAIT = 0x00000008,
    DXGI_PRESENT_STEREO_PREFER_RIGHT = 0x00000010,
    DXGI_PRESENT_STEREO_TEMPORARY_MONO = 0x00000020,
    DXGI_PRESENT_RESTRICT_TO_OUTPUT = 0x00000040,
    DXGI_PRESENT_USE_DURATION = 0x00000100,
    DXGI_PRESENT_ALLOW_TEARING = 0x00000200,
}
