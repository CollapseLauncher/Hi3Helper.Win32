using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Enums.DXGI;

public enum DXGI_ADAPTER_FLAG : uint
{
    DXGI_ADAPTER_FLAG_NONE        = 0,
    DXGI_ADAPTER_FLAG_REMOTE      = 1,
    DXGI_ADAPTER_FLAG_SOFTWARE    = 2,
    DXGI_ADAPTER_FLAG_FORCE_DWORD = 0xffffffff
}
