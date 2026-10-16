using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface]
[Guid("66EE13E1-CC44-48F7-A038-6D2EF00A571A")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface IAnimationInfo
{
    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetAnimationInfo(out uint animated, out uint loopCount, out uint backgroundBgra);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetFrameTiming(uint index, out uint startMilliseconds, out uint durationMilliseconds);
}
