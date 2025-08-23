using System;
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum ExecutionState : uint
    {
        EsAwaymodeRequired = 0x00000040,
        EsContinuous       = 0x80000000,
        EsDisplayRequired  = 0x00000002,
        EsSystemRequired   = 0x00000001
    }
}
