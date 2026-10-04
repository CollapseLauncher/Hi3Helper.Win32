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
    int BeginDraw(nint updateRect, in Guid iid, out nint updateObject, out POINTL updateOffset);

    [PreserveSig]
    int EndDraw();

    [PreserveSig]
    int Resize(SIZEL sizePixels);

    [PreserveSig]
    int Scroll(nint scrollRect, nint clipRect, int offsetX, int offsetY);

    [PreserveSig]
    int ResumeDraw();

    [PreserveSig]
    int SuspendDraw();
}