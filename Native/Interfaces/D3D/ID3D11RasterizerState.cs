using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs.D3D;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ID3D11RasterizerState : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11rasterizerstate-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_RASTERIZER_DESC pDesc);
}
