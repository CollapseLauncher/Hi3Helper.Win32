using Hi3Helper.Win32.Native.LibraryImport;
using Microsoft.Extensions.Logging;
using System;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public abstract unsafe class NotificationActivator(ILogger? logger = null)
        : INotificationActivationCallback, IDisposable
    {
        #region Properties
        internal ILogger? Logger                 = logger;
        internal uint     CurrentRegisteredClass = 0;
        #endregion

        #region Methods

        public void Activate(string appUserModelId, string invokedArgs, byte* data, uint dataCount)
        {
            OnActivated(invokedArgs, new NotificationUserInput(data, dataCount, Logger), appUserModelId);
        }

        protected abstract void OnActivated(string arguments, NotificationUserInput? userInput, string appUserModelId);

        public void Dispose()
        {
            if (CurrentRegisteredClass != 0)
            {
                PInvoke.CoRevokeClassObject(CurrentRegisteredClass).ThrowOnFailure();
            }
        }
        #endregion
    }
}
