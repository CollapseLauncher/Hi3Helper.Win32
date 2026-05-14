using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("06152247-6f50-465a-9245-118bfd3b6007")]
public partial interface ID2D1Factory
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics
    void ReloadSystemMetrics();

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi
    [PreserveSig]
    void GetDesktopDpi(out float dpiX, out float dpiY);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createrectanglegeometry
    void CreateRectangleGeometry(in D2D_RECT_F rectangle, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1RectangleGeometry>))] out ID2D1RectangleGeometry rectangleGeometry);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createroundedrectanglegeometry
    void CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1RoundedRectangleGeometry>))] out ID2D1RoundedRectangleGeometry roundedRectangleGeometry);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createellipsegeometry
    void CreateEllipseGeometry(in D2D1_ELLIPSE ellipse, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1EllipseGeometry>))] out ID2D1EllipseGeometry ellipseGeometry);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup
    void CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In][MarshalUsing(CountElementName = nameof(geometriesCount))] ID2D1Geometry[] geometries, uint geometriesCount, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometryGroup>))] out ID2D1GeometryGroup geometryGroup);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createtransformedgeometry
    void CreateTransformedGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1TransformedGeometry>))] out ID2D1TransformedGeometry transformedGeometry);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry
    void CreatePathGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1PathGeometry>))] out ID2D1PathGeometry pathGeometry);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createstrokestyle
    void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, nint /* optional float* */ dashes, uint dashesCount, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle>))] out ID2D1StrokeStyle strokeStyle);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createdrawingstateblock
    void CreateDrawingStateBlock(nint /* optional D2D1_DRAWING_STATE_DESCRIPTION* */ drawingStateDescription, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteRenderingParams?>))] IDWriteRenderingParams? textRenderingParams, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DrawingStateBlock>))] out ID2D1DrawingStateBlock drawingStateBlock);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createwicbitmaprendertarget
    void CreateWicBitmapRenderTarget([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1RenderTarget>))] out ID2D1RenderTarget renderTarget);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1factory-createhwndrendertarget
    void CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1HwndRenderTarget>))] out ID2D1HwndRenderTarget hwndRenderTarget);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget(idxgisurface_constd2d1_render_target_properties__id2d1rendertarget)
    void CreateDxgiSurfaceRenderTarget([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGISurface>))] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1RenderTarget>))] out ID2D1RenderTarget renderTarget);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget
    void CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DCRenderTarget>))] out ID2D1DCRenderTarget dcRenderTarget);
}
