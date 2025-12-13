using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
public partial interface ID3D11Texture2D : ID3D11Resource
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11texture2d-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_TEXTURE2D_DESC pDesc);
}