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
}
