using Hi3Helper.Win32.Native.ClassIds;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(ClassFactoryClsId.IClassFactory)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(Options = ComInterfaceOptions.ManagedObjectWrapper | ComInterfaceOptions.ComObjectWrapper)]
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
}
