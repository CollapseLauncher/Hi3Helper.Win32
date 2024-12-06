﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Windows.UI.Notifications;
using DomXmlDocument = Windows.Data.Xml.Dom.XmlDocument;
using DomXmlElement = Windows.Data.Xml.Dom.XmlElement;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    /// <summary>
    /// An abstract class inherited by <seealso cref="NotificationService"/>.
    /// Do not use this class to initialize a new instance. Instead, use <seealso cref="NotificationService"/>
    /// </summary>
    /// <param name="logger">Logger of the instance to use</param>
    public abstract class NotificationServiceCallback(ILogger? logger) : NotificationActivator(logger)
    {
        #region Properties
        private DesktopNotificationHistoryCompat? _desktopNotificationHistoryCompat;

        #endregion
        #region Methods

        public void Initialize(string appName, string executablePath, string shortcutPath, Guid? applicationId = null, bool asElevatedUser = false)
        {
            applicationId ??= CLSIDGuid.GetGuidFromString(appName);

            DesktopNotificationManagerCompat.RegisterAumidAndComServer(this, appName, executablePath, shortcutPath, applicationId.Value, asElevatedUser);
            DesktopNotificationManagerCompat.RegisterActivator(this, applicationId.Value);
        }

        public event ToastCallback? ToastCallback;

        protected override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
#if DEBUG
            _logger?.LogDebug($"[NotificationServiceSub::OnActivated] Invoking ToastCallback for application name: {appUserModelId} with argument: {arguments}");
#endif
            Dictionary<string, string?>? inputDataDictionary = null;
            if (userInput != null && userInput.Count > 0)
            {
                inputDataDictionary = new Dictionary<string, string?>();
                foreach (KeyValuePair<string, string?> data in userInput)
                {
#if DEBUG
                    _logger?.LogDebug($"[NotificationServiceSub::OnActivated] Invoking additional data to ToastCallback with key: {data.Key} and data: {data.Value}");
#endif
                    inputDataDictionary.Add(data.Key, data.Value);
                }
            }

            ToastCallback?.Invoke(appUserModelId, arguments, inputDataDictionary);
        }

        protected virtual void OnSetNotifyXML(string xml) { }

        public void ShowNotificationToast(NotificationContent notificationContent)
        {
            XmlDocument? xmlDocument = notificationContent.Xml;
            string xmlDocumentString = xmlDocument?.OuterXml ?? "";

#if DEBUG
            _logger?.LogDebug($"[NotificationServiceSub::ShowNotificationToast] Showing toast using this XML:\r\n{xmlDocumentString}");
#endif

            DomXmlDocument domXmlDocument = new DomXmlDocument();
            domXmlDocument.LoadXml(xmlDocumentString);

            ToastNotification toast = new ToastNotification(domXmlDocument);
            DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        protected void AddInput(DomXmlDocument xml, params ToastAction[] paras)
        {
            DomXmlElement actions = GetAction(xml);

            foreach (var para in paras)
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
            DomXmlElement? actions = null;
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

    public class Test
    {
        public static void TestMethod()
        {
            string processPath = Process.GetCurrentProcess().MainModule?.FileName ?? "";
            NotificationService manager = new NotificationService();

            string appName = "Hi3Helper.Win32 ToastCOM Test";
            manager.Initialize(
                appName,
                processPath,
                Path.Combine("Collapse Launcher Team", appName));

            NotificationContent content = NotificationContent.Create()
                .SetTitle("Welcome to Collapse Launcher!")
                .SetContent("You are currently selecting Honkai: Star Rail - Global as your game. There are more games awaits you, find out more!")
                .SetAppLogoPath(@"Assets\Images/GameLogo\starrail-logo.png", true)
                .SetAppHeroImagePath(@"Assets\Images\GamePoster/poster_starrail.png");

            content.Duration = ToastDuration.Short;

            manager.ShowNotificationToast(content);
        }
    }
}
