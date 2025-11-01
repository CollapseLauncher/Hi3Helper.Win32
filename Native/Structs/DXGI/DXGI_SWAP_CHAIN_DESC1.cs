using Hi3Helper.Win32.Native.Enums.DXGI;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Describes a swap chain. (DXGI_SWAP_CHAIN_DESC1)</summary>
/// <remarks>
/// <para>This structure is used by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">CreateSwapChainForHwnd</a>,  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow">CreateSwapChainForCoreWindow</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">CreateSwapChainForComposition</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_3/nf-dxgi1_3-idxgifactorymedia-createswapchainforcompositionsurfacehandle">CreateSwapChainForCompositionSurfaceHandle</a>, and <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1">GetDesc1</a> methods. <div class="alert"><b>Note</b>  You cannot cast a <b>DXGI_SWAP_CHAIN_DESC1</b> to a <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_swap_chain_desc">DXGI_SWAP_CHAIN_DESC</a> and vice versa. An application must explicitly use the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1">IDXGISwapChain1::GetDesc1</a> method to retrieve the newer version of the swap-chain description structure.</div> <div> </div> In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer. For a <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-flip-model">flip-model</a> swap chain (that is, a swap chain that has the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_DISCARD</a> or <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value set in the <b>SwapEffect</b> member), you must set the <b>Format</b> member to <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT_R16G16B16A16_FLOAT</a>, <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>, or <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>; you must set the <b>Count</b> member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a> structure that the <b>SampleDesc</b> member specifies to one and the <b>Quality</b> member of <b>DXGI_SAMPLE_DESC</b> to zero because multiple sample antialiasing (MSAA) is not supported; you must set the <b>BufferCount</b> member to from two to sixteen. For more info about flip-model swap chain, see DXGI Flip Model.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
public struct DXGI_SWAP_CHAIN_DESC1
{
    /// <summary>
    /// <para>A value that describes the resolution width. If you specify the width as zero when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a> method to create a swap chain, the runtime obtains the width from the output window and assigns this width value to the swap-chain description. You can subsequently call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1">IDXGISwapChain1::GetDesc1</a> method to retrieve the assigned width value. You cannot specify the width as zero when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Width;

    /// <summary>
    /// <para>A value that describes the resolution height. If you specify the height as zero when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a> method to create a swap chain, the runtime obtains the height from the output window and assigns this height value to the swap-chain description. You can subsequently call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1">IDXGISwapChain1::GetDesc1</a> method to retrieve the assigned height value. You cannot specify the height as zero when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Height;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a> structure that describes the display format.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_FORMAT Format;

    /// <summary>
    /// <para>Specifies whether the full-screen display mode or the swap-chain back buffer is stereo. <b>TRUE</b> if stereo; otherwise, <b>FALSE</b>. If you specify stereo, you must also specify a flip-model swap chain (that is, a swap chain that has the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value set in the <b>SwapEffect</b> member).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public int Stereo;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a> structure that describes multi-sampling parameters. This member is valid only with bit-block transfer (bitblt) model swap chains.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SAMPLE_DESC SampleDesc;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-usage">DXGI_USAGE</a>-typed value that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_USAGE BufferUsage;

    /// <summary>
    /// <para>A value that describes the number of buffers in the swap chain. When you create a full-screen swap chain, you typically include the front buffer in this value.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint BufferCount;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling">DXGI_SCALING</a>-typed value that identifies resize behavior if the size of the back buffer is not equal to the target output.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SCALING Scaling;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT</a>-typed value that describes the presentation model that is used by the swap chain and options for handling the contents of the presentation buffer after presenting a surface. You must specify the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method because this method supports only <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-flip-model">flip presentation model</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SWAP_EFFECT SwapEffect;

    /// <summary>
    /// <para>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ne-dxgi1_2-dxgi_alpha_mode">DXGI_ALPHA_MODE</a>-typed value that identifies the transparency behavior of the swap-chain back buffer.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_ALPHA_MODE AlphaMode;

    private DXGI_SWAP_CHAIN_FLAG _flags;

    // ReSharper disable once ConvertToAutoProperty
    internal DXGI_SWAP_CHAIN_FLAG Flags
    {
        get => _flags;
        set => _flags = value;
    }
}
