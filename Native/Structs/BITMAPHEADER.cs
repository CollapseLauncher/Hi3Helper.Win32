using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable GrammarMistakeInComment

namespace Hi3Helper.Win32.Native.Structs;
#pragma warning disable CS9080 // Use of variable in this context may expose referenced variables outside of their declaration scope

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct BITMAPHEADER
{
    private const ushort TypeSig = (ushort)19778u; // BM

    public        BITMAPFILEHEADER File;
    private fixed byte             _dibHeaderData[124]; // Max: BITMAPV5HEADER

    public void Init()
    {
        var thisSpan = new Span<BITMAPHEADER>(ref this);
        thisSpan.Clear();
        ref BITMAPV5HEADER v5Header = ref MemoryMarshal.AsRef<BITMAPV5HEADER>(DibHeaderData);

        v5Header.V5Size      = (uint)sizeof(BITMAPV5HEADER);
        File.PixelDataOffset = v5Header.V5Size;

        MemoryMarshal.AsRef<ushort>(MemoryMarshal.AsBytes(thisSpan)) = TypeSig;
    }

    public int DibHeaderSize
    {
        get
        {
            ref BITMAPV5HEADER v5Header = ref MemoryMarshal.AsRef<BITMAPV5HEADER>(DibHeaderData);
            if (Unsafe.IsNullRef(ref v5Header))
                return 0;

            return (int)v5Header.V5Size;
        }
    }

    public bool IsNull => Unsafe.AsPointer(ref this) == null;

    public bool IsValid
    {
        get
        {
            int structSize = DibHeaderSize;
            return !IsNull &&
                   MemoryMarshal.Read<ushort>(File.Type) == TypeSig &&
                   (sizeof(BITMAPV1HEADER) >= structSize ||
                    sizeof(BITMAPV4HEADER) >= structSize ||
                    sizeof(BITMAPV5HEADER) >= structSize);
        }
    }

    public Span<byte> DibHeaderData
    {
        get
        {
            fixed (byte* headerP = _dibHeaderData)
            {
                return new Span<byte>(headerP, 124);
            }
        }
    }

    public ref T TryReadAs<T>() where T : unmanaged
        => ref IsValid
            ? ref MemoryMarshal.AsRef<T>(DibHeaderData)
            : ref Unsafe.NullRef<T>();

    public Span<byte> AsBytesSpan(out int headerSize)
    {
        Unsafe.SkipInit(out headerSize);

        if (!IsValid)
            return Span<byte>.Empty;

        Span<byte> asBytes   = MemoryMarshal.AsBytes(new Span<BITMAPHEADER>(ref this));
        int        sizeOfSig = sizeof(BITMAPFILEHEADER);
        int sizeOfDib = MemoryMarshal.Read<ushort>(File.Type);

        headerSize = sizeOfSig + sizeOfDib;
        return asBytes[..headerSize];
    }
}