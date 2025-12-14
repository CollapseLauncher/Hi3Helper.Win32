using Hi3Helper.Win32.Native.Interfaces.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("839d1216-bb2e-412b-b7f4-a9dbebe08ed1")]
public partial interface ID3D11View : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource
    [PreserveSig]
    void GetResource([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] out ID3D11Resource ppResource);
}
