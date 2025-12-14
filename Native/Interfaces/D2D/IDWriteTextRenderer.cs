using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("ef8a8135-5cc6-45fe-8825-c5a0724eb819")]
public partial interface IDWriteTextRenderer : IDWritePixelSnapping
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawglyphrun
    void DrawGlyphRun(nint /* optional void* */ clientDrawingContext, float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun, in DWRITE_GLYPH_RUN_DESCRIPTION glyphRunDescription, nint clientDrawingEffect);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawunderline
    void DrawUnderline(nint /* optional void* */ clientDrawingContext, float baselineOriginX, float baselineOriginY, in DWRITE_UNDERLINE underline, nint clientDrawingEffect);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawstrikethrough
    void DrawStrikethrough(nint /* optional void* */ clientDrawingContext, float baselineOriginX, float baselineOriginY, in DWRITE_STRIKETHROUGH strikethrough, nint clientDrawingEffect);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawinlineobject
    void DrawInlineObject(nint /* optional void* */ clientDrawingContext, float originX, float originY, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteInlineObject>))] IDWriteInlineObject inlineObject, BOOL isSideways, BOOL isRightToLeft, nint clientDrawingEffect);
}