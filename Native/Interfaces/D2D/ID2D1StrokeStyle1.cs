using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("10a72a66-e91c-43f4-993f-ddf4b82b0b4a")]
public partial interface ID2D1StrokeStyle1 : ID2D1StrokeStyle
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1strokestyle1-getstroketransformtype
    [PreserveSig]
    D2D1_STROKE_TRANSFORM_TYPE GetStrokeTransformType();
}