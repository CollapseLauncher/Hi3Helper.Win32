namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_SUBRESOURCE_TILING
{
    public uint WidthInTiles;
    public ushort HeightInTiles;
    public ushort DepthInTiles;
    public uint StartTileIndexInOverallResource;
}
