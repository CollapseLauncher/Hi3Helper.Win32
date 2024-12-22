using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM
{
    [Guid(IIDGuid.INotificationActivationCallback)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(Options = ComInterfaceOptions.ManagedObjectWrapper | ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
    [ComVisible(true)]
    public partial interface INotificationActivationCallback
    {
        unsafe void Activate(
            string appUserModelId,
            string invokedArgs,
            byte* data,
            uint dataCount
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
