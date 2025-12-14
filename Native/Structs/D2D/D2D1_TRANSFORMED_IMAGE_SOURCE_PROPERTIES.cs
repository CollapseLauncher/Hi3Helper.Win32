using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES
{
    public D2D1_ORIENTATION orientation;
    public float scaleX;
    public float scaleY;
    public D2D1_INTERPOLATION_MODE interpolationMode;
    public D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS options;
}