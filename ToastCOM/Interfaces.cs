using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM
{
    [Guid(IIDGuid.INotificationActivationCallback)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface INotificationActivationCallback
    {
        void Activate(
            [MarshalAs(UnmanagedType.LPWStr)] string appUserModelId,
            [MarshalAs(UnmanagedType.LPWStr)] string invokedArgs,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] nint[] data,
            [MarshalAs(UnmanagedType.U4)] uint dataCount
            );
    }

    [GeneratedComInterface]
    [Guid(IIDGuid.IClassFactory)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IClassFactory
    {
        // For HRESULTs use
        [PreserveSig]
        int CreateInstance(nint pUnkOuter,
                           in Guid riid,
                           out nint ppvObject);

        [PreserveSig]
        int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock);
    }

}
