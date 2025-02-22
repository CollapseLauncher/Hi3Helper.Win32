using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682096(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_SOA_DATA
    {
        public IntPtr pNamePrimaryServer;       // string
        public IntPtr pNameAdministrator;       // string
        public uint dwSerialNo;
        public uint dwRefresh;
        public uint dwRetry;
        public uint dwExpire;
        public uint dwDefaultTtl;
    }
}
