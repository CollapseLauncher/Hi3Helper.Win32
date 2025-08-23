using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum FORMAT_MESSAGE
    {
        MAX_WIDTH_MASK  = 0xFF,
        ALLOCATE_BUFFER = 0x100,
        IGNORE_INSERTS  = 0x200,
        FROM_STRING     = 0x400,
        FROM_HMODULE    = 0x800,
        FROM_SYSTEM     = 0x1000,
        ARGUMENT_ARRAY  = 0x2000,
        DEFAULT         = ALLOCATE_BUFFER | IGNORE_INSERTS | FROM_SYSTEM
    }
}
