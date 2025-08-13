using System.Collections.Generic;
using Windows.UI.Notifications;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    internal class DesktopNotificationHistoryCompat
    {
        #region Properties
        private readonly string                   _aumId;
        private readonly ToastNotificationHistory _history;

        /// <summary>
        /// Do not call this. Instead, call <see cref="DesktopNotificationManagerCompat.History"/> to obtain an instance.
        /// </summary>
        /// <param name="aumId"></param>
        public DesktopNotificationHistoryCompat(string aumId)
        {
            _aumId = aumId;
            _history = ToastNotificationManager.History;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Removes all notifications sent by this app from action center.
        /// </summary>
        public void Clear()
        {
            _history.Clear(_aumId);
        }

        /// <summary>
        /// Gets all notifications sent by this app that are currently still in Action Center.
        /// </summary>
        /// <returns>A collection of toasts.</returns>
        public IReadOnlyList<ToastNotification> GetHistory()
        {
            return _history.GetHistory(_aumId);
        }

        /// <summary>
        /// Removes an individual toast, with the specified tag label, from action center.
        /// </summary>
        /// <param name="tag">The tag label of the toast notification to be removed.</param>
        public void Remove(string tag)
        {
            _history.Remove(tag, string.Empty, _aumId);
        }

        /// <summary>
        /// Removes a toast notification from the action using the notification's tag and group labels.
        /// </summary>
        /// <param name="tag">The tag label of the toast notification to be removed.</param>
        /// <param name="group">The group label of the toast notification to be removed.</param>
        public void Remove(string tag, string group)
        {
            _history.Remove(tag, group, _aumId);
        }

        /// <summary>
        /// Removes a group of toast notifications, identified by the specified group label, from action center.
        /// </summary>
        /// <param name="group">The group label of the toast notifications to be removed.</param>
        public void RemoveGroup(string group)
        {
            _history.RemoveGroup(group, _aumId);
        }
        #endregion
    }
}
