using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682106(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_TSIG_DATA
    {
        public IntPtr pNameAlgorithm;   // string
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
    }
}
