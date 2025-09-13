// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum SICHINTF : uint
    {
        SICHINT_DISPLAY                       = 0,
        SICHINT_ALLFIELDS                     = 0x1,
        SICHINT_CANONICAL                     = 0x10000000,
        SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
    }
}
