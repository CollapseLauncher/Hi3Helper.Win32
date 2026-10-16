using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Structs;

// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(ClassFactoryClsId.IClassFactory)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IClassFactory
{
    // For HRESULTs use
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateInstance(nint     pUnkOuter,
                           in  Guid riid,
                           out nint ppvObject);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
}
