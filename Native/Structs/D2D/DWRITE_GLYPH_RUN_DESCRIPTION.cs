namespace Hi3Helper.Win32.Native.Structs.D2D;

public unsafe struct DWRITE_GLYPH_RUN_DESCRIPTION
{
    public char* localeName;
    public char* @string;
    public uint stringLength;
    public nint clusterMap;
    public uint textPosition;
}