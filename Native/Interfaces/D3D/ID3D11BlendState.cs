using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("75b68faa-347d-4159-8f45-a0640f01cd9a")]
public partial interface ID3D11BlendState : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11blendstate-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_BLEND_DESC pDesc);
}
