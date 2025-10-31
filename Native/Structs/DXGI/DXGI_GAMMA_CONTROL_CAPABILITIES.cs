// ReSharper disable InconsistentNaming
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

public unsafe struct DXGI_GAMMA_CONTROL_CAPABILITIES
{
    public int ScaleAndOffsetSupported;

    public float MaxConvertedValue;

    public float MinConvertedValue;

    public uint NumGammaControlPoints;

    public fixed float ControlPointPositions[1025];
}
