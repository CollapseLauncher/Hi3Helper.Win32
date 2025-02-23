using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682106(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_TSIG_DATA
    {
        public char* pNameAlgorithm;
        public IntPtr pAlgorithmPacket; // PBYTE (which is BYTE*)
        public IntPtr pSignature;       // PBYTE (which is BYTE*)
        public IntPtr pOtherData;       // PBYTE (which is BYTE*)
        public long i64CreateTime;
        public ushort wFudgeTime;
        public ushort wOriginalXid;
        public ushort wError;
        public ushort wSigLength;
        public ushort wOtherLength;
        public byte cAlgNameLength;     // UCHAR    cAlgNameLength;
        public int bPacketPointers;     // BOOL     bPacketPointers;

        public ReadOnlySpan<char> GetNameAlgorithm() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameAlgorithm);

        public override string ToString() => $"NameAlgorithm: {GetNameAlgorithm()}";
    }
}
