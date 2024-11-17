using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEOPSTRUCTW
    {
        public nint hwnd;
        public uint wFunc;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pFrom;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pTo;
        public ushort fFlags;
        public int fAnyOperationsAborted;
        public nint hNameMappings;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszProgressTitle;
    }
}
