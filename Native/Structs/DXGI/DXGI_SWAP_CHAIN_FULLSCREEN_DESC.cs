using Hi3Helper.Win32.Native.Enums.DXGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Structs.DXGI
{
 /// <summary>Describes full-screen mode for a swap chain.</summary>
 /// <remarks>This structure is used by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd">CreateSwapChainForHwnd</a> and <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getfullscreendesc">GetFullscreenDesc</a> methods.</remarks>
 public struct DXGI_SWAP_CHAIN_FULLSCREEN_DESC
 {
  /// <summary>A <a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_rational">DXGI_RATIONAL</a> structure that describes the refresh rate in hertz.</summary>
  public DXGI_RATIONAL RefreshRate;

  /// <summary>A member of the <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173067(v=vs.85)">DXGI_MODE_SCANLINE_ORDER</a> enumerated type that describes the scan-line drawing mode.</summary>
  public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

  /// <summary>A member of the <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173066(v=vs.85)">DXGI_MODE_SCALING</a> enumerated type that describes the scaling mode.</summary>
  public DXGI_MODE_SCALING Scaling;

  /// <summary>A Boolean value that specifies whether the swap chain is in windowed mode. <b>TRUE</b> if the swap chain is in windowed mode; otherwise, <b>FALSE</b>.</summary>
  public int Windowed;
 }
}
