using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.App.Library.Core
{
    public static class Utils
    {
        public static string ConcatUrlPaths(string url1, params string[] urls)
        {
            if (urls.Length > 0)
            {
                string url = url1;
                foreach (string u in urls)
                {
                    url = ConcatUrlPaths(url, u);
                }
                return url;
            }
            else
                return url1;
        }

        public static string ConcatUrlPaths(string url1, string url2)
        {
            if (url1.EndsWith("/") && url2.StartsWith("/"))
                url1 = url1.Substring(0, url1.Length - 1);
            return string.Format("{0}{1}{2}", url1, ((url1.EndsWith("/") || url2.StartsWith("/")) ? "" : "/"), url2);
        }

        public static string GetRelativeWebUrl(string webUrl)
        {
            string webUrlRelative = string.Copy(webUrl);
            if (webUrlRelative.IndexOf("://") > -1)
            {
                webUrlRelative = webUrlRelative.Substring(webUrlRelative.IndexOf("://") + 3);
                if (webUrlRelative.IndexOf("/") > -1)
                    webUrlRelative = webUrlRelative.Substring(webUrlRelative.IndexOf("/"));
            }
            return webUrlRelative;
        }

    }
}