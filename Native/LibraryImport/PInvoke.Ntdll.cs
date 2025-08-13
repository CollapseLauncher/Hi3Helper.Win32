using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("ntdll.dll", EntryPoint = "NtQuerySystemInformation", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial uint NtQuerySystemInformation(int systemInformationClass, byte* systemInformation, uint systemInformationLength, out uint returnLength);

        [LibraryImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint OpenProcess(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [LibraryImport("kernel32.dll", EntryPoint = "QueryFullProcessImageNameW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool QueryFullProcessImageName(nint hProcess, int dwFlags, char* lpExeName, ref int lpdwSize);
    }
}
