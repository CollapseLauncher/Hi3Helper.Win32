using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.TaskbarListCOM;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.ITaskbarList2)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface ITaskbarList2 : ITaskbarList
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult MarkFullscreenWindow(
        nint                                 windowHandle,
        [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
}