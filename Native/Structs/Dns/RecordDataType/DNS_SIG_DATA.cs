using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682094(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_SIG_DATA
    {
        public IntPtr pNameSigner;      // string
        public ushort wTypeCovered;
        public byte chAlgorithm;
        public byte chLabelCount;
        public uint dwOriginalTtl;
        public uint dwExpiration;
        public uint dwTimeSigned;
        public ushort wKeyTag;
        public ushort Pad;
        public IntPtr Signature;      // BYTE  Signature[1];
    }
}
