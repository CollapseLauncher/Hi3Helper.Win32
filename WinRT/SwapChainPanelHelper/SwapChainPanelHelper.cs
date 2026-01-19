using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.WinRT.SwapChainPanelHelper;

public static class SwapChainPanelHelper
{
    /// <summary>
    /// BEWARE: This IID is different from regular IDisposable.
    /// </summary>
    private static readonly Guid IDisposableWinRTObj_IID = new("30d5a829-7fa4-4026-83bb-d75bae4ea99e");
    private const uint DefaultDummyColor = 0xCEFABEBA; // Just a random

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void GetDirectNativeDelegateForDrawRoutine(
        nint                                                                 imageSourceP,
        nint                                                                 renderTargetP,
        out delegate* unmanaged[Stdcall]<nint, uint, in Rect, out nint, int> s_beginDraw,
        out delegate* unmanaged[Stdcall]<nint, nint, in Rect, int>           s_drawImage,
        out delegate* unmanaged[Stdcall]<nint, int>                          s_dispose,
        in  Rect                                                             updateWinRect)
    {
        // -- CanvasImageSource.CreateDrawingSession(Color, Rect);
        s_beginDraw = (delegate* unmanaged[Stdcall]<nint, uint, in Rect, out nint, int>)(*(*(void***)imageSourceP + 7));
        Marshal.ThrowExceptionForHR(s_beginDraw(imageSourceP, DefaultDummyColor, in updateWinRect, out nint drawingSessionPpv));

        // -- CanvasDrawingSession.DrawImage(ICanvasBitmap, Rect);
        //    This method is the shortest based on the implementation source at:
        //    https://github.com/microsoft/Win2D/blob/65e90b29055de64b02e7f2a3d3f042b7fa36326c/winrt/lib/drawing/CanvasDrawingSession.cpp#L254
        s_drawImage = (delegate* unmanaged[Stdcall]<nint, nint, in Rect, int>)(*(*(void***)drawingSessionPpv + 12));
        Marshal.ThrowExceptionForHR(s_drawImage(drawingSessionPpv, renderTargetP, in updateWinRect));

        // -- Query to WinRT's IDisposable
        QueryInterfaceShort(drawingSessionPpv, in IDisposableWinRTObj_IID, out nint disposablePpv);

        // -- CanvasDrawingSession.Dispose()
        s_dispose = (delegate* unmanaged[Stdcall]<nint, int>)(*(*(void***)disposablePpv + 6));
        Marshal.ThrowExceptionForHR(s_dispose(disposablePpv));

        // -- Release object
        ReleaseShort(drawingSessionPpv);
        ReleaseShort(disposablePpv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void NativeSurfaceImageSource_BeginDrawEndDrawUnsafe(
        nint                                                             imageSourceP,
        nint                                                             renderTargetP,
        delegate* unmanaged[Stdcall]<nint, uint, in Rect, out nint, int> s_beginDraw,
        delegate* unmanaged[Stdcall]<nint, nint, in Rect, int>           s_drawImage,
        delegate* unmanaged[Stdcall]<nint, int>                          s_dispose,
        in Rect                                                          updateWinRect)
    {
        // -- CanvasImageSource.CreateDrawingSession(Color, Rect);
        Marshal.ThrowExceptionForHR(s_beginDraw(imageSourceP, DefaultDummyColor, in updateWinRect, out nint drawingSessionPpv));

        // -- CanvasDrawingSession.DrawImage(ICanvasBitmap, Rect);
        //    This method is the shortest based on the implementation source at:
        //    https://github.com/microsoft/Win2D/blob/65e90b29055de64b02e7f2a3d3f042b7fa36326c/winrt/lib/drawing/CanvasDrawingSession.cpp#L254
        Marshal.ThrowExceptionForHR(s_drawImage(drawingSessionPpv, renderTargetP, in updateWinRect));

        // -- Query to WinRT's IDisposable
        QueryInterfaceShort(drawingSessionPpv, in IDisposableWinRTObj_IID, out nint disposablePpv);

        // -- CanvasDrawingSession.Dispose()
        Marshal.ThrowExceptionForHR(s_dispose(disposablePpv));

        // -- Release object
        ReleaseShort(drawingSessionPpv);
        ReleaseShort(disposablePpv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void MediaPlayer_CopyFrameToVideoSurfaceUnsafe(
        nint    playerP,
        nint    surfaceP,
        in Rect updateWinRect)
        => Marshal.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<nint, nint, in Rect, int>)(*(*(void***)playerP + 11)))(playerP, surfaceP, in updateWinRect)); // +11 == .CopyFrameToVideoSurface(nint, Rect)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe int QueryInterfaceShort(nint pUnk, in Guid iid, out nint ppv)
        => ((delegate* unmanaged<nint, in Guid, out nint, int>)
            (**(void***)pUnk))(pUnk, in iid, out ppv);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe int ReleaseShort(nint pUnk)
        => ((delegate* unmanaged<nint, int>)
            (*(*(void***)pUnk + 2)))(pUnk);
}