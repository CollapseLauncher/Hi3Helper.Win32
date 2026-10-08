using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("a24bc4d1-769e-43f7-8013-98ff566c18e2")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ID3D11CommandList : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11commandlist-getcontextflags
    [PreserveSig]
    uint GetContextFlags();
}
