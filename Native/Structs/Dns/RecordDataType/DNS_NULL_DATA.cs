using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682074(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_NULL_DATA
    {
        public uint dwByteCount;
        public IntPtr Data;           // BYTE  Data[1];
    }
}
