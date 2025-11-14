using System.Runtime.InteropServices;
// ReSharper disable UnusedType.Global

namespace Hi3Helper.Win32.ShellLinkCOM
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0)]
    public struct FileTime
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
}
