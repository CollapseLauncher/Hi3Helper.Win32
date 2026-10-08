using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.TaskbarListCOM;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Interfaces;

public partial interface ITaskbarList3 : ITaskbarList2
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetProgressValue(nint windowHandle, ulong ullCompleted, ulong ullTotal);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetProgressState(nint windowHandle, TaskbarState state);
}
