using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [GeneratedComClass]
    public partial class NotificationService : NotificationServiceCallback
    {
        public NotificationService(ILogger? logger = null)
            : base(logger) { }

        protected override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
            base.OnActivated(arguments, userInput, appUserModelId);
        }
    }
}
