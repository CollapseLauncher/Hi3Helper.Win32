using System.Xml;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    /// <summary>
    /// Specifies a text box input shown in a toast notification.<br/>
    /// <inheritdoc/>
    /// </summary>
    public class ToastTextBox : ToastCommand
    {
        public required string  Id                 { get; set; }
        public          string? PlaceHolderContent { get; set; }
        public          string? Title              { get; set; }

        internal override XmlNode GetXmlNode(XmlDocument rootDocument)
        {
            XmlNode xmlNodeRootElement = rootDocument.CreateElement("input");

            xmlNodeRootElement.AddAttribute(rootDocument, "type", "text");

            if (!string.IsNullOrEmpty(Id))
                xmlNodeRootElement.AddAttribute(rootDocument, "id", Id);

            if (!string.IsNullOrEmpty(PlaceHolderContent))
                xmlNodeRootElement.AddAttribute(rootDocument, "placeHolderContent", PlaceHolderContent);

            if (!string.IsNullOrEmpty(Title))
                xmlNodeRootElement.AddAttribute(rootDocument, "title", Title);

            return xmlNodeRootElement;
        }
    }
}
