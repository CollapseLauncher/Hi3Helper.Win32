using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_DEPTH_STENCIL_DESC
{
    public BOOL DepthEnable;
    public D3D11_DEPTH_WRITE_MASK DepthWriteMask;
    public D3D11_COMPARISON_FUNC DepthFunc;
    public BOOL StencilEnable;
    public byte StencilReadMask;
    public byte StencilWriteMask;
    public D3D11_DEPTH_STENCILOP_DESC FrontFace;
    public D3D11_DEPTH_STENCILOP_DESC BackFace;
}
