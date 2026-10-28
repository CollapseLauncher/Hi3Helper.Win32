using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BITMAPV5HEADER
{
    public uint         V5Size;
    public int          V5Width;
    public int          V5Height;
    public ushort       V5Planes;
    public ushort       V5BitCount;
    public uint         V5Compression;
    public uint         V5SizeImage;
    public int          V5XPelsPerMeter;
    public int          V5YPelsPerMeter;
    public uint         V5ClrUsed;
    public uint         V5ClrImportant;
    public uint         V5RedMask;
    public uint         V5GreenMask;
    public uint         V5BlueMask;
    public uint         V5AlphaMask;
    public uint         V5CSType;
    public CIEXYZTRIPLE V5Endpoints;
    public uint         V5GammaRed;
    public uint         V5GammaGreen;
    public uint         V5GammaBlue;
    public uint         V5Intent;
    public uint         V5ProfileData;
    public uint         V5ProfileSize;
    public uint         V5Reserved;
}
