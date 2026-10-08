using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.TaskbarListCOM;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.ITaskbarList3)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface ITaskbarList3 : ITaskbarList2
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetProgressValue(nint windowHandle, ulong ullCompleted, ulong ullTotal);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetProgressState(nint windowHandle, TaskbarState state);
}
