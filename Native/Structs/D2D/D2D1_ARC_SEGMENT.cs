using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_ARC_SEGMENT
{
    public D2D_POINT_2F point;
    public D2D_SIZE_F size;
    public float rotationAngle;
    public D2D1_SWEEP_DIRECTION sweepDirection;
    public D2D1_ARC_SIZE arcSize;
}