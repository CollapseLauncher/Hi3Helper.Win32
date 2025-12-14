using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.DXGI;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_RENDER_TARGET_VIEW_DESC
{
    [StructLayout(LayoutKind.Explicit)]
    public struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public D3D11_BUFFER_RTV Buffer;

        [FieldOffset(0)]
        public D3D11_TEX1D_RTV Texture1D;

        [FieldOffset(0)]
        public D3D11_TEX1D_ARRAY_RTV Texture1DArray;

        [FieldOffset(0)]
        public D3D11_TEX2D_RTV Texture2D;

        [FieldOffset(0)]
        public D3D11_TEX2D_ARRAY_RTV Texture2DArray;

        [FieldOffset(0)]
        public D3D11_TEX2DMS_RTV Texture2DMS;

        [FieldOffset(0)]
        public D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;

        [FieldOffset(0)]
        public D3D11_TEX3D_RTV Texture3D;
    }

    public DXGI_FORMAT Format;
    public D3D11_RTV_DIMENSION ViewDimension;
    public _Anonymous_e__Union Anonymous;
}
