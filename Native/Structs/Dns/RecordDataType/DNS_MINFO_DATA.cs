using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682067(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_MINFO_DATA
    {
        public IntPtr pNameMailbox;     // string
        public IntPtr pNameErrorsMailbox;       // string
    }
}
