using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_RENDER_TARGET_PROPERTIES
{
    public D2D1_RENDER_TARGET_TYPE type;
    public D2D1_PIXEL_FORMAT pixelFormat;
    public float dpiX;
    public float dpiY;
    public D2D1_RENDER_TARGET_USAGE usage;
    public D2D1_FEATURE_LEVEL minLevel;
}
