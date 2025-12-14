using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface, Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2")]
public partial interface ID3D11ShaderResourceView : ID3D11View
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11shaderresourceview-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_SHADER_RESOURCE_VIEW_DESC pDesc);
}
