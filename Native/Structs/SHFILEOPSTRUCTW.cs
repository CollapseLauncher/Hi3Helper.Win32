using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SHFILEOPSTRUCTW
    {
        public nint          windowHandle;
        public FileFuncFlags wFunc;
        public char*         pFrom;
        public char*         pTo;
        public FILEOP_FLAGS  fFlags;
        public int           fAnyOperationsAborted;
        public nint          hNameMappings;
        public char*         lpszProgressTitle;
    }
}