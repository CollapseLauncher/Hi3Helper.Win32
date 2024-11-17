using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    // 8-bytes structure
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL
    {
        public int x;
        public int y;
    }
}
