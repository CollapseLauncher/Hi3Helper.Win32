using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/dd392296(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_DS_DATA
    {
        public ushort wKeyTag;
        public byte chAlgorithm;
        public byte chDigestType;
        public ushort wDigestLength;
        public ushort wPad;
        public IntPtr Digest;         // BYTE Digest[1];
    }
}
