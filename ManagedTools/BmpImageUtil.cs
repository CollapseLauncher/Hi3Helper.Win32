using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ManagedTools;

public static class BmpImageUtil
{
    [SkipLocalsInit]
    public static ref BITMAPHEADER TryGetHeader(Span<byte> span)
    {
        if (span.Length < sizeof(BITMAPHEADER))
            return ref Unsafe.NullRef<BITMAPHEADER>();

        ref BITMAPHEADER bitmapHeader = ref MemoryMarshal.AsRef<BITMAPHEADER>(span);
        if (!bitmapHeader.IsValid)
            return ref Unsafe.NullRef<BITMAPHEADER>();

        return ref bitmapHeader;
    }
}
