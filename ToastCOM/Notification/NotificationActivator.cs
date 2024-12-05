using Microsoft.Extensions.Logging;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public unsafe abstract partial class NotificationActivator : INotificationActivationCallback
    {
        #region Properties
        internal ILogger? _logger;
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

        #endregion
    }
}
