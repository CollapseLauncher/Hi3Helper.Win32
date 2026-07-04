using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs;


[StructLayout(LayoutKind.Sequential)]
public struct PROCESS_BASIC_INFORMATION
{
    public long  ExitStatus;
    public nint  PebBaseAddress;
    public nuint AffinityMask;
    public long  BasePriority;
    public nuint UniqueProcessId;
    public nuint InheritedFromUniqueProcessId;
}
