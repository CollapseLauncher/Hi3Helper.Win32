using Hi3Helper.Win32.Native.Enums.Dns;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    public unsafe struct DNS_QUERY_RESULT
    {
        public uint        Version;
        public DnsStatus   QueryStatus;
        public ulong       QueryOptions;
        public DNS_RECORD* pQueryRecords;
        public void*       Reserved;

        public static DNS_QUERY_RESULT Create()
            => new()
            {
                Version = 1
            };

        public nint GetRecordPtr() => (nint)pQueryRecords;
    }
}
