using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Xml;
using Windows.UI.Notifications;
using DomXmlDocument = Windows.Data.Xml.Dom.XmlDocument;
using DomXmlElement = Windows.Data.Xml.Dom.XmlElement;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.ToastCOM.Notification
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

        public Guid Initialize(string appName, string executablePath, string shortcutPath, Guid? applicationId = null, bool asElevatedUser = false)
        {
            applicationId ??= ClsidGuid.GetGuidFromString(appName);

            DesktopNotificationManagerCompat.RegisterAumidAndComServer(this, appName, executablePath, shortcutPath, applicationId.Value, asElevatedUser);
            DesktopNotificationManagerCompat.RegisterActivator(this, applicationId.Value, asElevatedUser);

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

            DomXmlDocument domXmlDocument = new DomXmlDocument();
            domXmlDocument.LoadXml(xmlDocumentString);

            ToastNotification toast = new ToastNotification(domXmlDocument);
            toast.Tag = Guid.CreateVersion7().ToString();
            return toast;
        }

        public ToastNotifier CreateToastNotifier()
            => DesktopNotificationManagerCompat.CreateToastNotifier();

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
                .AddAppHeroImagePath(@"Assets\Images\GamePoster/poster_starrail.png");

            content.Duration = ToastDuration.Short;

            ToastNotification toastNotification = manager.CreateToastNotification(content);
            ToastNotifier toastNotifier = manager.CreateToastNotifier();
            toastNotifier.Show(toastNotification);
        }
    }
}
