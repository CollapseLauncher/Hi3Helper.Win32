using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEOPSTRUCTW
    {
        public nint          hwnd;
        public FileFuncFlags wFunc;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string        pFrom;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string        pTo;
        public FILEOP_FLAGS  fFlags;
        public int           fAnyOperationsAborted;
        public nint          hNameMappings;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string        lpszProgressTitle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEOPSTRUCTW_UNSAFE
    {
        public nint          hwnd;
        public FileFuncFlags wFunc;
        public nint          pFrom;
        public nint          pTo;
        public FILEOP_FLAGS  fFlags;
        public int           fAnyOperationsAborted;
        public nint          hNameMappings;
        public nint          lpszProgressTitle;
    }
}