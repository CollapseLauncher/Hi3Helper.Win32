using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7")]
public partial interface ID3D11RasterizerState : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11rasterizerstate-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_RASTERIZER_DESC pDesc);
}
