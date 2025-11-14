using Hi3Helper.Win32.Native.Enums.DXGI;
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo
// ReSharper disable GrammarMistakeInComment
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

public struct DXGI_SWAP_CHAIN_DESC
{
    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a></b> A <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a> structure that describes the backbuffer display mode.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_MODE_DESC BufferDesc;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a></b> A <a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a> structure that describes multi-sampling parameters.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SAMPLE_DESC SampleDesc;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-usage">DXGI_USAGE</a></b> A member of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-usage">DXGI_USAGE</a> enumerated type that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_USAGE BufferUsage;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> A value that describes the number of buffers in the swap chain. When you call  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgifactory-createswapchain">IDXGIFactory::CreateSwapChain</a> to create a full-screen swap chain, you typically include the front buffer in this value. For more information about swap-chain buffers, see Remarks.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint BufferCount;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a></b> An <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a> handle to the output window. This member must not be <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nint OutputWindow;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">BOOL</a></b> A Boolean value that specifies whether the output is in windowed mode. <b>TRUE</b> if the output is in windowed mode; otherwise, <b>FALSE</b>. We recommend that you create a windowed swap chain and allow the end user to change the swap chain to full screen through <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate">IDXGISwapChain::SetFullscreenState</a>; that is, do not set this member to FALSE to force the swap chain to be full screen. However, if you create the swap chain as full screen, also provide the end user with a list of supported display modes through the <b>BufferDesc</b> member because a swap chain that is created with an unsupported display mode might cause the display to go black and prevent the end user from seeing anything. For more information about choosing windowed verses full screen, see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgifactory-createswapchain">IDXGIFactory::CreateSwapChain</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nint Windowed;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT</a></b> A member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT</a> enumerated type that describes options for handling the contents of the presentation buffer after presenting a surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SWAP_EFFECT SwapEffect;

    private DXGI_SWAP_CHAIN_FLAG _flags;

    // ReSharper disable once ConvertToAutoProperty
    public DXGI_SWAP_CHAIN_FLAG Flags
    {
        get => _flags;
        set => _flags = value;
    }
}
