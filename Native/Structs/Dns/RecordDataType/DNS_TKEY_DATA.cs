using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682104(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_TKEY_DATA
    {
        public char*  pNameAlgorithm;
        public IntPtr pAlgorithmPacket; // PBYTE (which is BYTE*)
        public IntPtr pKey;             // PBYTE (which is BYTE*)
        public IntPtr pOtherData;       // PBYTE (which is BYTE*)
        public uint   dwCreateTime;
        public uint   dwExpireTime;
        public ushort wMode;
        public ushort wError;
        public ushort wKeyLength;
        public ushort wOtherLength;
        public byte   cAlgNameLength;   // UCHAR cAlgNameLength;
        public int    bPacketPointers;  // BOOL  bPacketPointers;

        public ReadOnlySpan<char> GetNameAlgorithm() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameAlgorithm);

        public override string ToString() => $"NameAlgorithm: {GetNameAlgorithm()}";
    }
}
