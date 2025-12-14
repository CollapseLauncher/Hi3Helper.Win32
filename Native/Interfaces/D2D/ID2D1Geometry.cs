using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2cd906a1-12e2-11dc-9fed-001143a055f9")]
public partial interface ID2D1Geometry : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-getbounds
    void GetBounds(nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, out D2D_RECT_F bounds);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-getwidenedbounds
    void GetWidenedBounds(float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, out D2D_RECT_F bounds);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-strokecontainspoint
    void StrokeContainsPoint(D2D_POINT_2F point, float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, out BOOL contains);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-fillcontainspoint
    void FillContainsPoint(D2D_POINT_2F point, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, out BOOL contains);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-comparewithgeometry
    void CompareWithGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry inputGeometry, nint /* optional D2D_MATRIX_3X2_F* */ inputGeometryTransform, float flatteningTolerance, out D2D1_GEOMETRY_RELATION relation);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-simplify
    void Simplify(D2D1_GEOMETRY_SIMPLIFICATION_OPTION simplificationOption, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1SimplifiedGeometrySink>))] ID2D1SimplifiedGeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-tessellate
    void Tessellate(nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1TessellationSink>))] ID2D1TessellationSink tessellationSink);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-combinewithgeometry
    void CombineWithGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Geometry>))] ID2D1Geometry inputGeometry, D2D1_COMBINE_MODE combineMode, nint /* optional D2D_MATRIX_3X2_F* */ inputGeometryTransform, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1SimplifiedGeometrySink>))] ID2D1SimplifiedGeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-outline
    void Outline(nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1SimplifiedGeometrySink>))] ID2D1SimplifiedGeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-computearea
    void ComputeArea(nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, out float area);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-computelength
    void ComputeLength(nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, out float length);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-computepointatlength
    void ComputePointAtLength(float length, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, nint /* optional D2D_POINT_2F* */ point, nint /* optional D2D_POINT_2F* */ unitTangentVector);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1geometry-widen
    void Widen(float strokeWidth, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle?>))] ID2D1StrokeStyle? strokeStyle, nint /* optional D2D_MATRIX_3X2_F* */ worldTransform, float flatteningTolerance, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1SimplifiedGeometrySink>))] ID2D1SimplifiedGeometrySink geometrySink);
}