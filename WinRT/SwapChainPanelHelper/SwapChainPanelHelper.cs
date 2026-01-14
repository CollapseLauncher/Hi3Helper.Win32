using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void NativeSurfaceImageSource_BeginDrawEndDrawUnsafe(
        nint    imageSourceP,
        nint    renderTargetP,
        in Rect updateRect)
    {
        nint drawingSessionPpv = nint.Zero;
        uint colorDummy        = 0;

        void* colorDummyP = Unsafe.AsPointer(in colorDummy);
        void* updateRectP = Unsafe.AsPointer(in updateRect);

        // -- CanvasImageSource.CreateDrawingSession(Color);
        Marshal.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<nint, void*, void**, int>)(*(*(void***)imageSourceP + 6)))(imageSourceP, colorDummyP, (void**)&drawingSessionPpv));

        // -- CanvasDrawingSession.DrawImage(ICanvasImage);
        Marshal.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<nint, void*, void*, int>)(*(*(void***)drawingSessionPpv + 9)))(drawingSessionPpv, (void*)renderTargetP, updateRectP));

        // -- Query to WinRT's IDisposable
        Marshal.QueryInterface(drawingSessionPpv, in IDisposableWinRTObj_IID, out nint disposablePpv);
        
        // -- CanvasDrawingSession.Dispose()
        Marshal.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<nint, int>)(*(*(void***)disposablePpv + 6)))(disposablePpv));

        // -- Release object
        Marshal.Release(drawingSessionPpv);
        Marshal.Release(disposablePpv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void MediaPlayer_CopyFrameToVideoSurfaceUnsafe(
        nint playerP,
        nint surfaceP)
        => Marshal.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<nint, nint, int>)(*(*(void***)playerP + 10)))(playerP, surfaceP)); // +10 == .CopyFrameToVideoSurface(nint)
}