using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum ExecutionState : uint
    {
        EsAwaymodeRequired = 0x00000040,
        EsContinuous = 0x80000000,
        EsDisplayRequired = 0x00000002,
        EsSystemRequired = 0x00000001
    }
}
