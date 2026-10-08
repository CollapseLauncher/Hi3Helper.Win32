using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums.DXGI;

[Flags]
public enum DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG : uint
{
    PRESENT         = 0x1,
    OVERLAY_PRESENT = 0x2
}
