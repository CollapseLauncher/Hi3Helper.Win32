using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
public partial interface ID3D11ClassInstance : ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getclasslinkage
    [PreserveSig]
    void GetClassLinkage([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage>))] out ID3D11ClassLinkage ppLinkage);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_CLASS_INSTANCE_DESC pDesc);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getinstancename
    [PreserveSig]
    void GetInstanceName([MarshalUsing(CountElementName = nameof(pBufferLength))] string? pInstanceName, ref nuint pBufferLength);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-gettypename
    [PreserveSig]
    void GetTypeName([MarshalUsing(CountElementName = nameof(pBufferLength))] string? pTypeName, ref nuint pBufferLength);
}