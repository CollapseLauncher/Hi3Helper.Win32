using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

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
        void AddTab(nint hwnd);
        [PreserveSig]
        void DeleteTab(nint hwnd);
        [PreserveSig]
        void ActivateTab(nint hwnd);
        [PreserveSig]
        void SetActiveAlt(nint hwnd);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(nint hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3
        [PreserveSig]
        int SetProgressValue(nint hwnd, ulong ullCompleted, ulong ullTotal);
        [PreserveSig]
        int SetProgressState(nint hwnd, TaskbarState state);
    }
}
