using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Xml;
using Windows.UI.Notifications;
using DomXmlDocument = Windows.Data.Xml.Dom.XmlDocument;
using DomXmlElement = Windows.Data.Xml.Dom.XmlElement;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public static class NotificationContentExtension
    {
        public static NotificationContent SetTitle(this NotificationContent content, string? title)
        {
            content.Title = title;
            return content;
        }

        public static NotificationContent SetContent(this NotificationContent content, string? contentString)
        {
            content.Content = contentString;
            return content;
        }

        public static NotificationContent SetAppLogoPath(this NotificationContent content, string? appLogoUriOrPath, bool isUseCircleCropped = false)
            => content.SetAppLogoPath(CreateUrlFromString(appLogoUriOrPath), isUseCircleCropped);

        public static NotificationContent SetAppLogoPath(this NotificationContent content, Uri? appLogoUri, bool isUseCircleCropped = false)
        {
            content.AppLogo = appLogoUri;
            content.UseCircleCroppedAppLogo = isUseCircleCropped;
            return content;
        }

        public static NotificationContent SetAppHeroImagePath(this NotificationContent content, string? heroImageUriOrPath)
            => content.SetAppHeroImagePath(CreateUrlFromString(heroImageUriOrPath));

        public static NotificationContent SetAppHeroImagePath(this NotificationContent content, Uri? heroImageUri)
        {
            content.AppHeroImage = heroImageUri;
            return content;
        }

        public static List<ToastCommand> GetToastCommandList(this NotificationContent content)
            => content.ToastCommands;

        private static Uri? CreateUrlFromString(string? rawUrlString)
        {
            const string pathSchemeHttp = "http://";
            const string pathSchemeHttps = "https://";
            const string pathSchemeFileNetwork = "file://";
            const string pathSchemeFileLocal = pathSchemeFileNetwork + "/";

            // Return null if empty
            if (string.IsNullOrEmpty(rawUrlString))
                return null;

            // If the string is already a valid local URL, return
            bool isUnc = rawUrlString.StartsWith(pathSchemeFileNetwork, StringComparison.OrdinalIgnoreCase);
            bool isLocal = rawUrlString.StartsWith(pathSchemeFileLocal, StringComparison.OrdinalIgnoreCase);
            if (isLocal)
            {
                ReadOnlySpan<char> localTrimmedPath = rawUrlString.AsSpan().TrimStart(pathSchemeFileLocal);
                string localNormalized = localTrimmedPath.ToString();
                return new Uri(localNormalized);
            }

            // If the string is already a valid UNC URL, return
            if (isUnc)
            {
                ReadOnlySpan<char> uncTrimmedPath = rawUrlString.AsSpan().TrimStart(pathSchemeFileNetwork);
                string uncNormalized = @"\\" + uncTrimmedPath.ToString().Replace('/', '\\');
                return new Uri(uncNormalized, UriKind.Absolute);
            }

            StartParsing:
            // Try create the url
            if (Uri.TryCreate(rawUrlString, UriKind.Absolute, out Uri? appLogoAsUri))
            {
                string absoluteUri = appLogoAsUri.AbsoluteUri;

                // If it's a not valid URL (scheme is not supported), then throw
                if (!(absoluteUri.StartsWith(pathSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                      absoluteUri.StartsWith(pathSchemeHttps, StringComparison.OrdinalIgnoreCase) ||
                      absoluteUri.StartsWith(pathSchemeFileNetwork, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException($"Only URL with {pathSchemeHttp}, {pathSchemeHttps}, {pathSchemeFileNetwork} (UNC) or {pathSchemeFileNetwork}/ (Local Path) is supported.");
                }

                // Otherwise, return the path
                return appLogoAsUri;
            }

            // If it fails to create the string, try get the path from relative
            // and start parsing
            rawUrlString = Path.GetFullPath(rawUrlString);
            goto StartParsing;
        }

        internal static void AddAttribute(this XmlNode? node, XmlDocument rootXml, string name, string value)
        {
            if (node == null)
                return;

            XmlAttribute? attribute = node.Attributes?.Append(rootXml.CreateAttribute(name));
            if (attribute == null)
                return;

            attribute.Value = value;
        }

        internal static string ToCamelCaseString<TEnum>(this TEnum enumValue)
            where TEnum : struct, Enum
        {
            ReadOnlySpan<char> value = enumValue.ToString();
            Span<char> returnValue = stackalloc char[value.Length];

            value.CopyTo(returnValue);
            returnValue[0] = char.ToLower(value[0]);

            return new string(returnValue);
        }
    }

    public class NotificationContent
    {
        public string? Title { get; internal set; }
        public string? Content { get; internal set; }
        public Uri? AppLogo { get; internal set; }
        public Uri? AppHeroImage { get; internal set; }
        public bool UseCircleCroppedAppLogo { get; internal set; }
        public List<ToastCommand> ToastCommands { get; internal set; } = new List<ToastCommand>();
        public string? Launch { get; set; }
        public ToastDuration? Duration { get; set; }
        public string? DisplayTimestamp { get; set; }
        public ToastScenario? Scenario { get; set; }
        public bool? UseButtonStyle { get; set; }

        public static NotificationContent Create() => new NotificationContent();
        public XmlDocument GetXmlDocument()
        {
            // Create root visual element
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode? xmlToastRootElement = xmlDocument.AppendChild(CreateToastElement(xmlDocument));
            XmlNode? xmlVisualElement = xmlToastRootElement?.AppendChild(xmlDocument.CreateElement("visual"));

            // Create binding element for messages
            XmlNode? xmlBindingElement = xmlVisualElement?.AppendChild(xmlDocument.CreateElement("binding"));
            xmlBindingElement.AddAttribute(xmlDocument, "template", "ToastGeneric");

            // If binding element is successfully created
            if (xmlBindingElement != null)
            {
                // Append Title if any
                if (!string.IsNullOrEmpty(Title))
                {
                    XmlNode? xmlTitleElement = xmlBindingElement.AppendChild(xmlDocument.CreateElement("text"));
                    xmlTitleElement?.AppendChild(xmlDocument.CreateTextNode(Title));
                }

                // Append Content if any
                if (!string.IsNullOrEmpty(Content))
                {
                    XmlNode? xmlContentElement = xmlBindingElement.AppendChild(xmlDocument.CreateElement("text"));
                    xmlContentElement?.AppendChild(xmlDocument.CreateTextNode(Content));
                }

                // Append App Logo if any
                if (AppLogo != null)
                {
                    XmlNode? xmlAppLogoElement = xmlBindingElement.AppendChild(xmlDocument.CreateElement("image"));
                    xmlAppLogoElement.AddAttribute(xmlDocument, "src", AppLogo.ToString());
                    xmlAppLogoElement.AddAttribute(xmlDocument, "placement", "appLogoOverride");

                    // If circle crop is being used, add hint-crop attribute
                    if (UseCircleCroppedAppLogo)
                        xmlAppLogoElement.AddAttribute(xmlDocument, "hint-crop", "circle");
                }

                // Append Hero Image if any
                if (AppHeroImage != null)
                {
                    XmlNode? xmlAppLogoElement = xmlBindingElement.AppendChild(xmlDocument.CreateElement("image"));
                    xmlAppLogoElement.AddAttribute(xmlDocument, "src", AppHeroImage.ToString());
                    xmlAppLogoElement.AddAttribute(xmlDocument, "placement", "hero");
                }
            }

            // If ToastCommands is not empty, add actions
            if (ToastCommands.Count != 0)
            {
                XmlNode? xmlActionsElement = xmlToastRootElement?.AppendChild(xmlDocument.CreateElement("actions"));
                if (xmlActionsElement != null)
                {
                    // Enumerate and create command action
                    foreach (ToastCommand toastCommand in ToastCommands)
                    {
                        xmlActionsElement.AppendChild(toastCommand.GetXmlNode());
                    }
                }
            }

            return xmlDocument;
        }

        private XmlNode CreateToastElement(XmlDocument rootXml)
        {
            XmlNode xmlToastRootElement = rootXml.CreateElement("toast");

            if (!string.IsNullOrEmpty(Launch))
                xmlToastRootElement.AddAttribute(rootXml, "launch", Launch);

            if (Duration != null)
                xmlToastRootElement.AddAttribute(rootXml, "duration", Duration.Value.ToCamelCaseString());

            if (!string.IsNullOrEmpty(DisplayTimestamp))
                xmlToastRootElement.AddAttribute(rootXml, "displayTimeStamp", DisplayTimestamp);

            if (Scenario != null)
                xmlToastRootElement.AddAttribute(rootXml, "scenario", Scenario.Value.ToCamelCaseString());

            if (UseButtonStyle != null)
                xmlToastRootElement.AddAttribute(rootXml, "useButtonStyle", $"{UseButtonStyle}");

            return xmlToastRootElement;
        }
    }

    [Guid(CLSIDGuid.Member_NotificationService)]
    [GeneratedComClass]
    public partial class NotificationService : NotificationActivator
    {
        #region Properties
        private ToastNotifier? _toastNotifier;
        private DesktopNotificationHistoryCompat? _desktopNotificationHistoryCompat;
        #endregion

        #region Methods
        public void Init(string appid)
        {
            DesktopNotificationManagerCompat.RegisterAumidAndComServer(appid);
            DesktopNotificationManagerCompat.RegisterActivator();
        }

        public event ToastAction? ToastCallback;

        public override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
            List<KeyValuePair<string, string?>> kvs = new List<KeyValuePair<string, string?>>();
            if (userInput != null && userInput.Count > 0)
            {
                foreach (var key in userInput.Keys)
                {
                    kvs.Add(new KeyValuePair<string, string?>(key, userInput[key]));
                }
            }

            ToastCallback?.Invoke(appUserModelId, arguments, kvs);
        }

        protected virtual void OnSetNotifyXML(string xml) { }

        public void ShowNotificationToast(NotificationContent notificationContent)
        {
            XmlDocument xmlDocument = notificationContent.GetXmlDocument();
            string xmlDocumentString = xmlDocument.OuterXml;

            DomXmlDocument domXmlDocument = new DomXmlDocument();
            domXmlDocument.LoadXml(xmlDocumentString);

            ToastNotification toast = new ToastNotification(domXmlDocument);
            _toastNotifier ??= DesktopNotificationManagerCompat.CreateToastNotifier();
            _toastNotifier?.Show(toast);
        }

        protected void AddInput(DomXmlDocument xml, params ToastCommand[] paras)
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
            NotificationService manager = new NotificationService();
            manager.Init("Collapse Launcher");

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
