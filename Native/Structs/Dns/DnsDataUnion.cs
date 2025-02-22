using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Structs.Dns.RecordDataType;

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DnsDataUnion
    {
        [FieldOffset(0)]
        public DNS_A_DATA A;
        [FieldOffset(0)]
        public DNS_SOA_DATA SOA;
        [FieldOffset(0)]
        public DNS_PTR_DATA PTR, NS, CNAME, DNAME, MB, MD, MF, MG, MR;
        [FieldOffset(0)]
        public DNS_MINFO_DATA MINFO, RP;
        [FieldOffset(0)]
        public DNS_MX_DATA MX, AFSDB, RT;
        [FieldOffset(0)]
        public DNS_TXT_DATA HINFO, ISDN, TXT, X25;
        [FieldOffset(0)]
        public DNS_NULL_DATA Null;
        [FieldOffset(0)]
        public DNS_WKS_DATA WKS;
        [FieldOffset(0)]
        public DNS_AAAA_DATA AAAA;
        [FieldOffset(0)]
        public DNS_KEY_DATA KEY;
        [FieldOffset(0)]
        public DNS_SIG_DATA SIG;
        [FieldOffset(0)]
        public DNS_ATMA_DATA ATMA;
        [FieldOffset(0)]
        public DNS_NXT_DATA NXT;
        [FieldOffset(0)]
        public DNS_SRV_DATA SRV;
        [FieldOffset(0)]
        public DNS_NAPTR_DATA NAPTR;
        [FieldOffset(0)]
        public DNS_OPT_DATA OPT;
        [FieldOffset(0)]
        public DNS_DS_DATA DS;
        [FieldOffset(0)]
        public DNS_RRSIG_DATA RRSIG;
        [FieldOffset(0)]
        public DNS_NSEC_DATA NSEC;
        [FieldOffset(0)]
        public DNS_DNSKEY_DATA DNSKEY;
        [FieldOffset(0)]
        public DNS_TKEY_DATA TKEY;
        [FieldOffset(0)]
        public DNS_TSIG_DATA TSIG;
        [FieldOffset(0)]
        public DNS_WINS_DATA WINS;
        [FieldOffset(0)]
        public DNS_WINSR_DATA WINSR, NBSTAT;
        [FieldOffset(0)]
        public DNS_DHCID_DATA DHCID;
    }
}
