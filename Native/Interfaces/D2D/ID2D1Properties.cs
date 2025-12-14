using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("483473d7-cd46-4f9d-9d3a-3112aa80159d")]
public partial interface ID2D1Properties
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertycount
    [PreserveSig]
    uint GetPropertyCount();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyname(uint32_pwstr_uint32)
    void GetPropertyName(uint index, [MarshalUsing(CountElementName = nameof(nameCount))] string? name, uint nameCount);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertynamelength(u)
    [PreserveSig]
    uint GetPropertyNameLength(uint index);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-gettype(uint32)
    [PreserveSig]
    D2D1_PROPERTY_TYPE GetType(uint index);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyindex
    [PreserveSig]
    uint GetPropertyIndex(string? name);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvaluebyname(pcwstr_constbyte_uint32)
    void SetValueByName(string? name, D2D1_PROPERTY_TYPE type, nint /* byte array */ data, uint dataSize);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvalue(u_constbyte_uint32)
    void SetValue(uint index, D2D1_PROPERTY_TYPE type, nint /* byte array */ data, uint dataSize);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluebyname(pcwstr)
    void GetValueByName(string? name, D2D1_PROPERTY_TYPE type, nint /* byte array */ data, uint dataSize);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvalue(u_t)
    void GetValue(uint index, D2D1_PROPERTY_TYPE type, nint /* byte array */ data, uint dataSize);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluesize(u)
    [PreserveSig]
    uint GetValueSize(uint index);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getsubproperties(uint32_id2d1properties)
    void GetSubProperties(uint index, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Properties>))] out ID2D1Properties subProperties);
}