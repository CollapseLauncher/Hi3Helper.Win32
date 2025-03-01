using Hi3Helper.Win32.Native.Enums.Dns;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs.Dns;
using Hi3Helper.Win32.Native.Structs.Dns.RecordDataType;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertIfStatementToSwitchStatement

namespace Hi3Helper.Win32.ManagedTools;

#pragma warning disable CA1859
public static unsafe class Dns
{
    /// <summary>
    /// Enumerate A and AAAA (if any) record of the host. Returns none of the enumeration if it cannot find one.
    /// </summary>
    /// <param name="host">The hostname where the A and AAAA record to be resolved.</param>
    /// <param name="bypassCache">Whether to bypass OS's DNS cache. Default: <c>false</c></param>
    /// <param name="zigzagResult">Instead of getting both IPv4 and IPv6 result sequentially, the result will begin from IPv4 then IPv6 and so-on.</param>
    /// <param name="logger">Logger to display any debug or error message while requesting the record.</param>
    /// <returns>Enumerable of the tuple of <seealso cref="IDNS_WITH_IPADDR"/> as the record and <see cref="uint"/> as the TTL</returns>
    public static IEnumerable<(IDNS_WITH_IPADDR Record, uint TimeToLive)> EnumerateIPAddressFromHost(string host, bool bypassCache = false, bool zigzagResult = false, ILogger? logger = null)
    {
        if (zigzagResult)
        {
            IEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv4 =
                EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_A, bypassCache, logger)
                   .GetEnumerator();

            IEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv6 =
                EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_AAAA, bypassCache, logger)
                   .GetEnumerator();

            try
            {
                EnumerateZigZag:
                bool isNextIpv4 = recordIpv4.MoveNext();
                bool isNextIpv6 = recordIpv6.MoveNext();

                if (!isNextIpv4 && !isNextIpv6)
                {
                    yield break;
                }

                if (isNextIpv4)
                {
                    yield return (recordIpv4.Current.RecordUnion.A, recordIpv4.Current.TimeToLive);
                }

                if (isNextIpv6)
                {
                    yield return (recordIpv4.Current.RecordUnion.AAAA, recordIpv4.Current.TimeToLive);
                }

                goto EnumerateZigZag;
            }
            finally
            {
                recordIpv4.Dispose();
                recordIpv6.Dispose();
            }
        }

        // Enumerate the A Record first (for IPv4)
        foreach ((DnsDataUnion RecordUnion, uint TimeToLive) data in EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_A, bypassCache, logger))
        {
            IDNS_WITH_IPADDR ipv4AddrRecord = data.RecordUnion.A;
#if DEBUG
            string? ipv4AddrString = ipv4AddrRecord.ToString();
            logger?.LogDebug("Found A Record from host: {host} -> IPv4: {ipv4AddrString}", host, ipv4AddrString);
#endif
            yield return (ipv4AddrRecord, data.TimeToLive);
        }

        // Then try to enumerate the AAAA record (for IPv6)
        foreach ((DnsDataUnion RecordUnion, uint TimeToLive) data in EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_AAAA, bypassCache, logger))
        {
            IDNS_WITH_IPADDR ipv6AddrRecord = data.RecordUnion.AAAA;
#if DEBUG
            string? ipv6AddrString = ipv6AddrRecord.ToString();
            logger?.LogDebug("Found AAAA Record from host: {host} -> IPv6: {ipv6AddrString}", host, ipv6AddrString);
#endif
            yield return (ipv6AddrRecord, data.TimeToLive);
        }
    }

    /// <summary>
    /// Enumerate the record result of the host. Returns none of the enumeration if it cannot find one.
    /// </summary>
    /// <param name="host">The hostname where the record to be resolved.</param>
    /// <param name="recordType">Record type to resolve.</param>
    /// <param name="bypassCache">Whether to bypass OS's DNS cache. Default: <c>false</c></param>
    /// <param name="logger">Logger to display any debug or error message while requesting the record.</param>
    /// <returns>Enumerable of the tuple of <seealso cref="DnsDataUnion"/> and <see cref="uint"/> as the TTL</returns>
    public static IEnumerable<(DnsDataUnion RecordUnion, uint TimeToLive)> EnumerateDnsRecord(string host, DnsRecordTypes recordType, bool bypassCache = false, ILogger? logger = null)
    {
        // Initialize the pointer of the record array information
        nint recordAPtr        = nint.Zero;
        nint recordAInitialPos = nint.Zero;

        try
        {
            bool isStop = false;
            int lastError = 0;

            // If it's not the end of the data and the record can be enumerated, get the record result.
            while (!isStop &&
                   EnumerateRecord(host,
                                   recordType,
                                   bypassCache,
                                   ref recordAPtr,
                                   out nint recordAPtrNext,
                                   out lastError,
                                   out DnsDataUnion recordResult,
                                   out uint recordTimeToLive))
            {
                // Save the initial pointer where it determines the first position of the record array.
                // This to ensure that the array pointer can be flushed once the enumeration is completed.
                if (recordAInitialPos == nint.Zero)
                {
                    recordAInitialPos = recordAPtr;
                }

                // Determine if this enumeration is the last one and
                // set the pointer to the next data
                isStop = recordAPtrNext == nint.Zero;
                recordAPtr = recordAPtrNext;

                // Then yield the record result
                yield return (recordResult, recordTimeToLive);
            }

            // If it fails to resolve the record, log the error
            if (lastError != 0)
            {
                logger?.LogError(new Win32Exception(lastError), message: "Error has occured while querying {recordType} Record of this host: {host}", host, recordType);
            }
        }
        finally
        {
            // Free the record array if it's not null
            if (recordAInitialPos != nint.Zero)
            {
                PInvoke.DnsRecordListFree(recordAInitialPos, DNS_FREE_TYPE.DnsFreeFlat);
            }
        }
    }

    private static bool EnumerateRecord(string           host,
                                        DnsRecordTypes   recordType,
                                        bool             bypassCache,
                                        ref nint         lastRecord,
                                        out nint         nextRecord,
                                        out int          lastError,
                                        out DnsDataUnion resultData,
                                        out uint         resultDataTtl)
    {
        // Initialize the options and result data
        DnsQueryOptions queryOptions = DnsQueryOptions.DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE;
        Unsafe.SkipInit(out resultData);
        Unsafe.SkipInit(out resultDataTtl);
        nextRecord = nint.Zero;
        lastError = 0;

        // If cache bypass is toggled, add the bypass flag
        if (bypassCache)
        {
            queryOptions |= DnsQueryOptions.DNS_QUERY_BYPASS_CACHE;
        }

        // If the lastRecord is empty, then begin to query the
        // record information and get the data.
        if (lastRecord == nint.Zero)
        {
            lastError = PInvoke.DnsQuery(host,
                                         recordType,
                                         queryOptions,
                                         nint.Zero,
                                         out DNS_RECORD* dnsArray,
                                         nint.Zero);

            // If it errors out, return false
            if (lastError != 0)
            {
                return false;
            }

            resultDataTtl = dnsArray->dwTtl;
            lastRecord    = (nint)dnsArray;
        }

        // Get the result data and output the next pointer of the record
        // from the array.
        DNS_RECORD* currentRecord = (DNS_RECORD*)lastRecord;
        nextRecord    = (nint)currentRecord->pNext;
        resultData    = currentRecord->Data;
        resultDataTtl = currentRecord->dwTtl;
        return true;
    }
}