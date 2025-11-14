using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFOEX
    {
        public STARTUPINFOW StartupInfo;
        public nint lpAttributeList;
    }
}
