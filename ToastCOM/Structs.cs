using Hi3Helper.Win32.ToastCOM.Notification;
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace Hi3Helper.Win32.ToastCOM
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NOTIFICATION_USER_INPUT_DATA
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Key;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string Value;
    }

    /// <summary>
    /// To see details for all included properties, see this URL:<br/>
    /// <seealso href="https://learn.microsoft.com/en-us/uwp/schemas/tiles/toastschema/element-action#attributes-and-elements"/>
    /// </summary>
    public class ToastCommand
    {
        public string? Argument { get; set; }
        public string? Content { get; set; }
        public Uri? ImageUri { get; set; }
        public ToastActivationType? ActivationType { get; set; }
        public ToastAfterActivationBehavior? AfterActivationBehaviour { get; set; }
        public string? HintInputId { get; set; }
        public ToastButtonStyle? HintButtonStyle { get; set; }
        public string? HintTooltip { get; set; }

        internal XmlNode GetXmlNode()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNodeRootElement = xmlDocument.CreateElement("action");

            if (!string.IsNullOrEmpty(Argument))
                xmlNodeRootElement.AddAttribute(xmlDocument, "argument", Argument);

            if (!string.IsNullOrEmpty(Content))
                xmlNodeRootElement.AddAttribute(xmlDocument, "content", Content);

            if (ImageUri != null)
                xmlNodeRootElement.AddAttribute(xmlDocument, "imageUri", ImageUri.ToString());

            if (ActivationType != null)
                xmlNodeRootElement.AddAttribute(xmlDocument, "activationType", ActivationType.Value.ToCamelCaseString());

            if (AfterActivationBehaviour != null)
                xmlNodeRootElement.AddAttribute(xmlDocument, "afterActivationBehavior", AfterActivationBehaviour.Value.ToCamelCaseString());

            if (!string.IsNullOrEmpty(HintInputId))
                xmlNodeRootElement.AddAttribute(xmlDocument, "hint-inputId", HintInputId);

            if (HintButtonStyle != null)
                xmlNodeRootElement.AddAttribute(xmlDocument, "hint-buttonStyle", HintButtonStyle.Value.ToCamelCaseString());

            if (!string.IsNullOrEmpty(HintTooltip))
                xmlNodeRootElement.AddAttribute(xmlDocument, "hint-toolTip", HintTooltip);

            return xmlDocument;
        }
    }

    public enum ToastActivationType
    {
        Foreground,
        Background,
        Protocol
    }

    public enum ToastAfterActivationBehavior
    {
        Default,
        PendingUpdate
    }

    public enum ToastButtonStyle
    {
        Success,
        Critical
    }

    public enum ToastDuration
    {
        Long,
        Short
    }

    public enum ToastScenario
    {
        Reminder,
        Alarm,
        IncomingCall,
        Urgent
    }
}
