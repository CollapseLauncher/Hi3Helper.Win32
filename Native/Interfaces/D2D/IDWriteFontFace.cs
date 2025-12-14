using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("5f49804d-7024-4d43-bfa9-d25984f53849")]
public partial interface IDWriteFontFace
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype
    [PreserveSig]
    DWRITE_FONT_FACE_TYPE GetType();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles
    void GetFiles(ref uint numberOfFiles, nint /* optional IDWriteFontFile* */ fontFiles);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex
    [PreserveSig]
    uint GetIndex();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations
    [PreserveSig]
    DWRITE_FONT_SIMULATIONS GetSimulations();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    BOOL IsSymbolFont();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics
    [PreserveSig]
    void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount
    [PreserveSig]
    ushort GetGlyphCount();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics
    void GetDesignGlyphMetrics([In][MarshalUsing(CountElementName = nameof(glyphCount))] ushort[] glyphIndices, uint glyphCount, [In][Out][MarshalUsing(CountElementName = nameof(glyphCount))] DWRITE_GLYPH_METRICS[] glyphMetrics, BOOL isSideways);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices
    void GetGlyphIndices([In][MarshalUsing(CountElementName = nameof(codePointCount))] uint[] codePoints, uint codePointCount, [In][Out][MarshalUsing(CountElementName = nameof(codePointCount))] ushort[] glyphIndices);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable
    void TryGetFontTable(uint openTypeTableTag, out nint tableData, out uint tableSize, out nint tableContext, out BOOL exists);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable
    [PreserveSig]
    void ReleaseFontTable(nint tableContext);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline
    void GetGlyphRunOutline(float emSize, [In][MarshalUsing(CountElementName = nameof(glyphCount))] ushort[] glyphIndices, nint /* optional float* */ glyphAdvances, nint /* optional DWRITE_GLYPH_OFFSET* */ glyphOffsets, uint glyphCount, BOOL isSideways, BOOL isRightToLeft, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1SimplifiedGeometrySink>))] ID2D1SimplifiedGeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode
    void GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteRenderingParams>))] IDWriteRenderingParams renderingParams, out DWRITE_RENDERING_MODE renderingMode);

    // https://learn.microsoft.com/windows/win32/DirectWrite/idwritefontface-getgdicompatiblemetrics
    void GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, nint /* optional DWRITE_MATRIX* */ transform, out DWRITE_FONT_METRICS fontFaceMetrics);

    // https://learn.microsoft.com/windows/win32/DirectWrite/idwritefontface-getgdicompatibleglyphmetrics
    void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, nint /* optional DWRITE_MATRIX* */ transform, BOOL useGdiNatural, [In][MarshalUsing(CountElementName = nameof(glyphCount))] ushort[] glyphIndices, uint glyphCount, [In][Out][MarshalUsing(CountElementName = nameof(glyphCount))] DWRITE_GLYPH_METRICS[] glyphMetrics, BOOL isSideways);
}
