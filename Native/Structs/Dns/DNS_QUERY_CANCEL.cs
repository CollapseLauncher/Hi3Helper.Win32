// ReSharper disable InconsistentNaming

using System.Runtime.InteropServices;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    public unsafe struct DNS_QUERY_CANCEL
    {
        public fixed byte Reserved[32];

        public static DNS_QUERY_CANCEL* Create()
            => (DNS_QUERY_CANCEL*)NativeMemory.AllocZeroed((nuint)sizeof(DNS_QUERY_CANCEL));
    }
}
