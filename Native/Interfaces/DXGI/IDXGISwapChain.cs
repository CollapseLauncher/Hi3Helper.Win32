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
    /// <summary>Presents a rendered image to the user.</summary>
    /// <param name="SyncInterval">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> An integer that specifies how to synchronize presentation of a frame with the vertical blank.</para>
    /// <para>For the bit-block transfer (bitblt) model (<a href="https://docs.microsoft.com/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_DISCARD</a> or <a href="https://docs.microsoft.com/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_SEQUENTIAL</a>), values are: </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-present#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Flags">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/WinProg/windows-data-types">UINT</a></b> An integer value that contains swap-chain presentation options. These options are defined by the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-present">DXGI_PRESENT</a> constants.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-present#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Possible return values include: S_OK, DXGI_ERROR_DEVICE_RESET or DXGI_ERROR_DEVICE_REMOVED (see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-error">DXGI_ERROR</a>), DXGI_STATUS_OCCLUDED (see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-status">DXGI_STATUS</a>), or D3DDDIERR_DEVICEREMOVED. <div class="alert"><b>Note</b>  The <b>Present</b> method can return either DXGI_ERROR_DEVICE_REMOVED or D3DDDIERR_DEVICEREMOVED if a video card has been physically removed from the computer, or a driver upgrade for the video card has occurred.</div> <div> </div></para>
    /// </returns>
    /// <remarks>
    /// <para>Starting with Direct3D 11.1, consider using <a href="https://docs.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> because you can then use dirty rectangles and the scroll rectangle in the swap chain presentation and as such use less memory bandwidth and as a result less system power. For more info about using dirty rectangles and the scroll rectangle in swap chain presentation, see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-1-2-presentation-improvements">Using dirty rectangles and the scroll rectangle in swap chain presentation</a>. For the best performance when flipping swap-chain buffers in a full-screen application, see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/d3d10-graphics-programming-guide-dxgi">Full-Screen Application Performance Hints</a>. Because calling <b>Present</b> might cause the render thread to wait on the message-pump thread, be careful when calling this method in an application that uses multiple threads. For more details, see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/d3d10-graphics-programming-guide-dxgi">Multithreading Considerations</a>. </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-present#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    [PreserveSig]
    HResult Present(uint SyncInterval, DXGI_PRESENT Flags);

    /// <summary>Accesses one of the swap-chain's back buffers.</summary>
    /// <param name="Buffer">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> A zero-based buffer index. If the swap chain's swap effect is <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_DISCARD</a>, this method can only access the first buffer; for this situation, set the index to zero. If the swap chain's swap effect is either <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_SEQUENTIAL</a> or <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a>, only the swap chain's zero-index buffer can be read from and written to. The swap chain's buffers with indexes greater than zero can only be read from; so if you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiresource-getusage">IDXGIResource::GetUsage</a> method for such buffers, they have the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-usage">DXGI_USAGE_READ_ONLY</a> flag set.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> The type of interface used to manipulate the buffer.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppSurface">
    /// <para>Type: <b>void**</b> A pointer to a back-buffer interface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer">Learn more about this API from learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetBuffer(uint Buffer, in Guid riid, out nint ppSurface);

    /// <summary>Sets the display state to windowed or full screen.</summary>
    /// <param name="Fullscreen">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/WinProg/windows-data-types">BOOL</a></b> A Boolean value that specifies whether to set the display state to windowed or full screen. <b>TRUE</b> for full screen, and <b>FALSE</b> for windowed.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pTarget">
    /// <para>Type: [in, optional] <b><a href="https://docs.microsoft.com/windows/win32/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a>*</b> If you pass <b>TRUE</b> to the <i>Fullscreen</i> parameter to set the display state to full screen, you can optionally set this parameter to a pointer to an <a href="https://docs.microsoft.com/windows/win32/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a> interface for the output target that contains the swap chain. If you set this parameter to <b>NULL</b>, DXGI will choose the output based on the swap-chain's device and the output window's placement. If you pass <b>FALSE</b> to <i>Fullscreen</i>, then you must set this parameter to <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> This method returns one of these values. - **S_OK** if the action succeeded and the swap chain was placed in the requested state. - **DXGI_ERROR_NOT_CURRENTLY_AVAILABLE** if the action failed. When this error is returned, your application can continue to run in windowed mode and try to switch to full-screen mode later. There are many reasons why a windowed-mode swap chain cannot switch to full-screen mode. Here are some examples. - The application is running over Terminal Server. - The output window is occluded. - The output window does not have keyboard focus. - Another application is already in full-screen mode. - **DXGI_STATUS_MODE_CHANGE_IN_PROGRESS** is returned if a fullscreen/windowed mode transition is occurring when this API is called. - Other error codes if you run out of memory or encounter another unexpected fault; these codes may be treated as hard, non-continuable errors.</para>
    /// </returns>
    /// <remarks>
    /// <para>DXGI may change the display state of a swap chain in response to end user or system requests. We recommend that you create a windowed swap chain and allow the end user to change the swap chain to full screen through <b>SetFullscreenState</b>; that is, do not set the <b>Windowed</b> member of <a href="https://docs.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc">DXGI_SWAP_CHAIN_DESC</a> to FALSE to force the swap chain to be full screen. However, if you create the swap chain as full screen, also provide the end user with a list of supported display modes because a swap chain that is created with an unsupported display mode might cause the display to go black and prevent the end user from seeing anything. Also, we recommend that you have a time-out confirmation screen or other fallback mechanism when you allow the end user to change display modes. <h3><a id="Notes_for_Windows_Store_apps"></a><a id="notes_for_windows_store_apps"></a><a id="NOTES_FOR_WINDOWS_STORE_APPS"></a>Notes for Windows Store apps</h3> If a Windows Store app calls <b>SetFullscreenState</b> to set the display state to full screen, <b>SetFullscreenState</b> fails with <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>. You cannot call <b>SetFullscreenState</b> on a swap chain that you created with <a href="https://docs.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a>. For the <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-flip-model">flip presentation model</a>, after you transition the display state to full screen, you must call <a href="https://docs.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers">ResizeBuffers</a> to ensure that your call to <a href="https://docs.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">IDXGISwapChain1::Present1</a> succeeds.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void SetFullscreenState(int Fullscreen, [MarshalAs(UnmanagedType.Interface)] IDXGIOutput pTarget);

    /// <summary>Get the state associated with full-screen mode.</summary>
    /// <param name="pFullscreen">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">BOOL</a>*</b> A pointer to a boolean whose value is either:</para>
    /// <para></para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getfullscreenstate#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppTarget">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a>**</b> A pointer to the output target (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a>) when the mode is full screen; otherwise <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getfullscreenstate#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>When the swap chain is in full-screen mode, a pointer to the  target output will be returned and its reference count will be incremented.</remarks>
    void GetFullscreenState(int* pFullscreen, out void* ppTarget);

    /// <summary>Get a description of the swap chain.</summary>
    /// <param name="result">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </param>
    /// <remarks>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getdesc">Learn more about this API from learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetDesc(out DXGI_SWAP_CHAIN_DESC result);

    /// <summary>Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.</summary>
    /// <param name="BufferCount">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain. This number can't be greater than <b>DXGI_MAX_SWAP_CHAIN_BUFFERS</b>. Set this number to zero to preserve the existing number of buffers in the swap chain. You can't specify less than two buffers for the flip presentation model.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Width">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The new width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window. You can't specify the width as zero if you called the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method to create the swap chain for a composition surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Height">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The new height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window. You can't specify the height as zero if you called the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a> method to create the swap chain for a composition surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="NewFormat">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a></b> A <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a>-typed value for the new format of the back buffer. Set this value to <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT_UNKNOWN</a> to preserve the existing format of the back buffer. The flip presentation model supports a more restricted set of formats than the bit-block transfer (bitblt) model.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="SwapChainFlags">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> A combination of <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_chain_flag">DXGI_SWAP_CHAIN_FLAG</a>-typed values that are combined by using a bitwise OR operation. The resulting value specifies options for swap-chain behavior.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns S_OK if successful; an error code otherwise. For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para>You can't resize a swap chain unless you release all outstanding references to its back buffers. You must release all of its direct and indirect references on the back buffers in order for <b>ResizeBuffers</b> to succeed.</para>
    /// <para>Direct references are held by the application after it calls <a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nf-unknwn-iunknown-addref">AddRef</a> on a resource.</para>
    /// <para>Indirect references are held by views to a resource, binding a view of the resource to a device context, a command list that used the resource, a command list that used a view to that resource, a command list that executed another command list that used the resource, and so on.</para>
    /// <para>Before you call <b>ResizeBuffers</b>, ensure that the application releases all references (by calling the appropriate number of <a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nf-unknwn-iunknown-release">Release</a> invocations) on the resources, any views to the resource, and any command lists that use either the resources or views, and ensure that neither the resource nor a view is still bound to a device context. You can use <a href="https://docs.microsoft.com/windows/desktop/api/d3d11/nf-d3d11-id3d11devicecontext-clearstate">ID3D11DeviceContext::ClearState</a> to ensure that all references are released. If a view is bound to a deferred context, you must discard the partially built command list as well (by calling <b>ID3D11DeviceContext::ClearState</b>, then <a href="https://docs.microsoft.com/windows/desktop/api/d3d11/nf-d3d11-id3d11devicecontext-finishcommandlist">ID3D11DeviceContext::FinishCommandList</a>, then <b>Release</b> on the command list). After you call <b>ResizeBuffers</b>, you can re-query interfaces via <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer">IDXGISwapChain::GetBuffer</a>.</para>
    /// <para>For swap chains that you created with <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_chain_flag">DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE</a>, before you call <b>ResizeBuffers</b>, also call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgisurface1-releasedc">IDXGISurface1::ReleaseDC</a> on the swap chain's back-buffer surface to ensure that you have no outstanding GDI device contexts (DCs) open.</para>
    /// <para>We recommend that you call <b>ResizeBuffers</b> when a client window is resized (that is, when an application receives a WM_SIZE message).</para>
    /// <para>The only difference between <b>IDXGISwapChain::ResizeBuffers</b> in Windows 8 versus Windows 7 is with flip presentation model swap chains that you create with the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> or DXGI_SWAP_EFFECT_FLIP_DISCARD value set. In Windows 8, you must call <b>ResizeBuffers</b> to realize a transition between full-screen mode and windowed mode; otherwise, your next call to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-present">IDXGISwapChain::Present</a> method fails.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void ResizeBuffers(uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, DXGI_SWAP_CHAIN_FLAG SwapChainFlags);

    /// <summary>Resizes the output target.</summary>
    /// <param name="pNewTargetParameters">
    /// <para>Type: <b>const <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>*</b> A pointer to a <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a> structure that describes the mode, which specifies the new width, height, format, and refresh rate of the target. If the format is <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT_UNKNOWN</a>, <b>ResizeTarget</b> uses the existing format. We only recommend that you use <b>DXGI_FORMAT_UNKNOWN</b> when the swap chain is in full-screen mode as this method is not thread safe.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizetarget#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns a code that indicates success or failure. <b>DXGI_STATUS_MODE_CHANGE_IN_PROGRESS</b> is returned if a full-screen/windowed mode transition is occurring when this API is called. See <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> for additional DXGI error codes.</para>
    /// </returns>
    /// <remarks>
    /// <para><b>ResizeTarget</b> resizes the target window when the swap chain is in windowed mode, and changes the display mode on the target output when the swap chain is in full-screen mode. Therefore, apps can call <b>ResizeTarget</b> to resize the target window (rather than a Microsoft Win32API such as <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos">SetWindowPos</a>) without knowledge of the swap chain display mode. If a Windows Store app calls <b>ResizeTarget</b>, it fails with <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>. You cannot call <b>ResizeTarget</b> on a swap chain that you created with <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a>. Apps must still call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers">IDXGISwapChain::ResizeBuffers</a> after they call <b>ResizeTarget</b> because only <b>ResizeBuffers</b> can change the back buffers. But, if those apps have implemented window resize processing to call <b>ResizeBuffers</b>, they don't need to explicitly call <b>ResizeBuffers</b> after they call <b>ResizeTarget</b> because the window resize processing will achieve what the app requires.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizetarget#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void ResizeTarget(DXGI_MODE_DESC* pNewTargetParameters);

    /// <summary>Get the output (the display monitor) that contains the majority of the client area of the target window.</summary>
    /// <param name="ppOutput">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a>**</b> A pointer to the output interface (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgioutput">IDXGIOutput</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getcontainingoutput#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para>If the method succeeds, the output interface will be filled and its reference count incremented. When you are finished with it, be sure to release the interface to avoid a memory leak. The output is also owned by the adapter on which the swap chain's device was created. You cannot call <b>GetContainingOutput</b> on a swap chain that you created with <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a>. To determine the output corresponding to such a swap chain, you should call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgifactory-enumadapters">IDXGIFactory::EnumAdapters</a> and then <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter-enumoutputs">IDXGIAdapter::EnumOutputs</a> to enumerate over all of the available outputs. You should then intersect the bounds of your <a href="https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.bounds">CoreWindow::Bounds</a> with the desktop coordinates of each output, as reported by <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_6/ns-dxgi1_6-dxgi_output_desc1">DXGI_OUTPUT_DESC1::DesktopCoordinates</a> or <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_output_desc">DXGI_OUTPUT_DESC::DesktopCoordinates</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getcontainingoutput#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetContainingOutput([MarshalAs(UnmanagedType.Interface)] out IDXGIOutput? ppOutput);

    /// <summary>Gets performance statistics about the last render frame.</summary>
    /// <param name="pStats">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_frame_statistics">DXGI_FRAME_STATISTICS</a>*</b> A pointer to a <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_frame_statistics">DXGI_FRAME_STATISTICS</a> structure for the frame statistics.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getframestatistics#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para>You cannot use <b>GetFrameStatistics</b> for swap chains that both use the bit-block transfer (bitblt) presentation model and draw in windowed mode. You can only use <b>GetFrameStatistics</b> for swap chains that either use the flip presentation model or draw in full-screen mode. You set the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value in the <b>SwapEffect</b> member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1">DXGI_SWAP_CHAIN_DESC1</a> structure to specify that the swap chain uses the flip presentation model. Statistics are not reliable in many multiple monitor scenarios, as well as scenarios where other fullscreen apps are running.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getframestatistics#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetFrameStatistics(DXGI_FRAME_STATISTICS* pStats);

    /// <summary>Gets the number of times that IDXGISwapChain::Present or IDXGISwapChain1::Present1 has been called.</summary>
    /// <param name="pLastPresentCount">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a>*</b> A pointer to a variable that receives the number of calls.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getlastpresentcount#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>For info about presentation statistics for a frame, see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_frame_statistics">DXGI_FRAME_STATISTICS</a>.</remarks>
    void GetLastPresentCount(out uint pLastPresentCount);
}
