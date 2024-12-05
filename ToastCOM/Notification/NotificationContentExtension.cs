using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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
}
