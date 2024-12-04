using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [Guid(CLSIDGuid.Member_NotificationService)]
    [GeneratedComClass]
    public partial class NotificationService : NotificationActivator
    {
        #region Properties
        private static ToastNotifier? _toastNotifier;
        private static DesktopNotificationHistoryCompat? _desktopNotificationHistoryCompat;
        #endregion

        #region Methods
        public void Init(string appid)
        {
            DesktopNotificationManagerCompat.RegisterAumidAndComServer(appid);
            DesktopNotificationManagerCompat.RegisterActivator();
        }

        public static event ToastAction? ToastCallback;

        public override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
            List<KeyValuePair<string, string?>> kvs = new List<KeyValuePair<string, string?>>();
            if (userInput != null && userInput.Count > 0)
                foreach (var key in userInput.Keys)
                {
                    kvs.Add(new KeyValuePair<string, string?>(key, userInput[key]));
                }
            ToastCallback?.Invoke(appUserModelId, arguments, kvs);
        }

        public void Notify()
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            ShowToast(xml);
        }

        protected virtual void OnSetNotifyXML(string xml) { }

        public void Notify(string title, string content)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            AddTitle(xml, title, content);
            ShowToast(xml);
        }

        public void Notify(string title, string content, params ToastCommands[] commands)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            AddTitle(xml, title, content);
            AddCommands(xml, commands);
            ShowToast(xml);
        }

        public void Notify(string picuri, string pic, string title, string content)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            AddTitle(xml, title, content);
            AddBigLogo(xml, picuri);
            AddBigPicture(xml, pic);
            ShowToast(xml);
        }

        public void Notify(string picuri, string title, string content, params ToastCommands[] commands)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            AddTitle(xml, title, content);
            AddBigLogo(xml, picuri);
            AddCommands(xml, commands);
            ShowToast(xml);
        }

        public void Notify(string title, string content, ToastCommands[] paras, ToastCommands[] commands)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            AddTitle(xml, title, content);
            AddInput(xml, paras);
            AddCommands(xml, commands);
            ShowToast(xml);
        }

        protected static void ShowToast(XmlDocument xml)
        {
            ToastNotification toast = new ToastNotification(xml);
            _toastNotifier ??= DesktopNotificationManagerCompat.CreateToastNotifier();
            _toastNotifier?.Show(toast);
        }

        protected static void AddTitle(XmlDocument xml, string title, string content)
        {
            XmlNodeList lines = xml.GetElementsByTagName("text");
            lines[0].AppendChild(xml.CreateTextNode(title));
            lines[1].AppendChild(xml.CreateTextNode(content));
        }

        protected static void AddCommands(XmlDocument xml, params ToastCommands[] commands)
        {
            XmlElement actions = GetAction(xml);

            foreach (var command in commands)
            {
                XmlElement action = xml.CreateElement("action");
                action.SetAttribute("activationType", "foreground");
                action.SetAttribute("arguments", command.Argument);
                action.SetAttribute("content", command.Content);
                actions.AppendChild(action);
            }
        }

        protected static void AddInput(XmlDocument xml, params ToastCommands[] paras)
        {
            XmlElement actions = GetAction(xml);

            foreach (var para in paras)
            {
                XmlElement input = xml.CreateElement("input");
                input.SetAttribute("type", "text");
                input.SetAttribute("id", para.Argument);
                input.SetAttribute("placeHolderContent", para.Content);
                actions?.AppendChild(input);
            }
        }

        protected static void AddBigLogo(XmlDocument xml, string logopath)
        {
            XmlElement binding = (XmlElement)xml.GetElementsByTagName("binding")[0];
            binding.SetAttribute("template", "ToastGeneric");
            XmlElement image = xml.CreateElement("image");
            image.SetAttribute("placement", "appLogoOverride");
            image.SetAttribute("src", logopath);
            binding.AppendChild(image);
        }

        protected static void AddBigPicture(XmlDocument xml, string picture)
        {
            XmlElement binding = (XmlElement)xml.GetElementsByTagName("binding")[0];
            binding.SetAttribute("template", "ToastGeneric");
            XmlElement image = xml.CreateElement("image");
            image.SetAttribute("placement", "hero");
            image.SetAttribute("src", picture);
            binding.AppendChild(image);
        }

        private static XmlElement GetAction(XmlDocument xml)
        {
            XmlElement? actions = null;
            if (xml.GetElementsByTagName("actions").Count != 0)
                actions = (XmlElement)xml.GetElementsByTagName("actions")[0];
            else
            {
                actions = xml.CreateElement("actions");
                ((XmlElement)xml.GetElementsByTagName("toast")[0]).AppendChild(actions);
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
            NotificationService manager = new NotificationService();
            manager.Init("Collapse Launcher");
            manager.Notify(
                "file:///file:///E:/myGit/Collapse/CollapseLauncher/Assets/Images/GameLogo/starrail-logo.png",
                "file:///E:/myGit/Collapse/CollapseLauncher/Assets/Images/GamePoster/poster_starrail.png",
                "Welcome to Collapse Launcher!",
                "Thank you for installing Collapse Launcher. You are currently selecting Honkai: Star Rail - Global as your game. There are more games awaits you, find out more!");
        }
    }
}
