using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_IMAGE_BRUSH_PROPERTIES
{
    public D2D_RECT_F sourceRectangle;
    public D2D1_EXTEND_MODE extendModeX;
    public D2D1_EXTEND_MODE extendModeY;
    public D2D1_INTERPOLATION_MODE interpolationMode;
}