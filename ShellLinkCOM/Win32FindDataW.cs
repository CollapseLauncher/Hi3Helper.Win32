using System.Runtime.InteropServices;
// ReSharper disable CollectionNeverQueried.Global

namespace Hi3Helper.Win32.ShellLinkCOM
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Win32FindDataW
    {
        public uint     dwFileAttributes; // 4
        public FileTime ftCreationTime;   // 12
        public FileTime ftLastAccessTime; // 20
        public FileTime ftLastWriteTime;  // 28
        public uint     nFileSizeHigh;    // 32
        public uint     nFileSizeLow;     // 36
        public uint     dwReserved0;      // 40
        public uint     dwReserved1;      // 44
        
        public fixed char cFileName[520];
        public fixed char cAlternateFileName[28];

        public uint dwFileType;
        public uint dwCreatorType;
        public uint wFinderFlags;
    }
}
