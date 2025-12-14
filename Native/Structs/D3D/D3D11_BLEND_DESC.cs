namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_BLEND_DESC
{
    public BOOL AlphaToCoverageEnable;
    public BOOL IndependentBlendEnable;
    public InlineArrayD3D11_RENDER_TARGET_BLEND_DESC_8 RenderTarget;
}