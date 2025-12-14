using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_BITMAP_PROPERTIES1
{
    public D2D1_PIXEL_FORMAT pixelFormat;
    public float dpiX;
    public float dpiY;
    public D2D1_BITMAP_OPTIONS bitmapOptions;
    public nint colorContext;
}