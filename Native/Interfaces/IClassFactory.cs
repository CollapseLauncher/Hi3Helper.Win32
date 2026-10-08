using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
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
    int CreateInstance(nint     pUnkOuter,
                       in  Guid riid,
                       out nint ppvObject);

    [PreserveSig]
    int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock);
}
