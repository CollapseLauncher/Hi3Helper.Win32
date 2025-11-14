using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum TOKEN_ACCESS : uint
    {
        TOKEN_ALL_ACCESS = 0x000F01FF
    }
}
