using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("9fdac92a-1876-48c3-afad-25b94f84a9b6")]
public partial interface ID3D11DepthStencilView : ID3D11View
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11depthstencilview-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_DEPTH_STENCIL_VIEW_DESC pDesc);
}
