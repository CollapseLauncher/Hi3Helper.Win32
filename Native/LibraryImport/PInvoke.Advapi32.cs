using Hi3Helper.Win32.Native.Enums;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
// ReSharper disable StringLiteralTypo
#pragma warning disable CA1401

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("advapi32.dll", EntryPoint = "RegOpenKeyExW", StringMarshalling = StringMarshalling.Utf16)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegOpenKeyEx(HKEYCLASS hKey,
                                               string    subKey,
                                               uint      options,
                                               uint      samDesired,
                                               out nint  phkResult);

        [LibraryImport("advapi32.dll", EntryPoint = "RegNotifyChangeKeyValue")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegNotifyChangeKeyValue(
            nint                                 hKey,
            [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree,
            RegChangeNotifyFilter                dwNotifyFilter,
            SafeWaitHandle                       hEvent,
            [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous);

        [LibraryImport("advapi32.dll", EntryPoint = "RegCloseKey")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial int RegCloseKey(nint hKey);

        [LibraryImport("advapi32.dll", EntryPoint = "OpenProcessToken", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool OpenProcessToken(nint ProcessHandle, TOKEN_ACCESS DesiredAccess, out nint TokenHandle);

        [LibraryImport("advapi32.dll", EntryPoint = "DuplicateTokenEx", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool DuplicateTokenEx(
            nint hExistingToken,
            TOKEN_ACCESS dwDesiredAccess,
            nint lpTokenAttributes,
            SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            TOKEN_TYPE TokenType,
            out nint phNewToken);
    }
}
