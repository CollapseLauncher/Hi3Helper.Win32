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

[Guid(DXGIClsId.IDXGISwapChain1)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGISwapChain1 : IDXGISwapChain
{
    /// <summary>Gets a description of the swap chain.</summary>
    /// <returns>Returns S_OK if successful; an error code otherwise.  For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</returns>
    /// <remarks>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1">Learn more about this API from learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetDesc1(out DXGI_SWAP_CHAIN_DESC1* pDesc);

    /// <summary>Gets a description of a full-screen swap chain.</summary>
    /// <returns>
    /// <para><b>GetFullscreenDesc</b> returns: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>The semantics of <b>GetFullscreenDesc</b> are identical to that of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-getdesc">IDXGISwapchain::GetDesc</a> method for <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a>-based swap chains.</remarks>
    void GetFullscreenDesc(out DXGI_SWAP_CHAIN_FULLSCREEN_DESC* pDesc);

    /// <summary>Retrieves the underlying HWND for this swap-chain object.</summary>
    /// <param name="pHwnd">A pointer to a variable that receives the <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a> for the swap-chain object.</param>
    /// <returns>
    /// <para>Returns S_OK if successful; an error code otherwise.  For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>. If <i>pHwnd</i> receives <b>NULL</b> (that is, the swap chain is not <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a>-based), <b>GetHwnd</b> returns <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a>.</para>
    /// </returns>
    /// <remarks>Applications call the  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a> method to create a swap chain that is associated with an <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a>.</remarks>
    void GetHwnd(out nint pHwnd);

    /// <summary>Retrieves the underlying CoreWindow object for this swap-chain object.</summary>
    /// <param name="refiid">
    /// <para>A pointer to the globally unique identifier (GUID) of the <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow">CoreWindow</a> object that is referenced by the <i>ppUnk</i> parameter.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getcorewindow#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppUnk">A pointer to a variable that receives a pointer to the <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow">CoreWindow</a> object.</param>
    /// <returns>
    /// <para><b>GetCoreWindow</b> returns: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>Applications call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow">IDXGIFactory2::CreateSwapChainForCoreWindow</a> method to create a swap chain that is associated with an <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow">CoreWindow</a> object.</remarks>
    void GetCoreWindow(Guid* refiid, out nint ppUnk);

    /// <summary>Presents a frame on the display screen.</summary>
    /// <param name="SyncInterval">
    /// <para>An integer that specifies how to synchronize presentation of a frame with the vertical blank.</para>
    /// <para>For the bit-block transfer (bitblt) model (<a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_DISCARD</a> or <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_SEQUENTIAL</a>), values are: </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="PresentFlags">An integer value that contains swap-chain presentation options. These options are defined by the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT</a> constants.</param>
    /// <param name="pPresentParameters">A pointer to a <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ns-dxgi1_2-dxgi_present_parameters">DXGI_PRESENT_PARAMETERS</a> structure that describes updated rectangles and scroll information of the frame to present.</param>
    /// <returns>Possible return values include: S_OK, <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_DEVICE_REMOVED</a> , <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-status">DXGI_STATUS_OCCLUDED</a>, <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a>, or E_OUTOFMEMORY.</returns>
    /// <remarks>
    /// <para>An app can use <b>Present1</b> to optimize presentation by specifying scroll and dirty rectangles. When the runtime has information about these rectangles, the runtime can then perform necessary bitblts during presentation more efficiently and pass this metadata to the Desktop Window Manager (DWM). The DWM can then use the metadata to optimize presentation and pass the metadata to indirect displays and terminal servers to optimize traffic over the wire. An app must confine its modifications to only the dirty regions that it passes to <b>Present1</b>, as well as modify the entire dirty region to avoid undefined resource contents from being exposed. For flip presentation model swap chains that you create with the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value set, a successful presentation results in an unbind of back buffer 0 from the graphics pipeline, except for when you pass the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT_DO_NOT_SEQUENCE</a> flag in the <i>Flags</i> parameter. For info about how data values change when you present content to the screen, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/converting-data-color-space">Converting data for the color space</a>. For info about calling <b>Present1</b> when your app uses multiple threads, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/d3d10-graphics-programming-guide-dxgi">Multithread Considerations</a> and <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-render-multi-thread-intro">Multithreading and DXGI</a>. <h3><a id="Flip_presentation_model_queue"></a><a id="flip_presentation_model_queue"></a><a id="FLIP_PRESENTATION_MODEL_QUEUE"></a>Flip presentation model queue</h3> Suppose the following frames with sync-interval values are queued from oldest (A) to newest (E) before you call <b>Present1</b>. A: 3, B: 0, C: 0, D: 1, E: 0 When you call <b>Present1</b>, the runtime shows frame A for only 1 vertical blank interval. The runtime terminates frame A early because of the sync interval 0 in frame B.   Then the runtime shows frame D for 1 vertical blank interval, and then frame E until you submit a new presentation. The runtime discards frames B and C.</para>
    /// <para><h3><a id="Variable_refresh_rate_displays"></a><a id="variable_refresh_rate_displays"></a><a id="VARIABLE_REFRESH_RATE_DISPLAYS"></a>Variable refresh rate displays</h3> It is a requirement of variable refresh rate displays that tearing is enabled. The <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport">CheckFeatureSupport</a> method can be used to determine if this feature is available, and to set the required flags refer to the descriptions of <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT_ALLOW_TEARING</a> and <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_chain_flag">DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING</a>, and the <b>Variable refresh rate displays/Vsync off</b> section of <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-1-5-improvements">DXGI 1.5 Improvements</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    [PreserveSig]
    HResult Present1(uint SyncInterval, DXGI_PRESENT PresentFlags, DXGI_PRESENT_PARAMETERS* pPresentParameters);

    /// <summary>Determines whether a swap chain supports “temporary mono.”</summary>
    /// <returns>
    /// <para>Indicates whether to use the swap chain in temporary mono mode. <b>TRUE</b> indicates that you can use temporary-mono mode; otherwise, <b>FALSE</b>. <b>Platform Update for Windows 7:  </b>On Windows 7 or Windows Server 2008 R2 with the <a href="https://support.microsoft.com/help/2670838">Platform Update for Windows 7</a> installed, <b>IsTemporaryMonoSupported</b> always returns FALSE because stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <a href="https://docs.microsoft.com/windows/desktop/direct3darticles/platform-update-for-windows-7">Platform Update for Windows 7</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para>Temporary mono is a feature where a stereo swap chain can be presented using only the content in the left buffer.  To present using the left buffer as a mono buffer, an application calls the  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> method with the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT_STEREO_TEMPORARY_MONO</a> flag.  All windowed swap chains support temporary mono. However, full-screen swap chains optionally support temporary mono because not all hardware supports temporary mono on full-screen swap chains efficiently.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-istemporarymonosupported#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Bool)] bool IsTemporaryMonoSupported();

    /// <summary>Gets the output (the display monitor) to which you can restrict the contents of a present operation.</summary>
    /// <param name="ppRestrictToOutput">A pointer to a buffer that receives a pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a> interface for the restrict-to output. An application passes this pointer to <b>IDXGIOutput</b> in a call to the  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow">IDXGIFactory2::CreateSwapChainForCoreWindow</a>, or  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method to create the swap chain.</param>
    /// <returns>Returns S_OK if the restrict-to output was successfully retrieved; otherwise, returns E_INVALIDARG if the pointer is invalid.</returns>
    /// <remarks>
    /// <para>If the method succeeds, the runtime fills the buffer at <i>ppRestrictToOutput</i> with a pointer to the restrict-to output interface. This restrict-to output interface has its reference count incremented. When you are finished with it, be sure to release the interface to avoid a memory leak. The output is also owned by the adapter on which the swap chain's device was created.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrestricttooutput#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetRestrictToOutput([MarshalAs(UnmanagedType.Interface)] out IDXGIOutput ppRestrictToOutput);

    /// <summary>Changes the background color of the swap chain.</summary>
    /// <param name="pColor">A pointer to a <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-rgba">DXGI_RGBA</a> structure that specifies the background color to set.</param>
    /// <returns>
    /// <para><b>SetBackgroundColor</b> returns: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>
    /// <para>The background color affects only swap chains that you create with <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling">DXGI_SCALING_NONE</a> in windowed mode. You pass this value in a call to <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow">IDXGIFactory2::CreateSwapChainForCoreWindow</a>, or  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a>. Typically, the background color is not visible unless the swap-chain contents are smaller than the destination window. When you set the background color, it is not immediately realized. It takes effect in conjunction with your next call to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> method. The <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT</a> flags that you pass to <b>IDXGISwapChain1::Present1</b> can help achieve the effect that you require. For example, if you call <b>SetBackgroundColor</b> and then call <b>IDXGISwapChain1::Present1</b> with the <i>Flags</i> parameter set to <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT_DO_NOT_SEQUENCE</a>, you change only the background color without changing the displayed contents of the swap chain. When you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> method to display contents of the swap chain, <b>IDXGISwapChain1::Present1</b> uses the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ne-dxgi1_2-dxgi_alpha_mode">DXGI_ALPHA_MODE</a> value that is specified in the <b>AlphaMode</b> member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1">DXGI_SWAP_CHAIN_DESC1</a> structure to determine how to handle the <b>a</b> member of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-rgba">DXGI_RGBA</a> structure, the alpha value of the background color, that achieves window transparency. For example, if <b>AlphaMode</b> is <b>DXGI_ALPHA_MODE_IGNORE</b>, <b>IDXGISwapChain1::Present1</b> ignores the a member of <b>DXGI_RGBA</b>. <div class="alert"><b>Note</b>  Like all presentation data, we recommend that you perform floating point operations in a linear color space. When the desktop is in a fixed bit color depth mode, the operating system converts linear color data to standard RGB data (sRGB, gamma 2.2 corrected space) to compose to the screen. For more info, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/converting-data-color-space">Converting data for the color space</a>.</div> <div> </div></para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setbackgroundcolor#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void SetBackgroundColor(DXGI_RGBA* pColor);

    /// <summary>Retrieves the background color of the swap chain.</summary>
    /// <param name="pColor">A pointer to a <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-rgba">DXGI_RGBA</a> structure that receives the background color of the swap chain.</param>
    /// <returns>
    /// <para><b>GetBackgroundColor</b> returns: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  The background color that <b>GetBackgroundColor</b> retrieves does not indicate what the screen currently displays. The background color indicates what the screen will display with your next call to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> method. The default value of the background color is black with full opacity: 0,0,0,1.</div> <div> </div></para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getbackgroundcolor#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetBackgroundColor(DXGI_RGBA* pColor);

    /// <summary>Sets the rotation of the back buffers for the swap chain.</summary>
    /// <param name="Rotation">A <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)">DXGI_MODE_ROTATION</a>-typed value that specifies how to set the rotation of the back buffers for the swap chain.</param>
    /// <returns>
    /// <para><b>SetRotation</b> returns: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>
    /// <para>You can only use <b>SetRotation</b> to rotate the back buffers for flip-model swap chains that you present in windowed mode. <b>SetRotation</b> isn't supported for rotating the back buffers for flip-model swap chains that you present in full-screen mode. In this situation, <b>SetRotation</b> doesn't fail, but you must ensure that you specify no rotation (<a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)">DXGI_MODE_ROTATION_IDENTITY</a>) for the swap chain. Otherwise, when you call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> or <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-present">IDXGISwapChain::Present</a> to present a frame,  the presentation fails.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setrotation#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void SetRotation(DXGI_MODE_ROTATION Rotation);

    /// <summary>Gets the rotation of the back buffers for the swap chain.</summary>
    /// <param name="pRotation">A pointer to a variable that receives a <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)">DXGI_MODE_ROTATION</a>-typed value that specifies the rotation of the back buffers for the swap chain.</param>
    /// <returns>
    /// <para>Returns S_OK if successful; an error code otherwise.  For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>. <b>Platform Update for Windows 7:  </b>On Windows 7 or Windows Server 2008 R2 with the <a href="https://support.microsoft.com/help/2670838">Platform Update for Windows 7</a> installed, <b>GetRotation</b> fails with DXGI_ERROR_INVALID_CALL. For more info about the Platform Update for Windows 7, see <a href="https://docs.microsoft.com/windows/desktop/direct3darticles/platform-update-for-windows-7">Platform Update for Windows 7</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrotation">Learn more about this API from learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetRotation(DXGI_MODE_ROTATION* pRotation);
}
