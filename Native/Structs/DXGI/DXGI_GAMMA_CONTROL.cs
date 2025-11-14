using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Structs.DXGI;

public unsafe struct DXGI_GAMMA_CONTROL
{
    public DXGI_RGB Scale;

    public DXGI_RGB Offset;

    private fixed float _gammaCurve[1025 * 3];

    public Span<DXGI_RGB> GammaCurveSpan
    {
        get
        {
            fixed (void* gammaCurvePtr = _gammaCurve)
            {
                return new Span<DXGI_RGB>(gammaCurvePtr, 1025);
            }
        }
    }
}
