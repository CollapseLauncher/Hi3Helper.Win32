using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Enums.DXGI
{
 /// <summary>Identifies resize behavior when the back-buffer size does not match the size of the target output.</summary>
 /// <remarks>
 /// <para>The DXGI_SCALING_NONE value is supported only for flip presentation model swap chains that you create with the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_effect">DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</a> value. You pass these values in a call to <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">IDXGIFactory2::CreateSwapChainForHwnd</a>, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow">IDXGIFactory2::CreateSwapChainForCoreWindow</a>, or  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition">IDXGIFactory2::CreateSwapChainForComposition</a>. DXGI_SCALING_ASPECT_RATIO_STRETCH will prefer to use a horizontal fill, otherwise it will use a vertical fill, using the following logic.</para>
 /// <para></para>
 /// <para>This doc was truncated.</para>
 /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling#">Read more on learn.microsoft.com</see>.</para>
 /// </remarks>
 public enum DXGI_SCALING
 {
  /// <summary>Directs DXGI to make the back-buffer contents scale to fit the presentation target size. This is the implicit behavior of DXGI when you call the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgifactory-createswapchain">IDXGIFactory::CreateSwapChain</a> method.</summary>
  DXGI_SCALING_STRETCH = 0,
  /// <summary>
  /// <para>Directs DXGI to make the back-buffer contents appear without any scaling when the presentation target size is not equal to the back-buffer size. The top edges of the back buffer and presentation target are aligned together. If the WS_EX_LAYOUTRTL style is associated with the <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HWND</a> handle to the target output window, the right edges of the back buffer and presentation target are aligned together; otherwise, the left edges are aligned together. All target area outside the back buffer is filled with window background color. This value specifies that all target areas outside the back buffer of a swap chain are filled with the background color that you specify in a call to <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setbackgroundcolor">IDXGISwapChain1::SetBackgroundColor</a>.</para>
  /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling#members">Read more on learn.microsoft.com</see>.</para>
  /// </summary>
  DXGI_SCALING_NONE = 1,
  /// <summary>
  /// <para>Directs DXGI to make the back-buffer contents scale to fit the presentation target size, while preserving the aspect ratio of the back-buffer. If the scaled back-buffer does not fill the presentation area, it will be centered with black borders. This constant is supported on Windows Phone 8 and Windows 10. Note that with legacy Win32 window swapchains, this works the same as DXGI_SCALING_STRETCH.</para>
  /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling#members">Read more on learn.microsoft.com</see>.</para>
  /// </summary>
  DXGI_SCALING_ASPECT_RATIO_STRETCH = 2,
 }
}
