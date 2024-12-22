using Hi3Helper.Win32.Native.LibraryImport;
using Microsoft.Extensions.Logging;
using System;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public abstract unsafe class NotificationActivator : INotificationActivationCallback, IDisposable
    {
        #region Properties
        internal ILogger? _logger;
        internal uint     _currentRegisteredClass = 0;
        #endregion

        #region Methods
        protected NotificationActivator(ILogger? logger = null)
        {
            _logger = logger;
        }

        public void Activate(string appUserModelId, string invokedArgs, byte* data, uint dataCount)
        {
            OnActivated(invokedArgs, new NotificationUserInput(data, dataCount, _logger), appUserModelId);
        }

        protected abstract void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId);

        public void Dispose()
        {
            if (_currentRegisteredClass != 0)
            {
                PInvoke.CoRevokeClassObject(_currentRegisteredClass).ThrowOnFailure();
            }
        }
        #endregion
    }
}
