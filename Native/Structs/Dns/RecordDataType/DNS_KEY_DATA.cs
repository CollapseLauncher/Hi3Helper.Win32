using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682061(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_KEY_DATA
    {
        public ushort wFlags;
        public byte   chProtocol;
        public byte   chAlgorithm;
        public IntPtr Key; // BYTE Key[1];
    }
}
