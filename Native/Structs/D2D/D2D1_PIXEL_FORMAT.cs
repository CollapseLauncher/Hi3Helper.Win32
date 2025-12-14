using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Enums.DXGI;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_PIXEL_FORMAT
{
    public DXGI_FORMAT format;
    public D2D1_ALPHA_MODE alphaMode;
}
