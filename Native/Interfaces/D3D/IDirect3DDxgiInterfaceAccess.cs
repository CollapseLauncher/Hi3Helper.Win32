using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[Guid("A37624AB-8D5F-4650-9D3E-9EAE3D9BC670")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IDirect3DDxgiInterfaceAccess
{
    void GetInterface(in Guid iid, out nint ppv);
}
