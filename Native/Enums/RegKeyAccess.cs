using System;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum RegKeyAccess : uint
    {
        KEY_QUERY_VALUE = 0x0001,
        KEY_NOTIFY      = 0x0010
    }
}
