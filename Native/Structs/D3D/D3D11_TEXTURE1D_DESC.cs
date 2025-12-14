using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.DXGI;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_TEXTURE1D_DESC
{
    public uint Width;
    public uint MipLevels;
    public uint ArraySize;
    public DXGI_FORMAT Format;
    public D3D11_USAGE Usage;
    public uint BindFlags;
    public uint CPUAccessFlags;
    public uint MiscFlags;
}
