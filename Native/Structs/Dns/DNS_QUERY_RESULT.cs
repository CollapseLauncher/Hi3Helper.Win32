using Hi3Helper.Win32.Native.Enums.Dns;
using System.Runtime.InteropServices;
// ReSharper disable NotAccessedField.Global
// ReSharper disable UnassignedField.Global

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

        public static DNS_QUERY_RESULT* Create()
        {
            DNS_QUERY_RESULT* ptr = (DNS_QUERY_RESULT*)NativeMemory.AllocZeroed((nuint)sizeof(DNS_QUERY_RESULT));
            ptr->Version = 1;
            return ptr;
        }

        public nint GetRecordPtr() => (nint)pQueryRecords;
    }
}
