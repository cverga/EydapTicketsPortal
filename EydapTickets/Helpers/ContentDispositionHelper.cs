using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevExpress.Web.Internal;

namespace EydapTickets.Helpers
{
    public static class ContentDispositionHelper
    {
        private static readonly Dictionary<char, char> AndroidAllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ._-+,@£$€!½§~'=()[]{}0123456789".ToDictionary(c => c);

        /// <summary>
        /// Create a content disposition object for an attachment.
        /// </summary>
        /// <param name="request">The current http request.</param>
        /// <param name="fileName"></param>
        /// <param name="inline"> a <see cref="T:System.Boolean" /> value that determines the disposition type (Inline or Attachment) for the attachment.</param>
        /// <returns></returns>
        public static ContentDisposition CreateAttachmentContentDisposition(HttpRequestBase request, string fileName, bool inline = false)
        {
            var contentDisposition = new ContentDisposition()
            {
                Inline = inline,
            };

            if (request.Browser.Browser == "IE" && (request.Browser.Version == "7.0" || request.Browser.Version == "8.0"))
            {
                contentDisposition.FileName = Uri.EscapeDataString(fileName);
            }
            else if (request.UserAgent != null && request.UserAgent.ToLowerInvariant().Contains("android")) // android built-in download manager (all browsers on android)
            {
                contentDisposition.FileName = $"\"{MakeAndroidSafeFileName(fileName)}\"";
            }
            else
            {
                contentDisposition.FileName = $"\"{fileName}\"";
                contentDisposition.Parameters.Add("filename*", "UTF-8''" + Uri.EscapeDataString(fileName));
            }

            return contentDisposition;
        }

        private static string MakeAndroidSafeFileName(string fileName)
        {
            var newFileName = fileName.ToCharArray();
            for (var i = 0; i < newFileName.Length; i++)
            {
                if (!AndroidAllowedChars.ContainsKey(newFileName[i]))
                {
                    newFileName[i] = '_';
                }
            }
            return new string(newFileName);
        }
    }
}
