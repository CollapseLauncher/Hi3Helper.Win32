using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(NotificationClsId.NotificationActivationCallback)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface INotificationActivationCallback
{
    unsafe void Activate(
        string appUserModelId,
        string invokedArgs,
        byte*  data,
        uint   dataCount
    );
}