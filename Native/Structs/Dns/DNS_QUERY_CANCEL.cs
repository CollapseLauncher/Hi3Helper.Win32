// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    public unsafe struct DNS_QUERY_CANCEL
    {
        public fixed byte Reserved[32];

        public static DNS_QUERY_CANCEL Create()
            => new();
    }
}
