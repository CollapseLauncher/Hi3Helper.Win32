﻿using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BIND_OPTS3
    {
        public uint cbStruct;            // DWORD
        public uint grfFlags;            // DWORD
        public uint grfMode;             // DWORD
        public uint dwTickCountDeadline; // DWORD
        public uint dwTrackFlags;        // DWORD
        public CLSCTX dwClassContext;    // DWORD
        public uint locale;              // LCID (equivalent to uint in .NET)
        public nint pServerInfo;         // COSERVERINFO*, use IntPtr for pointer to unmanaged struct
        public nint hwnd;                // HWND, use IntPtr to represent window handles
    }
}
