using System;
using System.Xml;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    /// <summary>
    /// Specifies a button shown in a toast.<br/>
    /// <inheritdoc/>
    /// </summary>
    public class ToastAction : ToastCommand
    {
        public required string                        Argument                 { get; set; }
        public required string                        Content                  { get; set; }
        public          Uri?                          ImageUri                 { get; set; }
        public          ToastActivationType?          ActivationType           { get; set; }
        public          ToastAfterActivationBehavior? AfterActivationBehaviour { get; set; }
        public          string?                       HintInputId              { get; set; }
        public          ToastButtonStyle?             HintButtonStyle          { get; set; }
        public          string?                       HintTooltip              { get; set; }

        internal override XmlNode GetXmlNode(XmlDocument rootDocument)
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
