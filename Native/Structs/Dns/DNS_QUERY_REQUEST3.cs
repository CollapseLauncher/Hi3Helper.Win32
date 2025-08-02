using Hi3Helper.Win32.Native.Enums.Dns;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_QUERY_REQUEST3
    {
        public const DnsQueryOptions DefaultQueryOptions = DnsQueryOptions.DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE;
        public delegate void DnsQueryCompletionRoutine(nint pQueryContext, nint pQueryResults);

        public uint           Version;
        public char*          QueryName;
        public DnsRecordTypes QueryType;
        public ulong          QueryOptions;
        public void*          pDnsServerList;
        public uint           InterfaceIndex;
        public void*          pQueryCompletionCallback;
        public void*          pQueryContext;

        /// <summary>
        /// Reserved. If you need to set this field, you must set the Version field to 3.<br/>
        /// Please refer to Microsoft documentation for more information.<br/>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_request3"/>
        /// </summary>
        public int IsNetworkQueryRequired;

        /// <summary>
        /// Reserved. If you need to set this field, you must set the Version field to 3.<br/>
        /// Please refer to Microsoft documentation for more information.<br/>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_request3"/>
        /// </summary>
        public int RequiredNetworkIndex;

        /// <summary>
        /// Reserved. If you need to set this field, you must set the Version field to 3.<br/>
        /// Please refer to Microsoft documentation for more information.<br/>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_request3"/>
        /// </summary>
        public int cCustomServers;

        /// <summary>
        /// Reserved. If you need to set this field, you must set the Version field to 3.<br/>
        /// Please refer to Microsoft documentation for more information.<br/>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_request3"/>
        /// </summary>
        public void* pCustomServers;

        public static DNS_QUERY_REQUEST3* Create(
            string                    hostnameToQuery,
            DnsQueryCompletionRoutine completionCallback,
            DnsRecordTypes            recordType,
            DnsQueryOptions           queryOptions = DefaultQueryOptions)
        {
            fixed (char* hostnameToQueryP = &Utf16StringMarshaller.GetPinnableReference(hostnameToQuery))
            {
                void* completionCallbackP = (void*)Marshal.GetFunctionPointerForDelegate(completionCallback);
                DNS_QUERY_REQUEST3* ptr = (DNS_QUERY_REQUEST3*)NativeMemory.AllocZeroed((nuint)sizeof(DNS_QUERY_REQUEST3));

                ptr->Version                  = 1;
                ptr->QueryName                = hostnameToQueryP;
                ptr->QueryType                = recordType;
                ptr->QueryOptions             = (ulong)queryOptions;
                ptr->pQueryCompletionCallback = completionCallbackP;

                return ptr;
            }
        }
    }
}
