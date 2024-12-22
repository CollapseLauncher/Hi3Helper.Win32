using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum TagREGCLS : uint
    {
        REGCLS_SINGLEUSE = 0,
        REGCLS_MULTIPLEUSE = 1,
        REGCLS_MULTI_SEPARATE = 2,
        REGCLS_SUSPENDED = 4,
        REGCLS_SURROGATE = 8,
        REGCLS_AGILE = 0x10
    }
}
