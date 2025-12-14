using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2cd906a3-12e2-11dc-9fed-001143a055f9")]
public partial interface ID2D1RoundedRectangleGeometry : ID2D1Geometry
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1roundedrectanglegeometry-getroundedrect
    [PreserveSig]
    void GetRoundedRect(out D2D1_ROUNDED_RECT roundedRect);
}
