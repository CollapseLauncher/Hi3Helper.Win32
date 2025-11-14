using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums.DXGI;

[Flags]
public enum DXGI_MAP_FLAGS : uint
{
    DXGI_MAP_READ    = 0x00000001,
    DXGI_MAP_WRITE   = 0x00000002,
    DXGI_MAP_DISCARD = 0x00000004
}
