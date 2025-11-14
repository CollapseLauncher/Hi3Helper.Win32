// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System;

namespace Hi3Helper.Win32.Native.Enums.DXGI;

[Flags]
public enum DXGI_MWA_FLAGS : uint
{
    DXGI_MWA_NO_WINDOW_CHANGES = 0x00000001,
    DXGI_MWA_NO_ALT_ENTER      = 0x00000002,
    DXGI_MWA_NO_PRINT_SCREEN   = 0x00000004,
    DXGI_MWA_VALID             = 0x00000007
}
