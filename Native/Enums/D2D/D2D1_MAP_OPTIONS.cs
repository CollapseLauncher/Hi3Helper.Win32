using System;

namespace Hi3Helper.Win32.Native.Enums.D2D;

[Flags]
public enum D2D1_MAP_OPTIONS
{
    D2D1_MAP_OPTIONS_NONE = 0,
    D2D1_MAP_OPTIONS_READ = 1,
    D2D1_MAP_OPTIONS_WRITE = 2,
    D2D1_MAP_OPTIONS_DISCARD = 4,
}