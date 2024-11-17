using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum GLOBAL_ALLOC_FLAGS : uint
    {
        GHND = 0x0042,
        GMEM_FIXED = 0x00000000,
        GMEM_MOVEABLE = 0x00000002,
        GMEM_ZEROINIT = 0x00000040,
        GPTR = 0x00000040,
    }
}
