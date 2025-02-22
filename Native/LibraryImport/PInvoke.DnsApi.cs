using Hi3Helper.Win32.Native.Enums.Dns;
using Hi3Helper.Win32.Native.Structs.Dns;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dnsapi.dll", EntryPoint = "DnsQuery_W", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static unsafe partial int DnsQuery(string lpstrName, DnsRecordTypes wType, DnsQueryOptions Options, IntPtr pExtra, out DNS_RECORD* ppQueryResultsSet, IntPtr pReserved);

        [LibraryImport("dnsapi.dll")]
        public static unsafe partial void DnsRecordListFree(DNS_RECORD* ppQueryResultsSet, DNS_FREE_TYPE FreeType);

        public static unsafe void DnsRecordListFree(nint ppQueryResultsSet, DNS_FREE_TYPE freeType)
            => DnsRecordListFree((DNS_RECORD*)ppQueryResultsSet, freeType);
    }
}
