using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct CIEXYZ
{
    public int ciexyzX;
    public int ciexyzY;
    public int ciexyzZ;
}
