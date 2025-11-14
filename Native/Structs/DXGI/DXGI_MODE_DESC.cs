using Hi3Helper.Win32.Native.Enums.DXGI;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

public struct DXGI_MODE_DESC
{
    public uint Width;

    public uint Height;

    public DXGI_RATIONAL RefreshRate;

    public DXGI_FORMAT Format;

    public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

    public DXGI_MODE_SCALING Scaling;
}
