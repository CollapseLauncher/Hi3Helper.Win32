using Hi3Helper.Win32.Native.Enums.Dns;
using Hi3Helper.Win32.Native.Structs.Dns;
using System;
using System.Runtime.InteropServices;
// ReSharper disable StringLiteralTypo

#pragma warning disable CA1401
namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dnsapi.dll", EntryPoint = "DnsQuery_W", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static unsafe partial int DnsQuery(string lpStrName, DnsRecordTypes wType, DnsQueryOptions options, IntPtr pExtra, out DNS_RECORD* ppQueryResultsSet, IntPtr pReserved);

        [LibraryImport("dnsapi.dll")]
        public static unsafe partial void DnsRecordListFree(DNS_RECORD* ppQueryResultsSet, DNS_FREE_TYPE freeType);

        public static unsafe void DnsRecordListFree(nint ppQueryResultsSet, DNS_FREE_TYPE freeType)
            => DnsRecordListFree((DNS_RECORD*)ppQueryResultsSet, freeType);
    }
}
