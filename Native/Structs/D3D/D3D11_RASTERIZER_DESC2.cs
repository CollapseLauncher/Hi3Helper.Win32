using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_RASTERIZER_DESC2
{
    public D3D11_FILL_MODE FillMode;
    public D3D11_CULL_MODE CullMode;
    public BOOL FrontCounterClockwise;
    public int DepthBias;
    public float DepthBiasClamp;
    public float SlopeScaledDepthBias;
    public BOOL DepthClipEnable;
    public BOOL ScissorEnable;
    public BOOL MultisampleEnable;
    public BOOL AntialiasedLineEnable;
    public uint ForcedSampleCount;
    public D3D11_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster;
}
