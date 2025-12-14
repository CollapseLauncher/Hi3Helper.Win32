namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct DWRITE_GLYPH_RUN
{
    public nint fontFace;
    public float fontEmSize;
    public uint glyphCount;
    public nint glyphIndices;
    public nint glyphAdvances;
    public nint glyphOffsets;
    public BOOL isSideways;
    public uint bidiLevel;
}