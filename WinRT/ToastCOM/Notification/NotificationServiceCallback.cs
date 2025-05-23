using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Xml;
using Windows.UI.Notifications;
using DomXmlDocument = Windows.Data.Xml.Dom.XmlDocument;
using DomXmlElement = Windows.Data.Xml.Dom.XmlElement;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    /// <summary>
    /// An abstract class inherited by <seealso cref="NotificationService"/>.
    /// Do not use this class to initialize a new instance. Instead, use <seealso cref="NotificationService"/>
    /// </summary>
    /// <param name="logger">Logger of the instance to use</param>
    [GeneratedComClass]
    public abstract partial class NotificationServiceCallback(ILogger? logger) : NotificationActivator(logger)
    {
        #region Properties
        private DesktopNotificationHistoryCompat? _desktopNotificationHistoryCompat;
        #endregion

        #region Methods
        public Guid Initialize(string appName, string executablePath, string shortcutPath, Guid? applicationId = null, string? toastIconPngPath = null)
        {
            applicationId ??= Extensions.GetGuidFromString(appName);

            DesktopNotificationManagerCompat.RegisterAumidAndComServer(this, appName, executablePath, shortcutPath, toastIconPngPath, applicationId.Value);
            DesktopNotificationManagerCompat.RegisterActivator(this, applicationId.Value);

            return applicationId.Value;
        }

        public event ToastCallback? ToastCallback;

        protected override void OnActivated(string arguments, NotificationUserInput? userInput, string appUserModelId)
        {
#if DEBUG
            Logger?.LogDebug($"[NotificationServiceSub::OnActivated] Invoking ToastCallback for application name: {appUserModelId} with argument: {arguments}");
#endif
            Dictionary<string, string?>? inputDataDictionary = null;
            if (userInput is { Count: > 0 })
            {
                inputDataDictionary = new Dictionary<string, string?>();
                foreach (KeyValuePair<string?, string?> data in userInput)
                {
#if DEBUG
                    Logger?.LogDebug($"[NotificationServiceSub::OnActivated] Invoking additional data to ToastCallback with key: {data.Key} and data: {data.Value}");
#endif
                    inputDataDictionary.TryAdd(data.Key ?? "", data.Value);
                }
            }

            ToastCallback?.Invoke(appUserModelId, arguments, inputDataDictionary);
        }

        protected virtual void OnSetNotifyXML(string xml) { }

        public ToastNotification CreateToastNotification(NotificationContent notificationContent)
        {
            XmlDocument xmlDocument = notificationContent.Xml;
            string xmlDocumentString = xmlDocument.OuterXml;

#if DEBUG
            Logger?.LogDebug($"[NotificationServiceSub::ShowNotificationToast] Showing toast using this XML:\r\n{xmlDocumentString}");
#endif

            DomXmlDocument domXmlDocument = new();
            domXmlDocument.LoadXml(xmlDocumentString);

            ToastNotification toast = new(domXmlDocument)
            {
                Tag = Guid.CreateVersion7().ToString()
            };
            return toast;
        }

        public ToastNotifier? CreateToastNotifier(bool throwOnFault =
#if DEBUG
            true
#else
            false
#endif
            )
            => DesktopNotificationManagerCompat.CreateToastNotifier(Logger, throwOnFault);

        protected void AddInput(DomXmlDocument xml, params ToastAction[] paras)
        {
            DomXmlElement actions = GetAction(xml);

            foreach (ToastAction? para in paras)
            {
                DomXmlElement input = xml.CreateElement("input");
                input.SetAttribute("type", "text");
                input.SetAttribute("id", para.Argument);
                input.SetAttribute("placeHolderContent", para.Content);
                actions?.AppendChild(input);
            }
        }

        private DomXmlElement GetAction(DomXmlDocument xml)
        {
            DomXmlElement? actions;
            if (xml.GetElementsByTagName("actions").Count != 0)
                actions = (DomXmlElement)xml.GetElementsByTagName("actions")[0];
            else
            {
                actions = xml.CreateElement("actions");
                ((DomXmlElement)xml.GetElementsByTagName("toast")[0]).AppendChild(actions);
            }
            return actions;
        }

        public void ClearHistory(string appid)
        {
            _desktopNotificationHistoryCompat ??= new DesktopNotificationHistoryCompat(appid);
            _desktopNotificationHistoryCompat?.Clear();
        }
#endregion
    }
}
