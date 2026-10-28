using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BITMAPV1HEADER
{
    public uint   V1Size;
    public int    V1Width;
    public int    V1Height;
    public ushort V1Planes;
    public ushort V1BitCount;
    public uint   V1Compression;
    public uint   V1SizeImage;
    public int    V1XPelsPerMeter;
    public int    V1YPelsPerMeter;
    public uint   V1ClrUsed;
    public uint   V1ClrImportant;
}