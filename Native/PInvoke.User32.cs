using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public delegate bool EnumWindowsProc(nint hWnd, nint lParam);

    public static partial class PInvoke
    {
        [LibraryImport("user32.dll", EntryPoint = "ShowWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShowWindow(nint hWnd, int nCmdShow);

        [LibraryImport("user32.dll", EntryPoint = "GetSystemMetrics", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int GetSystemMetrics(SystemMetric nIndex);

        [LibraryImport("user32.dll", EntryPoint = "ShowWindowAsync")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ShowWindowAsync(nint hWnd, HandleEnum nCmdShow);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetWindowPos(nint hWnd, nint hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [LibraryImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SendMessage(nint hWnd, uint msg, nuint wParam, nint lParam);

        [LibraryImport("user32.dll", EntryPoint = "OpenClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool OpenClipboard(nint hWndNewOwner);

        [LibraryImport("user32.dll", EntryPoint = "CloseClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool CloseClipboard();

        [LibraryImport("user32.dll", EntryPoint = "SetClipboardData", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SetClipboardData(uint uFormat, nint data);

        [LibraryImport("user32.dll", EntryPoint = "EmptyClipboard", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EmptyClipboard();

        [LibraryImport("user32.dll", EntryPoint = "IsWindowVisible")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool IsWindowVisible(nint hWnd);

        [LibraryImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetForegroundWindow(nint hWnd);

        [LibraryImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GetForegroundWindow();

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong);

        [LibraryImport("user32.dll", EntryPoint = "FindWindowExW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint FindWindowEx(nint hwndParent, nint hwndChildAfter, string lpszClass, string lpszWindow);

        [LibraryImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DestroyWindow(nint hwnd);

        [LibraryImport("user32.dll", EntryPoint = "CallWindowProcW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint CallWindowProc(nint lpPrevWndFunc, nint hWnd, uint Msg, nuint wParam, nint lParam);

        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;

        [LibraryImport("user32.dll", EntryPoint = "EnumDisplaySettingsW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EnumDisplaySettings(
            [MarshalAs(UnmanagedType.LPTStr)]
            string? lpszDeviceName,  // display device
            int iModeNum,         // graphics mode
            nint lpDevMode       // graphics mode settings
            );

        [LibraryImport("user32.dll", EntryPoint = "ChangeDisplaySettingsW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int ChangeDisplaySettings(
            nint lpDevMode,       // graphics mode settings
            uint dwflags);

        [LibraryImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DestroyIcon(nint hIcon);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowLongW", SetLastError = true)]
        public static partial WS_STYLE GetWindowLong(nint hWnd, GWL_INDEX nIndex);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongW", SetLastError = true)]
        public static partial int SetWindowLong(nint hWnd, GWL_INDEX nIndex, WS_STYLE dwNewLong);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowRect", SetLastError = true)]
        [return : MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool GetWindowRect(nint hwnd, WindowRect* rectangle);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetWindowPos(nint hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, SWP_FLAGS wFlags);
        
        [LibraryImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool EnumWindows(EnumWindowsProc lpEnumFunc, nint lParam);
        
        [LibraryImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        public static unsafe partial uint GetWindowThreadProcessId(nint hWnd, int* lpdwProcessId);

        [LibraryImport("user32.dll", EntryPoint = "GetWindow", SetLastError = true)]
        public static partial nint GetWindow(nint hWnd, GetWindowType uCmd);

        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int MessageBox(nint hWnd, string lpText, string lpCaption, uint uType);
    }
}
