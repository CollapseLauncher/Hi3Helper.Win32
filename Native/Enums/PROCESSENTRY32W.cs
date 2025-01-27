using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Enums
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PROCESSENTRY32W
    {
        public uint dwSize;
        public uint cntUsage;
        public uint th32ProcessID;
        public nint th32DefaultHeapID;
        public uint th32ModuleID;
        public uint cntThreads;
        public uint th32ParentProcessID;
        public int  pcPriClassBase;
        public uint dwFlags;
        public fixed char szExeFile[260];
    }
}
