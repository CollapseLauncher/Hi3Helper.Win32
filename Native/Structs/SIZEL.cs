using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct SIZEL
{
    public int Width;
    public int Height;
}
