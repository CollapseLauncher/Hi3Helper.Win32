using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global
#pragma warning disable CA1401

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public delegate bool EnumWindowsProc(nint windowHandle, nint lParam);

    public static partial class PInvoke
    {
        [LibraryImport("user32.dll", EntryPoint = "ShowWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShowWindow(nint windowHandle, int nCmdShow);

        [LibraryImport("user32.dll", EntryPoint = "GetSystemMetrics", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int GetSystemMetrics(SystemMetric nIndex);

        [LibraryImport("user32.dll", EntryPoint = "ShowWindowAsync")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShowWindowAsync(nint windowHandle, HandleEnum nCmdShow);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetWindowPos(nint windowHandle, nint windowHandleInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

        [LibraryImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SendMessage(nint windowHandle, uint msg, nuint wParam, nint lParam);

        [LibraryImport("user32.dll", EntryPoint = "OpenClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool OpenClipboard(nint windowHandleNewOwner);

        [LibraryImport("user32.dll", EntryPoint = "CloseClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool CloseClipboard();

        [LibraryImport("user32.dll", EntryPoint = "SetClipboardData", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SetClipboardData(StandardClipboardFormats uFormat, nint data);

        [LibraryImport("user32.dll", EntryPoint = "EmptyClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EmptyClipboard();

        [LibraryImport("user32.dll", EntryPoint = "IsWindowVisible")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool IsWindowVisible(nint windowHandle);

        [LibraryImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetForegroundWindow(nint windowHandle);

        [LibraryImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GetForegroundWindow();

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SetWindowLongPtr(nint windowHandle, int nIndex, nint dwNewLong);

        [LibraryImport("user32.dll", EntryPoint = "FindWindowExW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint FindWindowEx(nint windowHandleParent, nint windowHandleChildAfter, string lpszClass, string lpszWindow);

        [LibraryImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DestroyWindow(nint windowHandle);

        [LibraryImport("user32.dll", EntryPoint = "CallWindowProcW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint CallWindowProc(nint lpPrevWndFunc, nint windowHandle, uint msg, nuint wParam, nint lParam);

        [LibraryImport("user32.dll", EntryPoint = "EnumDisplaySettingsW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EnumDisplaySettings(
            [MarshalAs(UnmanagedType.LPTStr)] string? lpszDeviceName, // display device
            int                                       iModeNum,       // graphics mode
            nint                                      lpDevMode       // graphics mode settings
            );

        [LibraryImport("user32.dll", EntryPoint = "ChangeDisplaySettingsW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int ChangeDisplaySettings(
            nint lpDevMode, // graphics mode settings
            uint dwflags);

        [LibraryImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DestroyIcon(nint hIcon);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowLongW", SetLastError = true)]
        public static partial WS_STYLE GetWindowLong(nint windowHandle, GWL_INDEX nIndex);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongW", SetLastError = true)]
        public static partial int SetWindowLong(nint windowHandle, GWL_INDEX nIndex, WS_STYLE dwNewLong);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowRect", SetLastError = true)]
        [return : MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool GetWindowRect(nint windowHandle, WindowRect* rectangle);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetWindowPos(nint windowHandle, int windowHandleInsertAfter, int x, int y, int cx, int cy, SWP_FLAGS wFlags);
        
        [LibraryImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EnumWindows(EnumWindowsProc lpEnumFunc, nint lParam);
        
        [LibraryImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        public static unsafe partial uint GetWindowThreadProcessId(nint windowHandle, int* lpdwProcessId);

        [LibraryImport("user32.dll", EntryPoint = "GetWindow", SetLastError = true)]
        public static partial nint GetWindow(nint windowHandle, GetWindowType uCmd);

        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial MessageBoxResult MessageBox(nint windowHandle, string lpContent, string? lpTitle, MessageBoxFlags uType);
        
        [LibraryImport("user32.dll", EntryPoint = "ShutdownBlockReasonCreate", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShutdownBlockReasonCreate(nint windowHandle, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);
        
        [LibraryImport("user32.dll", EntryPoint = "ShutdownBlockReasonDestroy", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShutdownBlockReasonDestroy(nint windowHandle);
    }
}
