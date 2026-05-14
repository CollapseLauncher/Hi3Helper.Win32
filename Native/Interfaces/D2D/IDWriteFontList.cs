using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
public partial interface IDWriteFontList
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection
    void GetFontCollection([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontCollection>))] out IDWriteFontCollection fontCollection);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount
    [PreserveSig]
    uint GetFontCount();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont
    void GetFont(uint index, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFont>))] out IDWriteFont font);
}
