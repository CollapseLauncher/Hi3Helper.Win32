using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2cd906a5-12e2-11dc-9fed-001143a055f9")]
public partial interface ID2D1PathGeometry : ID2D1Geometry
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-open
    void Open([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometrySink>))] out ID2D1GeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-stream
    void Stream([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GeometrySink>))] ID2D1GeometrySink geometrySink);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-getsegmentcount
    void GetSegmentCount(out uint count);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-getfigurecount
    void GetFigureCount(out uint count);
}
