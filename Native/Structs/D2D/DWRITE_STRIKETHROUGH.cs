using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public unsafe struct DWRITE_STRIKETHROUGH
{
    public float width;
    public float thickness;
    public float offset;
    public DWRITE_READING_DIRECTION readingDirection;
    public DWRITE_FLOW_DIRECTION flowDirection;
    public char* localeName;
    public DWRITE_MEASURING_MODE measuringMode;
}
