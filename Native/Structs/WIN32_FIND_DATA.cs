using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct WIN32_FIND_DATA
    {
        public       uint     dwFileAttributes;
        public       FILETIME ftCreationTime;
        public       FILETIME ftLastAccessTime;
        public       FILETIME ftLastWriteTime;
        public       uint     nFileSizeHigh;
        public       uint     nFileSizeLow;
        public       uint     dwReserved0;
        public       uint     dwReserved1;
        public fixed char     cFileName[260];
        public fixed char     cAlternateFileName[14];
        public       uint     dwFileType;
        public       uint     dwCreatorType;
        public       ushort   wFinderFlags;

        public Span<char> FileNameBuffer
            => new((char*)Unsafe.AsPointer(ref cFileName[0]), 260);

        public ReadOnlySpan<char> FileName =>
            MemoryMarshal.CreateReadOnlySpanFromNullTerminated((char*)Unsafe.AsPointer(ref cFileName[0]));

        public Span<char> AlternateFileNameBuffer
            => new((char*)Unsafe.AsPointer(ref cAlternateFileName[0]), 14);

        public ReadOnlySpan<char> AlternativeFileName =>
            MemoryMarshal.CreateReadOnlySpanFromNullTerminated((char*)Unsafe.AsPointer(ref cAlternateFileName[0]));

        public long FileSize
        {
            get
            {
                ulong size = nFileSizeLow | ((ulong)nFileSizeHigh << 32);
                return (long)size;
            }
            set
            {
                nFileSizeLow = (uint)(value & 0xFFFFFFFF);
                nFileSizeHigh = (uint)((value >> 32) & 0xFFFFFFFF);
            }
        }

        public override string ToString()
            => FileName.ToString();
    }
}
