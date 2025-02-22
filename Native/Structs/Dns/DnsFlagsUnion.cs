using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DnsFlagsUnion
    {
        [FieldOffset(0)]
        public uint DW;
        [FieldOffset(0)]
        public DNS_RECORD_FLAGS S;
    }
}
