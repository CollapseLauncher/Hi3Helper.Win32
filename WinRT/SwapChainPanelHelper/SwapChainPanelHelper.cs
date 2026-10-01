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
    private static readonly Guid IClosableWinRTObj_IID = new("30d5a829-7fa4-4026-83bb-d75bae4ea99e");
    private const uint DefaultDummyColor = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void GetFuncForCanvasImageSource(
        nint                                                                           imageSourceP,
        nint                                                                           renderTargetP,
        nint                                                                           mediaPlayerP,
        out delegate* unmanaged[Stdcall]<nint, uint, ref readonly Rect, out nint, int> s_beginDraw,
        out delegate* unmanaged[Stdcall]<nint, nint, ref readonly Rect, int>           s_drawImage,
        out delegate* unmanaged[Stdcall]<nint, nint, int>                              s_copyFrameToSurface,
        out delegate* unmanaged[Stdcall]<nint, int>                                    s_dispose,
        in  Rect                                                                       updateWinRect)
    {
        string operation         = "CanvasImageSource.CreateDrawingSession";
        nint   drawingSessionPpv = 0;
        nint   disposablePpv     = 0;
        bool   closeAttempted    = false;

        try
        {
            // -- CanvasImageSource.CreateDrawingSession(Color, Rect);
            s_beginDraw = (delegate* unmanaged[Stdcall]<nint, uint, ref readonly Rect, out nint, int>)(*(*(void***)imageSourceP + 7));
            Marshal.ThrowExceptionForHR(s_beginDraw(imageSourceP, DefaultDummyColor, in updateWinRect, out drawingSessionPpv));

            operation = "CanvasDrawingSession.QueryInterface(IClosable)";
            Marshal.ThrowExceptionForHR(QueryInterfaceShort(drawingSessionPpv, in IClosableWinRTObj_IID, out disposablePpv));
            s_dispose = (delegate* unmanaged[Stdcall]<nint, int>)(*(*(void***)disposablePpv + 6));

            // -- CanvasDrawingSession.DrawImage(ICanvasBitmap, Rect);
            //    This method is the shortest based on the implementation source at:
            //    https://github.com/microsoft/Win2D/blob/65e90b29055de64b02e7f2a3d3f042b7fa36326c/winrt/lib/drawing/CanvasDrawingSession.cpp#L254
            operation = "CanvasDrawingSession.DrawImageToRect";
            s_drawImage = (delegate* unmanaged[Stdcall]<nint, nint, ref readonly Rect, int>)(*(*(void***)drawingSessionPpv + 12));
            Marshal.ThrowExceptionForHR(s_drawImage(drawingSessionPpv, renderTargetP, in updateWinRect));

            // -- MediaPlayer.CopyFrameToVideoSurface(IDirect3DSurface)
            s_copyFrameToSurface = (delegate* unmanaged[Stdcall]<nint, nint, int>)(*(*(void***)mediaPlayerP + 10));

            // -- CanvasDrawingSession.Dispose() (or IClosable.Close())
            operation = "CanvasDrawingSession.Dispose";
            closeAttempted = true;
            Marshal.ThrowExceptionForHR(s_dispose(disposablePpv));
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"{operation} failed (HRESULT 0x{ex.HResult:X8}, rectangle {updateWinRect}).", ex);
        }
        finally
        {
            if (disposablePpv != 0)
            {
                // Close a partially initialized session without masking the original failure.
                if (!closeAttempted)
                    ((delegate* unmanaged[Stdcall]<nint, int>)(*(*(void***)disposablePpv + 6)))(disposablePpv);
                ReleaseShort(disposablePpv);
            }
            if (drawingSessionPpv != 0) ReleaseShort(drawingSessionPpv);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe nint CanvasSessionDrawUnsafe(
        nint                                                                       imageSourceP,
        nint                                                                       renderTargetP,
        delegate* unmanaged[Stdcall]<nint, uint, ref readonly Rect, out nint, int> s_beginDraw,
        delegate* unmanaged[Stdcall]<nint, nint, ref readonly Rect, int>           s_drawImage,
        ref readonly Rect                                                          updateWinRect)
    {
        // -- CanvasImageSource.CreateDrawingSession(Color, Rect);
        ThrowOrIgnoreNull(s_beginDraw(imageSourceP, DefaultDummyColor, in updateWinRect, out nint drawingSessionPpv));

        // -- CanvasDrawingSession.DrawImage(ICanvasBitmap, Rect);
        //    This method is the shortest based on the implementation source at:
        //    https://github.com/microsoft/Win2D/blob/65e90b29055de64b02e7f2a3d3f042b7fa36326c/winrt/lib/drawing/CanvasDrawingSession.cpp#L254
        ThrowOrIgnoreNull(s_drawImage(drawingSessionPpv, renderTargetP, in updateWinRect));

        return drawingSessionPpv;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void DrawingDisposeUnsafe(
        nint                                    drawingSessionPpv,
        delegate* unmanaged[Stdcall]<nint, int> s_dispose)
    {
        // -- Query to WinRT's IClosable
        QueryInterfaceShort(drawingSessionPpv, in IClosableWinRTObj_IID, out nint disposablePpv);

        // -- CanvasDrawingSession.Dispose() (aka IClosable.Close())
        ThrowOrIgnoreNull(s_dispose(disposablePpv));

        // -- Release object
        ReleaseShort(drawingSessionPpv);
        ReleaseShort(disposablePpv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    public static unsafe void MediaPlayerCopyFrameUnsafe(
        nint              playerP,
        nint              surfaceP)
        => ThrowOrIgnoreNull(((delegate* unmanaged[Stdcall]<nint, nint, int>)(*(*(void***)playerP + 10)))(playerP, surfaceP)); // +10 == .CopyFrameToVideoSurface(IDirect3DSurface)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    private static unsafe int QueryInterfaceShort(nint pUnk, ref readonly Guid iid, out nint ppv)
        => ((delegate* unmanaged<nint, ref readonly Guid, out nint, int>)
            (**(void***)pUnk))(pUnk, in iid, out ppv);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SkipLocalsInit]
    private static unsafe int ReleaseShort(nint pUnk)
        => ((delegate* unmanaged<nint, int>)
            (*(*(void***)pUnk + 2)))(pUnk);

    private static void ThrowOrIgnoreNull(int hr)
    {
        if (hr == unchecked((int)0x80004003))
            return;

        if (hr != 0)
            Marshal.ThrowExceptionForHR(hr);
    }
}
