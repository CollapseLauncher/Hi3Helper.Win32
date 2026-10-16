using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface]
[Guid("A30B49F7-D6E9-4464-86B4-D3EBF66E07E8")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface IAnimationTiming
{
    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetFrameTimingTicks(uint index, out ulong startTicks, out ulong durationTicks, out uint timescale);
}