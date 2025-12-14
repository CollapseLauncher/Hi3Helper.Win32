using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("54d7898a-a061-40a7-bec7-e465bcba2c4f")]
public partial interface ID2D1CommandSink
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-begindraw
    void BeginDraw();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-enddraw
    void EndDraw();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setantialiasmode
    void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settags
    void SetTags(ulong tag1, ulong tag2);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settextantialiasmode
    void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settextrenderingparams
    void SetTextRenderingParams([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteRenderingParams?>))] IDWriteRenderingParams? textRenderingParams);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settransform
    void SetTransform(in D2D_MATRIX_3X2_F transform);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setprimitiveblend
    void SetPrimitiveBlend(D2D1_PRIMITIVE_BLEND primitiveBlend);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setunitmode
    void SetUnitMode(D2D1_UNIT_MODE unitMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-clear
    void Clear(nint /* optional D3DCOLORVALUE* */ color);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawglyphrun
    void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, nint /* optional DWRITE_GLYPH_RUN_DESCRIPTION* */ glyphRunDescription, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush foregroundBrush, DWRITE_MEASURING_MODE measuringMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawline
    void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush, float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawgeometry
    void DrawGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry geometry, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush, float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawrectangle
    void DrawRectangle(in D2D_RECT_F rect, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush, float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawbitmap
    void DrawBitmap([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Bitmap>))] ID2D1Bitmap bitmap, nint /* optional D2D_RECT_F* */ destinationRectangle, float opacity, D2D1_INTERPOLATION_MODE interpolationMode, nint /* optional D2D_RECT_F* */ sourceRectangle, nint /* optional D2D_MATRIX_4X4_F* */ perspectiveTransform);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawimage
    void DrawImage([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Image>))] ID2D1Image image, nint /* optional D2D_POINT_2F* */ targetOffset, nint /* optional D2D_RECT_F* */ imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawgdimetafile
    void DrawGdiMetafile([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GdiMetafile>))] ID2D1GdiMetafile gdiMetafile, nint /* optional D2D_POINT_2F* */ targetOffset);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillmesh
    void FillMesh([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Mesh>))] ID2D1Mesh mesh, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillopacitymask
    void FillOpacityMask([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Bitmap>))] ID2D1Bitmap opacityMask, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush, nint /* optional D2D_RECT_F* */ destinationRectangle, nint /* optional D2D_RECT_F* */ sourceRectangle);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillgeometry
    void FillGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry geometry, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush?>))] ID2D1Brush? opacityBrush);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillrectangle
    void FillRectangle(in D2D_RECT_F rect, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-pushaxisalignedclip
    void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-pushlayer
    void PushLayer(in D2D1_LAYER_PARAMETERS1 layerParameters1, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Layer?>))] ID2D1Layer? layer);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-popaxisalignedclip
    void PopAxisAlignedClip();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-poplayer
    void PopLayer();
}