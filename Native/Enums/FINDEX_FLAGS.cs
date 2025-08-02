using System;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum FINDEX_FLAGS
    {
        FIND_FIRST_EX_CASE_SENSITIVE       = 0x1,
        FIND_FIRST_EX_LARGE_FETCH          = 0x2,
        FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY = 0x4
    }
}
