using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("a84cee02-3eea-4eee-a827-87c1a02a0fcc")]
public partial interface IDWriteFontCollection
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamilycount
    [PreserveSig]
    uint GetFontFamilyCount();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamily
    void GetFontFamily(uint index, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontFamily>))] out IDWriteFontFamily fontFamily);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-findfamilyname
    void FindFamilyName(string? familyName, out uint index, out BOOL exists);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfromfontface
    void GetFontFromFontFace([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontFace>))] IDWriteFontFace fontFace, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFont>))] out IDWriteFont font);
}