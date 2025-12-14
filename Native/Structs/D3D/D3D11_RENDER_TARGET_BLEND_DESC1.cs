using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_RENDER_TARGET_BLEND_DESC1
{
    public BOOL BlendEnable;
    public BOOL LogicOpEnable;
    public D3D11_BLEND SrcBlend;
    public D3D11_BLEND DestBlend;
    public D3D11_BLEND_OP BlendOp;
    public D3D11_BLEND SrcBlendAlpha;
    public D3D11_BLEND DestBlendAlpha;
    public D3D11_BLEND_OP BlendOpAlpha;
    public D3D11_LOGIC_OP LogicOp;
    public byte RenderTargetWriteMask;
}
