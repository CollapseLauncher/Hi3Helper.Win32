using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface, Guid("dfdba067-0b8d-4865-875b-d7b4516cc164")]
public partial interface ID3D11RenderTargetView : ID3D11View
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11rendertargetview-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_RENDER_TARGET_VIEW_DESC pDesc);
}
