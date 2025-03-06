﻿using Hi3Helper.Win32.Native.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [GeneratedComClass]
    public sealed partial class NotificationService(ILogger? logger = null) : NotificationServiceCallback(logger);
}
