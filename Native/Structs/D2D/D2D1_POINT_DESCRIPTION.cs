namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_POINT_DESCRIPTION
{
    public D2D_POINT_2F point;
    public D2D_POINT_2F unitTangentVector;
    public uint endSegment;
    public uint endFigure;
    public float lengthToEndSegment;
}
