using Hi3Helper.Win32.Native.Interfaces.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed")]
public partial interface ID3D11ClassLinkage : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classlinkage-getclassinstance
    void GetClassInstance(string? pClassInstanceName, uint InstanceIndex, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassInstance>))] out ID3D11ClassInstance ppInstance);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classlinkage-createclassinstance
    void CreateClassInstance(string? pClassTypeName, uint ConstantBufferOffset, uint ConstantVectorOffset, uint TextureOffset, uint SamplerOffset, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassInstance>))] out ID3D11ClassInstance ppInstance);
}
