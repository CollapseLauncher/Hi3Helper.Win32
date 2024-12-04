using System;

namespace Hi3Helper.Win32.ToastCOM
{
    internal class IIDGuid
    {
        internal const string INotificationActivationCallback = "53E31837-6600-4A81-9395-75CFFE746F94";
    }

    internal class CLSIDGuid
    {
        internal const string Member_NotificationService = "7ddba60f-e2f0-4373-8098-0eafb79ba54a";

        internal static readonly Guid Member_NotificationServiceGuid = new Guid(Member_NotificationService);
    }
}
