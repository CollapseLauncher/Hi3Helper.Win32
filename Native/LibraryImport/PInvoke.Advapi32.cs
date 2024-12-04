﻿using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("advapi32.dll", EntryPoint = "RegOpenKeyExW", StringMarshalling = StringMarshalling.Utf16)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegOpenKeyEx(HKEYCLASS hKey, string subKey, uint options, uint samDesired,
                                               out nint phkResult);

        [LibraryImport("advapi32.dll", EntryPoint = "RegNotifyChangeKeyValue")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegNotifyChangeKeyValue(
            nint hKey,
            [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree,
            RegChangeNotifyFilter dwNotifyFilter,
            nint hEvent,
            [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous);

        [LibraryImport("advapi32.dll", EntryPoint = "RegCloseKey")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegCloseKey(nint hKey);
    }
}
