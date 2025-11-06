using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum ProcessCreationFlags : uint
    {
        EXTENDED_STARTUPINFO_PRESENT = 0x00080000
    }
}
