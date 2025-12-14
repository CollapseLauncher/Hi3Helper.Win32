using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2cd906c1-12e2-11dc-9fed-001143a055f9")]
public partial interface ID2D1TessellationSink
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1tessellationsink-addtriangles
    [PreserveSig]
    void AddTriangles([In][MarshalUsing(CountElementName = nameof(trianglesCount))] D2D1_TRIANGLE[] triangles, uint trianglesCount);

    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1tessellationsink-close
    void Close();
}
