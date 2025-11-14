using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable GrammarMistakeInComment

// The code was source generated from CsWin32, then adjusted to work with GeneratedComInterface
namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIFactory)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIFactory : IDXGIObject
{
    /// <summary>Enumerates the adapters (video cards).</summary>
    /// <param name="Adapter">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The index of the adapter to enumerate.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppAdapter">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a>**</b> The address of a pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> interface at the position specified by the <i>Adapter</i> parameter.  This parameter must not be <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns S_OK if successful; otherwise, returns <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_FOUND</a> if the index is greater than or equal to the number of adapters in the local system, or <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a> if <i>ppAdapter</i> parameter is <b>NULL</b>.</para>
    /// </returns>
    /// <remarks>
    /// <para>When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change the adapters in a system, you must destroy and recreate the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgifactory">IDXGIFactory</a> object. The number of adapters in a system changes when you add or remove a display card, or dock or undock a laptop. When the <b>EnumAdapters</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the adapter interface, <b>EnumAdapters</b> increments the adapter interface's reference count. When you finish using the adapter interface, call the <a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nf-unknwn-iunknown-release">Release</a> method to decrement the reference count before you destroy the pointer. <b>EnumAdapters</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter corresponds with an index of zero. <b>EnumAdapters</b> next returns other adapters with outputs. <b>EnumAdapters</b> finally returns adapters without outputs.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void EnumAdapters(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter? ppAdapter);

    /// <summary>Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).</summary>
    /// <param name="WindowHandle">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a></b> The handle of the window that is to be monitored. This parameter can be <b>NULL</b>; but only if *Flags* is also 0.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-makewindowassociation#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Flags">Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b></param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a> if <i>WindowHandle</i> is invalid, or E_OUTOFMEMORY.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  If you call this API in a Session 0 process, it returns <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>.</div> <div> </div> The combination of <i>WindowHandle</i> and <i>Flags</i> informs DXGI to stop monitoring window messages for the previously-associated window. If the application switches to full-screen mode, DXGI will choose a full-screen resolution to be the smallest supported resolution that is larger or the same size as the current back buffer size. Applications can make some changes to make the transition from windowed to full screen more efficient. For example, on a WM_SIZE message, the application should release any outstanding swap-chain back buffers, call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers">IDXGISwapChain::ResizeBuffers</a>, then re-acquire the back buffers from the swap chain(s). This gives the swap chain(s) an opportunity to resize the back buffers, and/or recreate them to enable full-screen flipping operation. If the application does not perform this sequence, DXGI will still make the full-screen/windowed transition, but may be forced to use a stretch operation (since the back buffers may not be the correct size), which may be less efficient. Even if a stretch is not required, presentation may not be optimal because the back buffers might not be directly interchangeable with the front buffer. Thus, a call to <b>ResizeBuffers</b> on WM_SIZE is always recommended, since WM_SIZE is always sent during a fullscreen transition. While windowed, the application can, if it chooses, restrict the size of its window's client area to sizes to which it is comfortable rendering. A fully flexible application would make no such restriction, but UI elements or other design considerations can, of course, make this flexibility untenable. If the application further chooses to restrict its window's client area to just those that match supported full-screen resolutions, the application can field WM_SIZING, then check against <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode">IDXGIOutput::FindClosestMatchingMode</a>. If a matching mode is found, allow the resize. (The IDXGIOutput can be retrieved from <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-getcontainingoutput">IDXGISwapChain::GetContainingOutput</a>. Absent subsequent changes to desktop topology, this will be the same output that will be chosen when alt-enter is fielded and fullscreen mode is begun for that swap chain.) Applications that want to handle mode changes or Alt+Enter themselves should call <b>MakeWindowAssociation</b> with the DXGI_MWA_NO_WINDOW_CHANGES flag after swap chain creation. The <i>WindowHandle</i> argument, if non-<b>NULL</b>, specifies that the application message queues will not be handled by the DXGI runtime for all swap chains of a particular target <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a>.  Calling <b>MakeWindowAssociation</b> with the DXGI_MWA_NO_WINDOW_CHANGES flag after swapchain creation ensures that DXGI will not interfere with application's handling of window mode changes or Alt+Enter. You must call the **MakeWindowAssociation** method on the factory object associated with the target HWND swap chain(s). You can guarantee that by calling the [IDXGIObject::GetParent](/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent) method on the swap chain(s) to locate the factory. Here's a code example of doing that. </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-makewindowassociation#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void MakeWindowAssociation(nint WindowHandle, DXGI_MWA_FLAGS Flags);

    /// <summary>Get the window through which the user controls the transition to and from full screen.</summary>
    /// <param name="pWindowHandle">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a>*</b> A pointer to a window handle.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-getwindowassociation#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns a code that indicates success or failure. <b>S_OK</b> indicates success, <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a> indicates <i>pWindowHandle</i> was passed in as <b>NULL</b>.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  If you call this API in a Session 0 process, it returns <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>.</div> <div> </div></para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-getwindowassociation#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetWindowAssociation(out nint pWindowHandle);

    /// <summary>Creates a swap chain.</summary>
    /// <param name="pDevice">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nn-unknwn-iunknown">IUnknown</a>*</b> For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12 this is a pointer to a direct command queue (refer to <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nn-d3d12-id3d12commandqueue">ID3D12CommandQueue</a>) . This parameter cannot be <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pDesc">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_swap_chain_desc">DXGI_SWAP_CHAIN_DESC</a>*</b> A pointer to a  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_swap_chain_desc">DXGI_SWAP_CHAIN_DESC</a> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppSwapChain">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiswapchain">IDXGISwapChain</a>**</b> A pointer to a variable that receives a pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiswapchain">IDXGISwapChain</a> interface for the swap chain that <b>CreateSwapChain</b> creates.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b></para>
    /// <para><a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a>  if <i>pDesc</i> or <i>ppSwapChain</i> is <b>NULL</b>, DXGI_STATUS_OCCLUDED if you request full-screen mode and it is unavailable, or E_OUTOFMEMORY. Other error codes defined by the type of device passed in may also be returned.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  If you call this API in a Session 0 process, it returns <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>.</div> <div> </div> If you attempt to create a swap chain in full-screen mode, and full-screen mode is unavailable, the swap chain will be created in windowed mode and DXGI_STATUS_OCCLUDED will be returned. If the buffer width or the buffer height is zero, the sizes will be inferred from the output window size in the swap-chain description. Because the target output can't be chosen explicitly when the swap chain is created, we recommend not to create a full-screen swap chain. This can reduce presentation performance if the swap chain size and the output window size do not match. Here are two ways to ensure that the sizes match: </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    [PreserveSig]
    HResult CreateSwapChain(nint pDevice, DXGI_SWAP_CHAIN_DESC* pDesc, [MarshalAs(UnmanagedType.Interface)] out IDXGISwapChain ppSwapChain);

    /// <summary>Create an adapter interface that represents a software adapter.</summary>
    /// <param name="Module">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HMODULE</a></b> Handle to the software adapter's dll. HMODULE can be obtained with <a href="https://docs.microsoft.com/windows/desktop/api/libloaderapi/nf-libloaderapi-getmodulehandlea">GetModuleHandle</a> or <a href="https://docs.microsoft.com/windows/desktop/api/libloaderapi/nf-libloaderapi-loadlibrarya">LoadLibrary</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createsoftwareadapter#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppAdapter">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a>**</b> Address of a pointer to an adapter (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createsoftwareadapter#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> A <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">return code</a> indicating success or failure.</para>
    /// </returns>
    /// <remarks>
    /// <para>A software adapter is a DLL that implements the entirety of a device driver interface, plus emulation, if necessary, of kernel-mode graphics components for Windows. Details on implementing a software adapter can be found in the Windows Vista Driver Development Kit. This is a very complex development task, and is not recommended for general readers. Calling this method will increment the module's reference count by one. The reference count can be decremented by calling <a href="https://docs.microsoft.com/windows/desktop/api/libloaderapi/nf-libloaderapi-freelibrary">FreeLibrary</a>. The typical calling scenario is to call <a href="https://docs.microsoft.com/windows/desktop/api/libloaderapi/nf-libloaderapi-loadlibrarya">LoadLibrary</a>, pass the handle to <b>CreateSoftwareAdapter</b>, then immediately call <a href="https://docs.microsoft.com/windows/desktop/api/libloaderapi/nf-libloaderapi-freelibrary">FreeLibrary</a> on the DLL and forget the DLL's <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HMODULE</a>. Since the software adapter calls <b>FreeLibrary</b> when it is destroyed, the lifetime of the DLL will now be owned by the adapter, and the application is free of any further consideration of its lifetime.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createsoftwareadapter#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void CreateSoftwareAdapter(nint Module, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter? ppAdapter);
}
