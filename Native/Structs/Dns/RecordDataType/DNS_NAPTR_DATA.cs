using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/cc982164(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_NAPTR_DATA
    {
        public ushort wOrder;
        public ushort wPreference;
        public IntPtr pFlags;       // string
        public IntPtr pService;     // string
        public IntPtr pRegularExpression;       // string
        public IntPtr pReplacement;     // string
    }
}
