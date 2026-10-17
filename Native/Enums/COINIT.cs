using System;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums;

[Flags]
public enum COINIT : uint
{
    COINIT_MULTITHREADED     = 0x0,
    COINIT_APARTMENTTHREADED = 0x2,
    COINIT_DISABLE_OLE1DDE   = 0x4,
    COINIT_SPEED_OVER_MEMORY = 0x8
}
