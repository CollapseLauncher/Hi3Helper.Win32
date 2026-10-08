using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("00000000-0000-0000-C000-000000000046")]
public partial interface IUnknown
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult QueryInterface(in Guid riid, out nint ppvObject);

    [PreserveSig]
    int AddRef();

    [PreserveSig]
    int Release();
}