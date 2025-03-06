using System.Xml;

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    /// <summary>
    /// To see details for all included properties, see this URL:<br/>
    /// <seealso href="https://learn.microsoft.com/en-us/uwp/schemas/tiles/toastschema/element-action#attributes-and-elements"/>
    /// </summary>
    public abstract class ToastCommand
    {
        internal abstract XmlNode GetXmlNode(XmlDocument rootDocument);
    }
}
