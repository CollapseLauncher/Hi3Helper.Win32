using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("d37f57e4-6908-459f-a199-e72f24f79987")]
public partial interface ID2D1DeviceContext1 : ID2D1DeviceContext
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-createfilledgeometryrealization
    void CreateFilledGeometryRealization([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry geometry, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometryRealization>))] out ID2D1GeometryRealization geometryRealization);

    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-createstrokedgeometryrealization
    void CreateStrokedGeometryRealization([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry geometry, float flatteningTolerance, float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometryRealization>))] out ID2D1GeometryRealization geometryRealization);

    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-drawgeometryrealization
    [PreserveSig]
    void DrawGeometryRealization([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometryRealization>))] ID2D1GeometryRealization geometryRealization, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Brush>))] ID2D1Brush brush);
}
