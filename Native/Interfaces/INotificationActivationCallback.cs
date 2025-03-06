using Hi3Helper.Win32.Native.ClassIds;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(NotificationClsId.NotificationActivationCallback)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(Options = ComInterfaceOptions.ManagedObjectWrapper | ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
    [ComVisible(true)]
    public partial interface INotificationActivationCallback
    {
        unsafe void Activate(
            string appUserModelId,
            string invokedArgs,
            byte*  data,
            uint   dataCount
        );
    }
}
