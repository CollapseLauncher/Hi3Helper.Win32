using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Interfaces.DXGI;

namespace Hi3Helper.Win32.Native.Interfaces.CompositorInterop;

[GeneratedComInterface]
[Guid("FC084699-67D8-40E1-ADE7-08901D84FFDA")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ICompositorSwapChainInterop : ICompositorInterop
{
    void CreateCompositionSurfaceForHandle(
        nint     swapChainHandle,
        out nint compositionSurfaceResult);

    void CreateCompositionSurfaceForSwapChain(
        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGISwapChain>))] IDXGISwapChain swapChain,
        out                                                                  nint           compositionSurfaceResult);
}