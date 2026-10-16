using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface]
[Guid("00000120-A8F2-4877-BA0A-FD2B6645FB94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public unsafe partial interface IWICBitmapSource
{
    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetSize(out uint width, out uint height);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetPixelFormat(out Guid format);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetResolution(out double x, out double y);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult CopyPalette(nint palette);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult CopyPixels(WICRect* rectangle, uint stride, uint bufferSize, byte* buffer);
}
