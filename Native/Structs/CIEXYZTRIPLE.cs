using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct CIEXYZTRIPLE
{
    public CIEXYZ ciexyzRed;
    public CIEXYZ ciexyzGreen;
    public CIEXYZ ciexyzBlue;
}
