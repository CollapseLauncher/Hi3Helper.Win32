namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D_VECTOR_3F
{
    public D2D_VECTOR_3F(float X, float Y, float Z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    public float x;
    public float y;
    public float z;
}