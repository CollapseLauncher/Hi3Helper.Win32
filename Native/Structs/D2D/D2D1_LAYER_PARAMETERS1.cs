using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_LAYER_PARAMETERS1
{
    public D2D_RECT_F contentBounds;
    public nint geometricMask;
    public D2D1_ANTIALIAS_MODE maskAntialiasMode;
    public D2D_MATRIX_3X2_F maskTransform;
    public float opacity;
    public nint opacityBrush;
    public D2D1_LAYER_OPTIONS1 layerOptions;
}