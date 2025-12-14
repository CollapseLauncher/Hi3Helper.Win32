namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D_VECTOR_4F
{
    public D2D_VECTOR_4F(float X, float Y, float Z, float W)
    {
        x = X;
        y = Y;
        z = Z;
        w = W;
    }

    public float x;
    public float y;
    public float z;
    public float w;
}
