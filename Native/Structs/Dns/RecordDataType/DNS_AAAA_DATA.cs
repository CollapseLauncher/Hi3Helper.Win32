using System;
using System.Net;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682035(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_AAAA_DATA : IDNS_WITH_IPADDR
    {
        public fixed uint Ip6Address[4];

        public IPAddress GetIPAddress()
        {
            const int sizeOf = sizeof(uint) * 4;
            fixed (void* ptr = &this)
            {
                IPAddress returnAddress = new IPAddress(new ReadOnlySpan<byte>(ptr, sizeOf));
                return returnAddress;
            }
        }

        public override string ToString() => GetIPAddress().ToString();
    }
}
