using System;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums.Registry;

[Flags]
public enum HKEY
{
    None,
    HKEY_CLASSES_ROOT = int.MinValue,
    HKEY_CURRENT_USER,
    HKEY_LOCAL_MACHINE,
    HKEY_USERS,
    HKEY_PERFORMANCE_DATA,
    HKEY_CURRENT_CONFIG,
    HKEY_DYN_DATA,
    HKEY_PERFORMANCE_TEXT    = unchecked((int)0x80000050),
    HKEY_PERFORMANCE_NLSTEXT = unchecked((int)0x80000060)
}
