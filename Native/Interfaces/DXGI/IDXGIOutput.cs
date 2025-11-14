using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIOutput)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIOutput
{
    /// <summary>Get a description of the output.</summary>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns a code that indicates success or failure. S_OK if successful, <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a> if <i>pDesc</i> is passed in as <b>NULL</b>.</para>
    /// </returns>
    /// <remarks>On a high DPI desktop, <b>GetDesc</b> returns the visualized screen size unless the app is marked high DPI aware. For info about writing DPI-aware Win32 apps, see <a href="https://docs.microsoft.com/windows/desktop/hidpi/high-dpi-desktop-application-development-on-windows">High DPI</a>.</remarks>
    void GetDesc(out DXGI_OUTPUT_DESC* pDesc);

    /// <summary>Gets the display modes that match the requested format and other input options. (IDXGIOutput.GetDisplayModeList)</summary>
    /// <param name="EnumFormat">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a></b> The color format (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Flags">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> Options for modes to include (see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-enum-modes">DXGI_ENUM_MODES</a>). DXGI_ENUM_MODES_SCALING needs to be specified to expose the display modes that require scaling.  Centered modes, requiring no scaling and corresponding directly to the display output, are enumerated by default.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pNumModes">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a>*</b> Set <i>pDesc</i> to <b>NULL</b> so that <i>pNumModes</i> returns the number of display modes that match the format and the options. Otherwise, <i>pNumModes</i> returns the number of display modes returned in <i>pDesc</i>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pDesc">
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>*</b> A pointer to a list of display modes (see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>); set to <b>NULL</b> to get the number of display modes.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>. It is rare, but possible, that the display modes available can change immediately after calling this method, in which case DXGI_ERROR_MORE_DATA is returned (if there is not enough room for all the display modes). If <b>GetDisplayModeList</b> is called from a Remote Desktop Services session (formerly Terminal Services session), DXGI_ERROR_NOT_CURRENTLY_AVAILABLE is returned.</para>
    /// </returns>
    /// <remarks>
    /// <para>In general, when switching from windowed to full-screen mode, a swap chain automatically chooses a display mode that meets (or exceeds) the resolution, color depth and refresh rate of the swap chain. To exercise more control over the display mode, use this API to poll the set of display modes that are validated against monitor capabilities, or all modes that match the desktop (if the desktop settings are not validated against the monitor). As shown, this API is designed to be called twice. First to get the number of modes available, and second to return a description of the modes.</para>
    /// <para></para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetDisplayModeList(
     DXGI_FORMAT EnumFormat,
     DXGI_ENUM_MODES Flags,
     ref uint pNumModes,
     DXGI_MODE_DESC* pDesc);

    /// <summary>Finds the display mode that most closely matches the requested display mode. (IDXGIOutput.FindClosestMatchingMode)</summary>
    /// <param name="pModeToMatch">
    /// <para>Type: <b>const <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>*</b> The desired display mode (see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>). Members of <b>DXGI_MODE_DESC</b> can be unspecified indicating no preference for that member.  A value of 0 for <b>Width</b> or <b>Height</b> indicates the value is unspecified.  If either <b>Width</b> or <b>Height</b> are 0, both must be 0.  A numerator and denominator of 0 in <b>RefreshRate</b> indicate it is unspecified. Other members of <b>DXGI_MODE_DESC</b> have enumeration values indicating the member is unspecified.  If <i>pConcernedDevice</i> is <b>NULL</b>, <b>Format</b> cannot be DXGI_FORMAT_UNKNOWN.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pClosestMatch">
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a>*</b> The mode that most closely matches <i>pModeToMatch</i>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pConcernedDevice">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nn-unknwn-iunknown">IUnknown</a>*</b> A pointer to the Direct3D device interface. If this parameter is <b>NULL</b>, only modes whose format matches that of <i>pModeToMatch</i> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned. For info about the formats that are supported for scan-out by the device at each feature level: </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para><b>FindClosestMatchingMode</b> behaves similarly to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-findclosestmatchingmode1">IDXGIOutput1::FindClosestMatchingMode1</a> except <b>FindClosestMatchingMode</b> considers only the mono display modes. <b>IDXGIOutput1::FindClosestMatchingMode1</b> considers only stereo modes if you set the <b>Stereo</b> member in the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ns-dxgi1_2-dxgi_mode_desc1">DXGI_MODE_DESC1</a> structure that <i>pModeToMatch</i> points to, and considers only mono modes if <b>Stereo</b> is not set.</para>
    /// <para><a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-findclosestmatchingmode1">IDXGIOutput1::FindClosestMatchingMode1</a> returns a matched display-mode set with only stereo modes or only mono modes. <b>FindClosestMatchingMode</b> behaves as though you specified the input mode as mono.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void FindClosestMatchingMode(
     DXGI_MODE_DESC* pModeToMatch,
     DXGI_MODE_DESC* pClosestMatch,
     nint pConcernedDevice);

    /// <summary>Halt a thread until the next vertical blank occurs.</summary>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the following <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>A vertical blank occurs when the raster moves from the lower right corner to the upper left corner to begin drawing the next frame.</remarks>
    void WaitForVBlank();

    /// <summary>Takes ownership of an output.</summary>
    /// <param name="pDevice">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nn-unknwn-iunknown">IUnknown</a>*</b> A pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/unknwn/nn-unknwn-iunknown">IUnknown</a> interface of a device (such as an <a href="https://docs.microsoft.com/windows/desktop/api/d3d10/nn-d3d10-id3d10device">ID3D10Device</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-takeownership#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="Exclusive">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">BOOL</a></b> Set to <b>TRUE</b> to enable other threads or applications to take ownership of the device; otherwise, set to <b>FALSE</b>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-takeownership#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para>When you are finished with the output, call <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-releaseownership">IDXGIOutput::ReleaseOwnership</a>. <b>TakeOwnership</b> should not be called directly by applications, since results will be unpredictable. It is called implicitly by the DXGI swap chain object during full-screen transitions, and should not be used as a substitute for swap-chain methods. <h3><a id="Notes_for_Windows_Store_apps"></a><a id="notes_for_windows_store_apps"></a><a id="NOTES_FOR_WINDOWS_STORE_APPS"></a>Notes for Windows Store apps</h3> If a Windows Store app uses <b>TakeOwnership</b>, it fails with <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-takeownership#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void TakeOwnership(nint pDevice, [MarshalAs(UnmanagedType.Bool)] bool Exclusive);

    /// <summary>Releases ownership of the output.</summary>
    /// <remarks>If you are not using a swap chain, get access to an output by calling <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-takeownership">IDXGIOutput::TakeOwnership</a> and release it when you are finished by calling <b>IDXGIOutput::ReleaseOwnership</b>. An application that uses a swap chain will typically not call either of these methods.</remarks>
    [PreserveSig]
    void ReleaseOwnership();

    /// <summary>Gets a description of the gamma-control capabilities.</summary>
    /// <param name="pGammaCaps">
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173062(v=vs.85)">DXGI_GAMMA_CONTROL_CAPABILITIES</a>*</b> A pointer to a  description of the gamma-control capabilities (see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173062(v=vs.85)">DXGI_GAMMA_CONTROL_CAPABILITIES</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrolcapabilities#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  Calling this method is only supported while in full-screen mode.</div> <div> </div></para>
    /// <para>For info about using gamma correction, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/using-gamma-correction">Using gamma correction</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrolcapabilities#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetGammaControlCapabilities(DXGI_GAMMA_CONTROL_CAPABILITIES* pGammaCaps);

    /// <summary>Sets the gamma controls.</summary>
    /// <param name="pArray">
    /// <para>Type: <b>const <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173061(v=vs.85)">DXGI_GAMMA_CONTROL</a>*</b> A pointer to a <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173061(v=vs.85)">DXGI_GAMMA_CONTROL</a> structure that describes the gamma curve to set.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setgammacontrol#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  Calling this method is only supported while in full-screen mode.</div> <div> </div></para>
    /// <para>For info about using gamma correction, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/using-gamma-correction">Using gamma correction</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setgammacontrol#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void SetGammaControl(DXGI_GAMMA_CONTROL* pArray);

    /// <summary>Gets the gamma control settings.</summary>
    /// <param name="pArray">
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173061(v=vs.85)">DXGI_GAMMA_CONTROL</a>*</b> An array of gamma control settings (see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173061(v=vs.85)">DXGI_GAMMA_CONTROL</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrol#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para><div class="alert"><b>Note</b>  Calling this method is only supported while in full-screen mode.</div> <div> </div></para>
    /// <para>For info about using gamma correction, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/using-gamma-correction">Using gamma correction</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrol#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetGammaControl(DXGI_GAMMA_CONTROL* pArray);

    /// <summary>Changes the display mode.</summary>
    /// <param name="pScanoutSurface">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgisurface">IDXGISurface</a>*</b> A pointer to a surface (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgisurface">IDXGISurface</a>) used for rendering an image to the screen. The surface must have been created as a back buffer (DXGI_USAGE_BACKBUFFER).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setdisplaysurface#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para><b>IDXGIOutput::SetDisplaySurface</b> should not be called directly by applications, since results will be unpredictable. It is called implicitly by the DXGI swap chain object during full-screen transitions, and should not be used as a substitute for swap-chain methods. This method should only be called between <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-takeownership">IDXGIOutput::TakeOwnership</a> and <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-releaseownership">IDXGIOutput::ReleaseOwnership</a> calls. <h3><a id="Notes_for_Windows_Store_apps"></a><a id="notes_for_windows_store_apps"></a><a id="NOTES_FOR_WINDOWS_STORE_APPS"></a>Notes for Windows Store apps</h3> If a Windows Store app uses <b>SetDisplaySurface</b>, it fails with <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setdisplaysurface#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void SetDisplaySurface([MarshalAs(UnmanagedType.Interface)] IDXGISurface pScanoutSurface);

    /// <summary>Gets a copy of the current display surface.</summary>
    /// <param name="pDestination">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgisurface">IDXGISurface</a>*</b> A pointer to a destination surface (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgisurface">IDXGISurface</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaysurfacedata#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns one of the <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a> values.</para>
    /// </returns>
    /// <remarks>
    /// <para><b>IDXGIOutput::GetDisplaySurfaceData</b> can only be called when an output is in full-screen mode. If the method succeeds, DXGI fills the destination surface. Use <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgioutput-getdesc">IDXGIOutput::GetDesc</a> to determine the size (width and height) of the output when you want to allocate space for the destination surface. This is true regardless of target monitor rotation. A destination surface created by a graphics component (such as Direct3D 10) must be created with CPU-write permission (see D3D10_CPU_ACCESS_WRITE). Other surfaces should be created with CPU read-write permission (see D3D10_CPU_ACCESS_READ_WRITE). This method will modify the surface data to fit the destination surface (stretch, shrink, convert format, rotate). The stretch and shrink is performed with point-sampling.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaysurfacedata#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetDisplaySurfaceData([MarshalAs(UnmanagedType.Interface)] IDXGISurface pDestination);

    /// <summary>Gets statistics about recently rendered frames.</summary>
    /// <param name="pStats">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_frame_statistics">DXGI_FRAME_STATISTICS</a>*</b> A pointer to frame statistics (see <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ns-dxgi-dxgi_frame_statistics">DXGI_FRAME_STATISTICS</a>).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getframestatistics#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> If this function succeeds, it returns S_OK. Otherwise, it might return <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR_INVALID_CALL</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para>This API is similar to <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiswapchain-getframestatistics">IDXGISwapChain::GetFrameStatistics</a>.</para>
    /// <para><div class="alert"><b>Note</b>  Calling this method is only supported while in full-screen mode.</div> <div> </div></para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getframestatistics#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void GetFrameStatistics(DXGI_FRAME_STATISTICS* pStats);
}