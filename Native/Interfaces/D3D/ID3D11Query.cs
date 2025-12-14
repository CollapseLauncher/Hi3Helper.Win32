using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("d6c00747-87b7-425e-b84d-44d108560afd")]
public partial interface ID3D11Query : ID3D11Asynchronous
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11query-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_QUERY_DESC pDesc);
}
