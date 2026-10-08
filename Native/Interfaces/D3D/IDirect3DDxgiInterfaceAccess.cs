using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("A9B3D012-3DF2-4EE3-B8D1-8695F457D3C1")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface IDirect3DDxgiInterfaceAccess
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInterface(
        in  Guid iid,
        out nint ppv);
}
