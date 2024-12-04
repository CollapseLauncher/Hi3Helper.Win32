﻿using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [Guid(IIDGuid.INotificationActivationCallback)]
    [GeneratedComClass]
    public abstract partial class NotificationActivator : INotificationActivationCallback
    {
        #region Methods
        public void Activate(string appUserModelId, string invokedArgs, nint[] data, uint dataCount)
        {
            OnActivated(invokedArgs, new NotificationUserInput(data), appUserModelId);
        }

        public abstract void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId);

        #endregion
    }
}