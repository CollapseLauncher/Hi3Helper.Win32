using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BITMAPV4HEADER
{
    public uint         V4Size;
    public int          V4Width;
    public int          V4Height;
    public ushort       V4Planes;
    public ushort       V4BitCount;
    public uint         V4Compression;
    public uint         V4SizeImage;
    public int          V4XPelsPerMeter;
    public int          V4YPelsPerMeter;
    public uint         V4ClrUsed;
    public uint         V4ClrImportant;
    public uint         V4RedMask;
    public uint         V4GreenMask;
    public uint         V4BlueMask;
    public uint         V4AlphaMask;
    public uint         V4CSType;
    public CIEXYZTRIPLE V4Endpoints;
    public uint         V4GammaRed;
    public uint         V4GammaGreen;
    public uint         V4GammaBlue;
}
