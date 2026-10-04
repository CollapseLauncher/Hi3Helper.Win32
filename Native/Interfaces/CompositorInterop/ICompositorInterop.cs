using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.CompositorInterop;

[GeneratedComInterface]
[Guid("FAB19398-6D19-4D8A-B752-8F096C396069")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ICompositorInterop
{
    [PreserveSig]
    int CreateGraphicsDevice(
        nint     renderingDevice,
        out nint compositionGraphicsDeviceResult);
}