using System.Collections.Generic;
using System.Linq;
using System.Xml;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CollectionNeverUpdated.Global

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    /// <summary>
    /// Specifies a combo box / selection input shown in a toast notification.<br/>
    /// <inheritdoc/>
    /// </summary>
    public class ToastComboBox : ToastCommand
    {
        public required string                     Id                  { get; set; }
        public          string?                    PlaceHolderContent  { get; set; }
        public          string?                    Title               { get; set; }
        public          string?                    DefaultSelectionKey { get; set; }
        public          Dictionary<string, string> Selection           { get; set; } = new();

        internal override XmlNode GetXmlNode(XmlDocument rootDocument)
        {
            XmlNode xmlNodeRootElement = rootDocument.CreateElement("input");

            if (Selection.Count != 0 && string.IsNullOrEmpty(DefaultSelectionKey))
            {
                string? firstKey = Selection.Keys.FirstOrDefault();
                if (!string.IsNullOrEmpty(firstKey))
                    DefaultSelectionKey = firstKey;
            }

            if (!string.IsNullOrEmpty(Id))
                xmlNodeRootElement.AddAttribute(rootDocument, "id", Id);

            xmlNodeRootElement.AddAttribute(rootDocument, "type", "selection");

            if (!string.IsNullOrEmpty(DefaultSelectionKey))
                xmlNodeRootElement.AddAttribute(rootDocument, "defaultInput", DefaultSelectionKey);

            if (!string.IsNullOrEmpty(PlaceHolderContent))
                xmlNodeRootElement.AddAttribute(rootDocument, "placeHolderContent", PlaceHolderContent);

            if (!string.IsNullOrEmpty(Title))
                xmlNodeRootElement.AddAttribute(rootDocument, "title", Title);

            foreach (KeyValuePair<string, string> keyValuePair in Selection)
            {
                if (string.IsNullOrEmpty(keyValuePair.Key) || string.IsNullOrEmpty(keyValuePair.Value))
                    continue;

                XmlNode xmlSelectionRootElement = rootDocument.CreateElement("selection");
                xmlSelectionRootElement.AddAttribute(rootDocument, "id", keyValuePair.Key);
                xmlSelectionRootElement.AddAttribute(rootDocument, "content", keyValuePair.Value);

                xmlNodeRootElement.AppendChild(xmlSelectionRootElement);
            }

            return xmlNodeRootElement;
        }
    }
}
