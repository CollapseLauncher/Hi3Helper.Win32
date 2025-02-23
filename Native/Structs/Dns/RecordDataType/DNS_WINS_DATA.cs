using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682114(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_WINS_DATA
    {
        public uint dwMappingFlag;
        public uint dwLookupTimeout;
        public uint dwCacheTimeout;
        public uint cWinsServerCount;
        public uint WinsServers;    // IP4_ADDRESS WinsServers[1];
    }
}
