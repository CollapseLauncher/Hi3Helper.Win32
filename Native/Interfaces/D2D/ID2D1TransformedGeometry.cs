using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs.D2D;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2cd906bb-12e2-11dc-9fed-001143a055f9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ID2D1TransformedGeometry : ID2D1Geometry
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1transformedgeometry-getsourcegeometry
    [PreserveSig]
    void GetSourceGeometry([MarshalUsing(typeof(ComInterfaceMarshaller<ID2D1Geometry>))] out ID2D1Geometry sourceGeometry);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1transformedgeometry-gettransform
    [PreserveSig]
    void GetTransform(out D2D_MATRIX_3X2_F transform);
}
