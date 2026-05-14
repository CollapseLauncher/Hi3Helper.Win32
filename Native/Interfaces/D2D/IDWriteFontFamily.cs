using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface, Guid("da20d8ef-812a-4c43-9802-62ec4abd7add")]
public partial interface IDWriteFontFamily : IDWriteFontList
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfamilynames
    void GetFamilyNames([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteLocalizedStrings>))] out IDWriteLocalizedStrings names);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfirstmatchingfont
    void GetFirstMatchingFont(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFont>))] out IDWriteFont matchingFont);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getmatchingfonts
    void GetMatchingFonts(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontList>))] out IDWriteFontList matchingFonts);
}
