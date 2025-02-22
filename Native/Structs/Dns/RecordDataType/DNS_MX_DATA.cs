using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682070(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_MX_DATA
    {
        public IntPtr pNameExchange;        // string
        public ushort wPreference;
        public ushort Pad;
    }
}
