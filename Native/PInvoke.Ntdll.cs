using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        [LibraryImport("ntdll.dll", EntryPoint = "NtQuerySystemInformation", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public unsafe static partial uint NtQuerySystemInformation(int SystemInformationClass, byte* SystemInformation, uint SystemInformationLength, out uint ReturnLength);

        [LibraryImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial nint OpenProcess(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [LibraryImport("kernel32.dll", EntryPoint = "QueryFullProcessImageNameW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool QueryFullProcessImageName(nint hProcess, int dwFlags, char* lpExeName, ref int lpdwSize);
    }
}
