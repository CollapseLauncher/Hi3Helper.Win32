using System.Net;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    public interface IDNS_WITH_IPADDR
    {
        IPAddress GetIPAddress();
    }
}
