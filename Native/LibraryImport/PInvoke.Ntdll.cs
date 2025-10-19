using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("ntdll.dll", EntryPoint = "NtQuerySystemInformation", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial uint NtQuerySystemInformation(int systemInformationClass, byte* systemInformation, uint systemInformationLength, out uint returnLength);
    }
}
