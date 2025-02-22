using System;

namespace Hi3Helper.Win32.Native.Enums.Dns
{
    [Flags]
    public enum DNS_RESULT_HAS_RECORD
    {
        HasNone = 0b_0000_0000_0000_0000,
        HasARecord = 0b_0000_0000_0000_0001,
        HasAAAARecord = 0b_0000_0000_0000_0010,
    }
}
