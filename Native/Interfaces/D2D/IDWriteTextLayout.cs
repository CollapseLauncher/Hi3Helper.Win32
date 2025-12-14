using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
public partial interface IDWriteTextLayout : IDWriteTextFormat
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth
    void SetMaxWidth(float maxWidth);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight
    void SetMaxHeight(float maxHeight);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontcollection
    void SetFontCollection([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontCollection>))] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontfamilyname
    void SetFontFamilyName(string? fontFamilyName, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontweight
    void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle
    void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstretch
    void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontsize
    void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setunderline
    void SetUnderline(BOOL hasUnderline, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough
    void SetStrikethrough(BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect
    void SetDrawingEffect(nint drawingEffect, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject
    void SetInlineObject([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteInlineObject>))] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-settypography
    void SetTypography([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteTypography>))] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename
    void SetLocaleName(string? localeName, DWRITE_TEXT_RANGE textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth
    [PreserveSig]
    float GetMaxWidth();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight
    [PreserveSig]
    float GetMaxHeight();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection
    void GetFontCollection(uint currentPosition, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteFontCollection>))] out IDWriteFontCollection fontCollection, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength
    void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname
    void GetFontFamilyName(uint currentPosition, [MarshalUsing(CountElementName = nameof(nameSize))] string? fontFamilyName, uint nameSize, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight
    void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle
    void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch
    void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize
    void GetFontSize(uint currentPosition, out float fontSize, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline
    void GetUnderline(uint currentPosition, out BOOL hasUnderline, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough
    void GetStrikethrough(uint currentPosition, out BOOL hasStrikethrough, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect
    void GetDrawingEffect(uint currentPosition, out nint drawingEffect, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject
    void GetInlineObject(uint currentPosition, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteInlineObject>))] out IDWriteInlineObject inlineObject, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography
    void GetTypography(uint currentPosition, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteTypography>))] out IDWriteTypography typography, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength
    void GetLocaleNameLength(uint currentPosition, out uint nameLength, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename
    void GetLocaleName(uint currentPosition, [MarshalUsing(CountElementName = nameof(nameSize))] string? localeName, uint nameSize, nint /* optional DWRITE_TEXT_RANGE* */ textRange);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw
    void Draw(nint /* optional void* */ clientDrawingContext, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteTextRenderer>))] IDWriteTextRenderer renderer, float originX, float originY);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlinemetrics
    void GetLineMetrics(nint /* optional DWRITE_LINE_METRICS* */ lineMetrics, uint maxLineCount, out uint actualLineCount);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics
    void GetMetrics(out DWRITE_TEXT_METRICS textMetrics);

    // https://learn.microsoft.com/windows/win32/DirectWrite/idwritetextlayout-getoverhangmetrics
    void GetOverhangMetrics(out DWRITE_OVERHANG_METRICS overhangs);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getclustermetrics
    void GetClusterMetrics(nint /* optional DWRITE_CLUSTER_METRICS* */ clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

    // https://learn.microsoft.com/windows/win32/DirectWrite/idwritetextlayout-determineminwidth
    void DetermineMinWidth(out float minWidth);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint
    void HitTestPoint(float pointX, float pointY, out BOOL isTrailingHit, out BOOL isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextposition
    void HitTestTextPosition(uint textPosition, BOOL isTrailingHit, out float pointX, out float pointY, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange
    void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY, nint /* optional DWRITE_HIT_TEST_METRICS* */ hitTestMetrics, uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);
}
