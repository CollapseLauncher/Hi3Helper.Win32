using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("bae8b344-23fc-4071-8cb5-d05d6f073848")]
public partial interface ID2D1InkStyle : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-setnibtransform(constd2d1_matrix_3x2_f_)
    [PreserveSig]
    void SetNibTransform(in D2D_MATRIX_3X2_F transform);

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-getnibtransform
    [PreserveSig]
    void GetNibTransform(out D2D_MATRIX_3X2_F transform);

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-setnibshape
    [PreserveSig]
    void SetNibShape(D2D1_INK_NIB_SHAPE nibShape);

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-getnibshape
    [PreserveSig]
    D2D1_INK_NIB_SHAPE GetNibShape();
}