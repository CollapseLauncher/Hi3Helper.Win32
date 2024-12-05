using System;
using System.Xml;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    /// <summary>
    /// To see details for all included properties, see this URL:<br/>
    /// <seealso href="https://learn.microsoft.com/en-us/uwp/schemas/tiles/toastschema/element-action#attributes-and-elements"/>
    /// </summary>
    public class ToastCommand
    {
        public string? Argument { get; set; }
        public string? Content { get; set; }
        public Uri? ImageUri { get; set; }
        public ToastActivationType? ActivationType { get; set; } = ToastActivationType.Foreground;
        public ToastAfterActivationBehavior? AfterActivationBehaviour { get; set; }
        public string? HintInputId { get; set; }
        public ToastButtonStyle? HintButtonStyle { get; set; }
        public string? HintTooltip { get; set; }

        internal XmlNode GetXmlNode(XmlDocument rootDocument)
        {
            XmlNode xmlNodeRootElement = rootDocument.CreateElement("action");

            if (!string.IsNullOrEmpty(Argument))
                xmlNodeRootElement.AddAttribute(rootDocument, "arguments", Argument);

            if (!string.IsNullOrEmpty(Content))
                xmlNodeRootElement.AddAttribute(rootDocument, "content", Content);

            if (ImageUri != null)
                xmlNodeRootElement.AddAttribute(rootDocument, "imageUri", ImageUri.ToString());

            if (ActivationType != null)
                xmlNodeRootElement.AddAttribute(rootDocument, "activationType", ActivationType.Value.ToCamelCaseString());

            if (AfterActivationBehaviour != null)
                xmlNodeRootElement.AddAttribute(rootDocument, "afterActivationBehavior", AfterActivationBehaviour.Value.ToCamelCaseString());

            if (!string.IsNullOrEmpty(HintInputId))
                xmlNodeRootElement.AddAttribute(rootDocument, "hint-inputId", HintInputId);

            if (HintButtonStyle != null)
                xmlNodeRootElement.AddAttribute(rootDocument, "hint-buttonStyle", HintButtonStyle.Value.ToCamelCaseString());

            if (!string.IsNullOrEmpty(HintTooltip))
                xmlNodeRootElement.AddAttribute(rootDocument, "hint-toolTip", HintTooltip);

            return xmlNodeRootElement;
        }
    }
}
