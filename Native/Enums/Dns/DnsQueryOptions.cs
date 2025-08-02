using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Enums.Dns
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/cc982162(v=vs.85).aspx
    /// </summary>
    [Flags]
    public enum DnsQueryOptions
    {
        DNS_QUERY_STANDARD                  = 0x0,
        DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 0x1,
        DNS_QUERY_USE_TCP_ONLY              = 0x2,
        DNS_QUERY_NO_RECURSION              = 0x4,
        DNS_QUERY_BYPASS_CACHE              = 0x8,
        DNS_QUERY_NO_WIRE_QUERY             = 0x10,
        DNS_QUERY_NO_LOCAL_NAME             = 0x20,
        DNS_QUERY_NO_HOSTS_FILE             = 0x40,
        DNS_QUERY_NO_NETBT                  = 0x80,
        DNS_QUERY_WIRE_ONLY                 = 0x100,
        DNS_QUERY_RETURN_MESSAGE            = 0x200,
        DNS_QUERY_MULTICAST_ONLY            = 0x400,
        DNS_QUERY_NO_MULTICAST              = 0x800,
        DNS_QUERY_TREAT_AS_FQDN             = 0x1000,
        DNS_QUERY_ADDRCONFIG                = 0x2000,
        DNS_QUERY_DUAL_ADDR                 = 0x4000,
        DNS_QUERY_MULTICAST_WAIT            = 0x20000,
        DNS_QUERY_MULTICAST_VERIFY          = 0x40000,
        DNS_QUERY_DONT_RESET_TTL_VALUES     = 0x100000,
        DNS_QUERY_DISABLE_IDN_ENCODING      = 0x200000,
        DNS_QUERY_APPEND_MULTILABEL         = 0x800000,
        DNS_QUERY_RESERVED                  = unchecked((int)0xF0000000)
    }
}
