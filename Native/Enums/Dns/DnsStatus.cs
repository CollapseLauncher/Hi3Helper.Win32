// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

using System;

#pragma warning disable CA1069

namespace Hi3Helper.Win32.Native.Enums.Dns
{
    [Flags]
    public enum DnsStatus : uint
    {
        // Success
        Success = 0, // ERROR_SUCCESS

        // General errors
        ErrorInvalidName     = 123, // ERROR_INVALID_NAME
        ErrorNotEnoughMemory = 8,   // ERROR_NOT_ENOUGH_MEMORY
        ErrorNoData          = 232, // ERROR_NO_DATA

        // Winsock related errors (WS*)
        WsaEhostNotFound = 11001, // WS_HOST_NOT_FOUND
        WsaEtryAgain     = 11002, // WS_TRY_AGAIN
        WsaEnodata       = 11004, // WS_NO_DATA

        // DNS-specific errors (from windns.h)
        DnsInfoNoRecords            = 9501, // DNS_INFO_NO_RECORDS
        DnsErrorRcodeFormatError    = 9001, // DNS_ERROR_RCODE_FORMAT_ERROR
        DnsErrorRcodeServerFailure  = 9002, // DNS_ERROR_RCODE_SERVER_FAILURE
        DnsErrorRcodeNameError      = 9003, // DNS_ERROR_RCODE_NAME_ERROR
        DnsErrorRcodeNotImplemented = 9004, // DNS_ERROR_RCODE_NOT_IMPLEMENTED
        DnsErrorRcodeRefused        = 9005, // DNS_ERROR_RCODE_REFUSED
        DnsErrorRcodeYxdomain       = 9006, // DNS_ERROR_RCODE_YXDOMAIN
        DnsErrorRcodeYxrrset        = 9007, // DNS_ERROR_RCODE_YXRRSET
        DnsErrorRcodeNxdomain       = 9003, // Alias for NameError
        DnsErrorRcodeNxrrset        = 9008, // DNS_ERROR_RCODE_NXRRSET
        DnsErrorRcodeNotAuth        = 9009, // DNS_ERROR_RCODE_NOTAUTH
        DnsErrorRcodeNotZone        = 9010, // DNS_ERROR_RCODE_NOTZONE
        DnsErrorRcodeBadSig         = 9016, // DNS_ERROR_RCODE_BADSIG
        DnsErrorRcodeBadKey         = 9017, // DNS_ERROR_RCODE_BADKEY
        DnsErrorRcodeBadTime        = 9018, // DNS_ERROR_RCODE_BADTIME

        // Other DNS errors
        DnsErrorBadPacket      = 9502, // DNS_ERROR_BAD_PACKET
        DnsErrorNoPacket       = 9503, // DNS_ERROR_NO_PACKET
        DnsErrorRcode          = 9504, // DNS_ERROR_RCODE
        DnsErrorUnsecurePacket = 9505, // DNS_ERROR_UNSECURE_PACKET
        DnsRequestPending      = 9506, // DNS_REQUEST_PENDING

        // Timeout and network issues
        Timeout = 1460 // ERROR_TIMEOUT
    }
}
