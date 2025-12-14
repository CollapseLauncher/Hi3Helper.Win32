using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs.D3D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_GRADIENT_MESH_PATCH
{
    public D2D_POINT_2F point00;
    public D2D_POINT_2F point01;
    public D2D_POINT_2F point02;
    public D2D_POINT_2F point03;
    public D2D_POINT_2F point10;
    public D2D_POINT_2F point11;
    public D2D_POINT_2F point12;
    public D2D_POINT_2F point13;
    public D2D_POINT_2F point20;
    public D2D_POINT_2F point21;
    public D2D_POINT_2F point22;
    public D2D_POINT_2F point23;
    public D2D_POINT_2F point30;
    public D2D_POINT_2F point31;
    public D2D_POINT_2F point32;
    public D2D_POINT_2F point33;
    public D3DCOLORVALUE color00;
    public D3DCOLORVALUE color03;
    public D3DCOLORVALUE color30;
    public D3DCOLORVALUE color33;
    public D2D1_PATCH_EDGE_MODE topEdgeMode;
    public D2D1_PATCH_EDGE_MODE leftEdgeMode;
    public D2D1_PATCH_EDGE_MODE bottomEdgeMode;
    public D2D1_PATCH_EDGE_MODE rightEdgeMode;
}
