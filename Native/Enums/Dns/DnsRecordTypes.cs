// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

#pragma warning disable CA1069
namespace Hi3Helper.Win32.Native.Enums.Dns
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/cc982162(v=vs.85).aspx
    /// Also see http://www.iana.org/assignments/dns-parameters/dns-parameters.xhtml
    /// </summary>
    public enum DnsRecordTypes
    {
        DNS_TYPE_A       = 0x1,
        DNS_TYPE_NS      = 0x2,
        DNS_TYPE_MD      = 0x3,
        DNS_TYPE_MF      = 0x4,
        DNS_TYPE_CNAME   = 0x5,
        DNS_TYPE_SOA     = 0x6,
        DNS_TYPE_MB      = 0x7,
        DNS_TYPE_MG      = 0x8,
        DNS_TYPE_MR      = 0x9,
        DNS_TYPE_NULL    = 0xA,
        DNS_TYPE_WKS     = 0xB,
        DNS_TYPE_PTR     = 0xC,
        DNS_TYPE_HINFO   = 0xD,
        DNS_TYPE_MINFO   = 0xE,
        DNS_TYPE_MX      = 0xF,
        DNS_TYPE_TEXT    = 0x10, // This is how it's specified on MSDN
        DNS_TYPE_TXT     = DNS_TYPE_TEXT,
        DNS_TYPE_RP      = 0x11,
        DNS_TYPE_AFSDB   = 0x12,
        DNS_TYPE_X25     = 0x13,
        DNS_TYPE_ISDN    = 0x14,
        DNS_TYPE_RT      = 0x15,
        DNS_TYPE_NSAP    = 0x16,
        DNS_TYPE_NSAPPTR = 0x17,
        DNS_TYPE_SIG     = 0x18,
        DNS_TYPE_KEY     = 0x19,
        DNS_TYPE_PX      = 0x1A,
        DNS_TYPE_GPOS    = 0x1B,
        DNS_TYPE_AAAA    = 0x1C,
        DNS_TYPE_LOC     = 0x1D,
        DNS_TYPE_NXT     = 0x1E,
        DNS_TYPE_EID     = 0x1F,
        DNS_TYPE_NIMLOC  = 0x20,
        DNS_TYPE_SRV     = 0x21,
        DNS_TYPE_ATMA    = 0x22,
        DNS_TYPE_NAPTR   = 0x23,
        DNS_TYPE_KX      = 0x24,
        DNS_TYPE_CERT    = 0x25,
        DNS_TYPE_A6      = 0x26,
        DNS_TYPE_DNAME   = 0x27,
        DNS_TYPE_SINK    = 0x28,
        DNS_TYPE_OPT     = 0x29,
        DNS_TYPE_DS      = 0x2B,
        DNS_TYPE_RRSIG   = 0x2E,
        DNS_TYPE_NSEC    = 0x2F,
        DNS_TYPE_DNSKEY  = 0x30,
        DNS_TYPE_DHCID   = 0x31,
        DNS_TYPE_UINFO   = 0x64,
        DNS_TYPE_UID     = 0x65,
        DNS_TYPE_GID     = 0x66,
        DNS_TYPE_UNSPEC  = 0x67,
        DNS_TYPE_ADDRS   = 0xF8,
        DNS_TYPE_TKEY    = 0xF9,
        DNS_TYPE_TSIG    = 0xFA,
        DNS_TYPE_IXFR    = 0xFB,
        DNS_TYPE_AFXR    = 0xFC,
        DNS_TYPE_MAILB   = 0xFD,
        DNS_TYPE_MAILA   = 0xFE,
        DNS_TYPE_ALL     = 0xFF,
        DNS_TYPE_ANY     = 0xFF,
        DNS_TYPE_WINS    = 0xFF01,
        DNS_TYPE_WINSR   = 0xFF02,
        DNS_TYPE_NBSTAT  = DNS_TYPE_WINSR
    }
}
