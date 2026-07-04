using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport;

public static partial class PInvoke
{
    [LibraryImport("ntdll.dll", EntryPoint = "NtQuerySystemInformation", SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static unsafe partial uint NtQuerySystemInformation(int systemInformationClass, byte* systemInformation, uint systemInformationLength, out uint returnLength);

    [LibraryImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess", SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static unsafe partial uint NtQueryInformationProcess(nint processHandle, uint processInformationClass, nint processInformation, int processInformationLength, out uint returnLength);

    public static unsafe uint NtQueryInformationProcess<T>(
        nint     processHandle,
        uint     processInformationClass,
        ref T    processInformation,
        out uint returnLength)
    where T : unmanaged
        => NtQueryInformationProcess(processHandle,
                                     processInformationClass,
                                     (nint)Unsafe.AsPointer(ref processInformation),
                                     sizeof(T),
                                     out returnLength);
}
