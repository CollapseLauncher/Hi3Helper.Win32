using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("48570b85-d1ee-4fcd-a250-eb350722b037")]
public partial interface ID3D11Buffer : ID3D11Resource
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11buffer-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_BUFFER_DESC pDesc);
}
