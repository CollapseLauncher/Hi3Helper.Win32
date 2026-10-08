using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("41343a53-e41a-49a2-91cd-21793bbb62e5")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ID2D1BitmapBrush1 : ID2D1BitmapBrush
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmapbrush1-setinterpolationmode1
    [PreserveSig]
    void SetInterpolationMode1(D2D1_INTERPOLATION_MODE interpolationMode);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmapbrush1-getinterpolationmode1
    [PreserveSig]
    D2D1_INTERPOLATION_MODE GetInterpolationMode1();
}