// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct BITMAPFILEHEADER
{
    private fixed byte  _type[2];
    public        uint  Size;
    public        short Reserved1;
    public        short Reserved2;
    public        uint  PixelDataOffset;

    public Span<byte> Type
    {
        get
        {
            fixed (byte* typeP = _type)
            {
                return new Span<byte>(typeP, 2);
            }
        }
    }
}
