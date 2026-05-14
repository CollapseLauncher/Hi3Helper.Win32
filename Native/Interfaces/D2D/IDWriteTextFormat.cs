using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
public partial interface IDWriteTextFormat
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment
    void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment
    void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping
    void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection
    void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection
    void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop
    void SetIncrementalTabStop(float incrementalTabStop);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming
    void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteInlineObject?>))] IDWriteInlineObject? trimmingSign);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing
    void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment
    [PreserveSig]
    DWRITE_TEXT_ALIGNMENT GetTextAlignment();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
    [PreserveSig]
    DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping
    [PreserveSig]
    DWRITE_WORD_WRAPPING GetWordWrapping();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
    [PreserveSig]
    DWRITE_READING_DIRECTION GetReadingDirection();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection
    [PreserveSig]
    DWRITE_FLOW_DIRECTION GetFlowDirection();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop
    [PreserveSig]
    float GetIncrementalTabStop();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming
    void GetTrimming(out DWRITE_TRIMMING trimmingOptions, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteInlineObject>))] out IDWriteInlineObject trimmingSign);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing
    void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection
    void GetFontCollection([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontCollection>))] out IDWriteFontCollection fontCollection);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength
    [PreserveSig]
    uint GetFontFamilyNameLength();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname
    void GetFontFamilyName([MarshalUsing(CountElementName = nameof(nameSize))] string? fontFamilyName, uint nameSize);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight
    [PreserveSig]
    DWRITE_FONT_WEIGHT GetFontWeight();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle
    [PreserveSig]
    DWRITE_FONT_STYLE GetFontStyle();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch
    [PreserveSig]
    DWRITE_FONT_STRETCH GetFontStretch();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize
    [PreserveSig]
    float GetFontSize();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength
    [PreserveSig]
    uint GetLocaleNameLength();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename
    void GetLocaleName([MarshalUsing(CountElementName = nameof(nameSize))] string? localeName, uint nameSize);
}