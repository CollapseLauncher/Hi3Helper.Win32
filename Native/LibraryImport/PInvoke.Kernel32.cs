﻿using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public delegate bool ConsoleControlHandler(uint handle);
    public static partial class PInvoke
    {
        [LibraryImport("kernel32.dll", EntryPoint = "GetConsoleMode", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool GetConsoleMode(nint hConsoleHandle, out uint lpMode);

        [LibraryImport("kernel32.dll", EntryPoint = "SetConsoleMode", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetConsoleMode(nint hConsoleHandle, uint dwMode);

        [LibraryImport("kernel32.dll", EntryPoint = "GetConsoleWindow")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GetConsoleWindow();

        [LibraryImport("kernel32.dll", EntryPoint = "SetStdHandle", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetStdHandle(int nStdHandle, nint hHandle);

        [LibraryImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool AllocConsole();

        [LibraryImport("kernel32.dll", EntryPoint = "CreateFileW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);

        [LibraryImport("kernel32.dll", EntryPoint = "GlobalAlloc", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GlobalAlloc(GLOBAL_ALLOC_FLAGS uFlags, nuint uBytes);

        [LibraryImport("kernel32.dll", EntryPoint = "GlobalFree", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GlobalFree(nint hMem);

        [LibraryImport("kernel32.dll", EntryPoint = "GlobalLock", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint GlobalLock(nint hMem);

        [LibraryImport("kernel32.dll", EntryPoint = "GlobalUnlock", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool GlobalUnlock(nint hMem);

        [LibraryImport("kernel32.dll", EntryPoint = "SetConsoleCtrlHandler", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetConsoleCtrlHandler(ConsoleControlHandler handlerRoutine, [MarshalAs(UnmanagedType.Bool)] bool add);

        [LibraryImport("kernel32.dll", EntryPoint = "SetThreadExecutionState")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [LibraryImport("Kernel32.dll", EntryPoint = "CreateHardLinkW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            nint lpSecurityAttributes
        );

        public const uint FORMAT_MESSAGE_FROM_HMODULE = 0x800;

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x200;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
        public const uint FORMAT_MESSAGE_FLAGS = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_IGNORE_INSERTS | FORMAT_MESSAGE_FROM_SYSTEM;

        [LibraryImport("kernel32.dll", EntryPoint = "FormatMessageW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int FormatMessage(
            FORMAT_MESSAGE dwFlags,
            nint lpSource,
            int dwMessageId,
            int dwLanguageId,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpBuffer,
            uint nSize,
            nint argumentsLong);
        
        [LibraryImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
        public static partial nint CreateFile(
            string lpFileName,
            uint   dwDesiredAccess,
            uint   dwShareMode,
            nint lpSecurityAttributes,
            uint   dwCreationDisposition,
            uint   dwFlagsAndAttributes,
            nint hTemplateFile);

        [LibraryImport("kernel32.dll", EntryPoint = "DeviceIoControl", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DeviceIoControl(
            nint   hDevice,
            uint     dwIoControlCode,
            nint   lpInBuffer,
            uint     nInBufferSize,
            nint   lpOutBuffer,
            uint     nOutBufferSize,
            out uint lpBytesReturned,
            nint   lpOverlapped);

        [LibraryImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool CloseHandle(nint hObject);
    }
}
