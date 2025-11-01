using Hi3Helper.Win32.Native.Enums.Dns;
using Hi3Helper.Win32.Native.Structs.Dns;
using System;
using System.Runtime.InteropServices;
// ReSharper disable StringLiteralTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMethodReturnValue.Global

#pragma warning disable CA1401
namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dnsapi.dll", EntryPoint = "DnsQuery_W", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static unsafe partial int DnsQuery(string lpStrName, DnsRecordTypes wType, DnsQueryOptions options, IntPtr pExtra, out DNS_RECORD* ppQueryResultsSet, IntPtr pReserved);

        [LibraryImport("dnsapi.dll")]
        public static unsafe partial void DnsRecordListFree(DNS_RECORD* ppQueryResultsSet, DNS_FREE_TYPE freeType);

        [LibraryImport("dnsapi.dll", EntryPoint = "DnsQueryEx", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial DnsStatus DnsQueryEx(DNS_QUERY_REQUEST3* requestQuery, DNS_QUERY_RESULT* queryResult, DNS_QUERY_CANCEL* queryCancel);

        [LibraryImport("dnsapi.dll", EntryPoint = "DnsCancelQuery", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial DnsStatus DnsCancelQuery(DNS_QUERY_CANCEL* queryCancel);

        public static unsafe void DnsRecordListFree(nint ppQueryResultsSet, DNS_FREE_TYPE freeType)
            => DnsRecordListFree((DNS_RECORD*)ppQueryResultsSet, freeType);
    }
}
