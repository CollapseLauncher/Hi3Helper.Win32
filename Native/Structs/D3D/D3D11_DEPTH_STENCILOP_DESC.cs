using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_DEPTH_STENCILOP_DESC
{
    public D3D11_STENCIL_OP StencilFailOp;
    public D3D11_STENCIL_OP StencilDepthFailOp;
    public D3D11_STENCIL_OP StencilPassOp;
    public D3D11_COMPARISON_FUNC StencilFunc;
}
