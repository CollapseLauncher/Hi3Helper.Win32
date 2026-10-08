using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.TaskbarListCOM;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.ITaskbarList)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface ITaskbarList
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult HrInit();

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult AddTab(nint windowHandle);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult DeleteTab(nint windowHandle);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ActivateTab(nint windowHandle);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetActiveAlt(nint windowHandle);
}