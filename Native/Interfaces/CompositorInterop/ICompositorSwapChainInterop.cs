using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.CompositorInterop;

[GeneratedComInterface]
[Guid("FC084699-67D8-40E1-ADE7-08901D84FFDA")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ICompositorSwapChainInterop : ICompositorInterop
{
    [PreserveSig]
    int CreateCompositionSurfaceForHandle(
        nint     swapChainHandle,
        out nint compositionSurfaceResult);

    [PreserveSig]
    int CreateCompositionSurfaceForSwapChain(
        nint     swapChain,
        out nint compositionSurfaceResult);
}