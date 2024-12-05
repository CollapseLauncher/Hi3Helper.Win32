using System;
using System.Collections.Generic;
using System.Xml;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
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

        private XmlDocument? _xml;
        public XmlDocument? Xml
        {
            get => GenerateXmlDocument();
        }

        public static NotificationContent Create() => new NotificationContent();

        public void UpdateXml(XmlDocument xml) => _xml = xml;

        private XmlDocument GenerateXmlDocument()
        {
            // If the inner xml is already generated, return
            if (_xml != null)
                return _xml;

            // Create root visual element
            _xml = new XmlDocument();
            XmlNode? xmlToastRootElement = _xml.AppendChild(CreateToastElement(_xml));
            XmlNode? xmlVisualElement = xmlToastRootElement?.AppendChild(_xml.CreateElement("visual"));

            // Create binding element for messages
            XmlNode? xmlBindingElement = xmlVisualElement?.AppendChild(_xml.CreateElement("binding"));
            xmlBindingElement.AddAttribute(_xml, "template", "ToastGeneric");

            // If binding element is successfully created
            if (xmlBindingElement != null)
            {
                // Append Title if any
                if (!string.IsNullOrEmpty(Title))
                {
                    XmlNode? xmlTitleElement = xmlBindingElement.AppendChild(_xml.CreateElement("text"));
                    xmlTitleElement?.AppendChild(_xml.CreateTextNode(Title));
                }

                // Append Content if any
                if (!string.IsNullOrEmpty(Content))
                {
                    XmlNode? xmlContentElement = xmlBindingElement.AppendChild(_xml.CreateElement("text"));
                    xmlContentElement?.AppendChild(_xml.CreateTextNode(Content));
                }

                // Append App Logo if any
                if (AppLogo != null)
                {
                    XmlNode? xmlAppLogoElement = xmlBindingElement.AppendChild(_xml.CreateElement("image"));
                    xmlAppLogoElement.AddAttribute(_xml, "src", AppLogo.ToString());
                    xmlAppLogoElement.AddAttribute(_xml, "placement", "appLogoOverride");

                    // If circle crop is being used, add hint-crop attribute
                    if (UseCircleCroppedAppLogo)
                        xmlAppLogoElement.AddAttribute(_xml, "hint-crop", "circle");
                }

                // Append Hero Image if any
                if (AppHeroImage != null)
                {
                    XmlNode? xmlAppLogoElement = xmlBindingElement.AppendChild(_xml.CreateElement("image"));
                    xmlAppLogoElement.AddAttribute(_xml, "src", AppHeroImage.ToString());
                    xmlAppLogoElement.AddAttribute(_xml, "placement", "hero");
                }
            }

            // If ToastCommands is not empty, add actions
            if (ToastCommands.Count != 0)
            {
                XmlNode? xmlActionsElement = xmlToastRootElement?.AppendChild(_xml.CreateElement("actions"));
                if (xmlActionsElement != null)
                {
                    // Enumerate and create command action
                    foreach (ToastCommand toastCommand in ToastCommands)
                    {
                        xmlActionsElement.AppendChild(toastCommand.GetXmlNode(_xml));
                    }
                }
            }

            return _xml;
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
}
