using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_DRAWING_STATE_DESCRIPTION
{
    public D2D1_ANTIALIAS_MODE antialiasMode;
    public D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode;
    public ulong tag1;
    public ulong tag2;
    public D2D_MATRIX_3X2_F transform;
}
