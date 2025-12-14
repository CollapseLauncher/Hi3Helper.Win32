using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2f543dc3-cfc1-4211-864f-cfd91c6f3395")]
public partial interface ID2D1GdiMetafile : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-stream
    void Stream([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GdiMetafileSink>))] ID2D1GdiMetafileSink sink);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-getbounds
    void GetBounds(out D2D_RECT_F bounds);
}