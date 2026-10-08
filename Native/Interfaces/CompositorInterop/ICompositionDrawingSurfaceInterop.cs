using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.Interfaces.CompositorInterop;

[GeneratedComInterface]
[Guid("2D6355C2-AD57-4EAE-92E4-4C3EFF65D578")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ICompositionDrawingSurfaceInterop
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult BeginDraw(nint updateRect, in Guid iid, out nint updateObject, out POINTL updateOffset);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult EndDraw();

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Resize(SIZEL sizePixels);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Scroll(nint scrollRect, nint clipRect, int offsetX, int offsetY);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ResumeDraw();

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SuspendDraw();
}