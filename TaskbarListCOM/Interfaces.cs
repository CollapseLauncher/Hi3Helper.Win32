using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.TaskbarListCOM
{
    [Guid(IIDGuid.ITaskbarList3)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper)]
    internal partial interface ITaskbarList3
    {
        // ITaskbarList
        [PreserveSig]
        void HrInit();
        [PreserveSig]
        void AddTab(nint windowHandle);
        [PreserveSig]
        void DeleteTab(nint windowHandle);
        [PreserveSig]
        void ActivateTab(nint windowHandle);
        [PreserveSig]
        void SetActiveAlt(nint windowHandle);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(nint windowHandle, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3
        [PreserveSig]
        int SetProgressValue(nint windowHandle, ulong ullCompleted, ulong ullTotal);
        [PreserveSig]
        int SetProgressState(nint windowHandle, TaskbarState state);
    }
}
