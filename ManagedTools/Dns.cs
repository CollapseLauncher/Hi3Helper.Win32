using Hi3Helper.Win32.Native.Enums.Dns;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs.Dns;
using Hi3Helper.Win32.Native.Structs.Dns.RecordDataType;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertIfStatementToSwitchStatement

namespace Hi3Helper.Win32.ManagedTools;

#pragma warning disable CA1859
public static class Dns
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
            using IEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv4 =
                EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_A, bypassCache, logger)
                   .GetEnumerator();

            using IEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv6 =
                EnumerateDnsRecord(host, DnsRecordTypes.DNS_TYPE_AAAA, bypassCache, logger)
                   .GetEnumerator();

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
        nint recordPtr        = nint.Zero;
        nint recordInitialPos = nint.Zero;

        try
        {
            bool isStop    = false;
            int  lastError = 0;

            // If it's not the end of the data and the record can be enumerated, get the record result.
            while (!isStop &&
                   EnumerateRecord(host,
                                   recordType,
                                   bypassCache,
                                   ref recordPtr,
                                   out nint recordPtrNext,
                                   out lastError,
                                   out DnsDataUnion recordResult,
                                   out uint recordTimeToLive))
            {
                // Save the initial pointer where it determines the first position of the record array.
                // This to ensure that the array pointer can be flushed once the enumeration is completed.
                if (recordInitialPos == nint.Zero)
                {
                    recordInitialPos = recordPtr;
                }

                // Determine if this enumeration is the last one and
                // set the pointer to the next data
                isStop    = recordPtrNext == nint.Zero;
                recordPtr = recordPtrNext;

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
            if (recordInitialPos != nint.Zero)
            {
                PInvoke.DnsRecordListFree(recordInitialPos, DNS_FREE_TYPE.DnsFreeFlat);
            }
        }
    }

    private static unsafe bool EnumerateRecord(string           host,
                                               DnsRecordTypes   recordType,
                                               bool             bypassCache,
                                               ref nint         lastRecord,
                                               out nint         nextRecord,
                                               out int          lastError,
                                               out DnsDataUnion resultData,
                                               out uint         resultDataTtl)
    {
        // Initialize the options and result data
        DnsQueryOptions queryOptions = DNS_QUERY_REQUEST3.DefaultQueryOptions;
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

    /// <summary>
    /// Enumerate A and AAAA (if any) record of the host asynchronously. Returns none of the enumeration if it cannot find one.
    /// </summary>
    /// <param name="host">The hostname where the A and AAAA record to be resolved.</param>
    /// <param name="bypassCache">Whether to bypass OS's DNS cache. Default: <c>false</c></param>
    /// <param name="zigzagResult">Instead of getting both IPv4 and IPv6 result sequentially, the result will begin from IPv4 then IPv6 and so-on.</param>
    /// <param name="logger">Logger to display any debug or error message while requesting the record.</param>
    /// <returns>Enumerable of the tuple of <seealso cref="IDNS_WITH_IPADDR"/> as the record and <see cref="uint"/> as the TTL</returns>
    /// <param name="token">A cancellation token to cancel the async operation.</param>
    public static async IAsyncEnumerable<(IDNS_WITH_IPADDR Record, uint TimeToLive)>
        EnumerateIPAddressFromHostAsync(string   host,
                                        bool     bypassCache  = false,
                                        bool     zigzagResult = false,
                                        ILogger? logger       = null,
                                        [EnumeratorCancellation] CancellationToken token = default)
    {
        if (zigzagResult)
        {
            await using IAsyncEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv4 =
                EnumerateDnsRecordAsync(host, DnsRecordTypes.DNS_TYPE_A, bypassCache, logger, token)
                   .GetAsyncEnumerator(token);

            await using IAsyncEnumerator<(DnsDataUnion RecordUnion, uint TimeToLive)> recordIpv6 =
                EnumerateDnsRecordAsync(host, DnsRecordTypes.DNS_TYPE_AAAA, bypassCache, logger, token)
                   .GetAsyncEnumerator(token);

            EnumerateZigZag:
            bool isNextIpv4 = await recordIpv4.MoveNextAsync();
            bool isNextIpv6 = await recordIpv6.MoveNextAsync();

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

        // Enumerate the A Record first (for IPv4)
        await foreach ((DnsDataUnion RecordUnion, uint TimeToLive) data in EnumerateDnsRecordAsync(host, DnsRecordTypes.DNS_TYPE_A, bypassCache, logger, token))
        {
            IDNS_WITH_IPADDR ipv4AddrRecord = data.RecordUnion.A;
#if DEBUG
            string? ipv4AddrString = ipv4AddrRecord.ToString();
            logger?.LogDebug("Found A Record from host: {host} -> IPv4: {ipv4AddrString}", host, ipv4AddrString);
#endif
            yield return (ipv4AddrRecord, data.TimeToLive);
        }

        // Then try to enumerate the AAAA record (for IPv6)
        await foreach ((DnsDataUnion RecordUnion, uint TimeToLive) data in EnumerateDnsRecordAsync(host, DnsRecordTypes.DNS_TYPE_AAAA, bypassCache, logger, token))
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
    /// Enumerate the record result of the host asynchronously. Returns none of the enumeration if it cannot find one.
    /// </summary>
    /// <param name="host">The hostname where the record to be resolved.</param>
    /// <param name="recordType">Record type to resolve.</param>
    /// <param name="bypassCache">Whether to bypass OS's DNS cache. Default: <c>false</c></param>
    /// <param name="logger">Logger to display any debug or error message while requesting the record.</param>
    /// <returns>Async Enumerable of the tuple of <seealso cref="DnsDataUnion"/> and <see cref="uint"/> as the TTL</returns>
    /// <param name="token">A cancellation token to cancel the async operation.</param>
    public static async IAsyncEnumerable<(DnsDataUnion RecordUnion, uint TimeToLive)>
        EnumerateDnsRecordAsync(string                                     host,
                                DnsRecordTypes                             recordType,
                                bool                                       bypassCache = false,
                                ILogger?                                   logger      = null,
                                [EnumeratorCancellation] CancellationToken token       = default)
    {
        nint result = await DnsQueryAsync(host,
                                          recordType,
                                          bypassCache,
                                          throwIfNotFound: false,
                                          token: token).ConfigureAwait(false);

        if (result == nint.Zero)
        {
            yield break;
        }

        // Initialize the pointer of the record array information
        nint recordPtr = result;
        bool isStop    = false;

        try
        {
            // If it's not the end of the data and the record can be enumerated, get the record result.
            while (!isStop &&
                   EnumerateRecord(host,
                                   recordType,
                                   bypassCache,
                                   ref recordPtr,
                                   out nint recordPtrNext,
                                   out int _,
                                   out DnsDataUnion recordResult,
                                   out uint recordTimeToLive))
            {
                // Determine if this enumeration is the last one and
                // set the pointer to the next data
                isStop    = recordPtrNext == nint.Zero;
                recordPtr = recordPtrNext;

                // Then yield the record result
                yield return (recordResult, recordTimeToLive);
            }
        }
        finally
        {
            // Free the record array if it's not null
            if (result != nint.Zero)
            {
                PInvoke.DnsRecordListFree(result, DNS_FREE_TYPE.DnsFreeFlat);
            }
        }
    }

    /// <summary>
    /// Performs a DNS query asynchronously using the <see cref="PInvoke.DnsQueryEx"/> method.
    /// </summary>
    /// <param name="host">The hostname to query into.</param>
    /// <param name="recordType">A type of the record to get.</param>
    /// <param name="bypassCache">Whether to bypass the DNS cacne.</param>
    /// <param name="throwIfNotFound">Whether to throw if no record is present.</param>
    /// <param name="token">A cancellation token to cancel the async operation.</param>
    /// <returns>A pointer to the <see cref="DNS_RECORD"/> struct.</returns>
    public static unsafe Task<nint> DnsQueryAsync(
        string            host,
        DnsRecordTypes    recordType,
        bool              bypassCache     = false,
        bool              throwIfNotFound = false,
        CancellationToken token           = default)
    {
        TaskCompletionSource<nint> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

        DnsQueryOptions options = DNS_QUERY_REQUEST3.DefaultQueryOptions;
        if (bypassCache)
        {
            options |= DnsQueryOptions.DNS_QUERY_BYPASS_CACHE;
        }

        DNS_QUERY_CANCEL   queryCancel  = DNS_QUERY_CANCEL.Create();
        DNS_QUERY_RESULT   queryResult  = DNS_QUERY_RESULT.Create();
        DNS_QUERY_REQUEST3 queryRequest = DNS_QUERY_REQUEST3.Create(host, Impl, recordType, options);

        DnsStatus status = PInvoke.DnsQueryEx(in queryRequest, ref queryResult, ref queryCancel);
        if (status == DnsStatus.Success)
        {
            DNS_QUERY_REQUEST3* queryRequestP = &queryRequest;
            Impl(nint.Zero, (nint)queryRequestP);
        }
        else if (status is not DnsStatus.DnsRequestPending)
        {
            tcs.SetException(GetWin32ExceptionFromStatus(status));
        }
        else
        {
            token.Register(() =>
                           {
                               PInvoke.DnsCancelQuery(in queryCancel);
                               tcs.SetCanceled(token);
                           });
        }

        return tcs.Task;

        Win32Exception GetWin32ExceptionFromStatus(DnsStatus value)
            => new Win32Exception((int)value,
                                  $"Failed while trying to get DNS query of: {host} ({recordType}) with error: {(int)value}/{value}");

        void Impl(nint pQueryContext, nint pQueryResults)
        {
            ref DNS_QUERY_RESULT queryResultRef = ref Unsafe.AsRef<DNS_QUERY_RESULT>((void*)pQueryResults);
            if (Unsafe.IsNullRef(ref queryResultRef))
            {
                tcs.SetException(new InvalidDataException("DnsQueryEx returns a null result!"));
                return;
            }

            if (queryResultRef.QueryStatus != DnsStatus.Success)
            {
                tcs.SetException(GetWin32ExceptionFromStatus(queryResultRef.QueryStatus));
                return;
            }

            if (queryResultRef.QueryStatus == DnsStatus.DnsInfoNoRecords && throwIfNotFound)
            {
                tcs.SetException(new Win32Exception((int)queryResultRef.QueryStatus, $"No query was found for: {host} ({recordType})"));
            }

            tcs.SetResult(queryResultRef.GetRecordPtr());
        }
    }
}