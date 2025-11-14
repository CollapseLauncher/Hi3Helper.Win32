using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums.DXGI;

[Flags]
public enum DXGI_ADAPTER_FLAG : uint
{
    DXGI_ADAPTER_FLAG_NONE        = 0,
    DXGI_ADAPTER_FLAG_REMOTE      = 1,
    DXGI_ADAPTER_FLAG_SOFTWARE    = 2,
    DXGI_ADAPTER_FLAG_FORCE_DWORD = 0xffffffff
}
