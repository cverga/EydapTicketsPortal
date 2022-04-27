using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Core
{
    public static class HtmlExtensions
    {
        public static System.Web.Mvc.MvcHtmlString CustomActionLink(this System.Web.Mvc.HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string wrapHtmlLinkText, object routeValues, object htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("String is null or empty", "linkText");
            }
            System.Web.Routing.RouteValueDictionary route = null;
            if (routeValues != null)
                route = new System.Web.Routing.RouteValueDictionary(routeValues);

            string html = System.Web.Mvc.HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, route, System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            // <a href="/[Controller]">[LinkText]</a>

            html = html.Replace(">" + linkText, string.Format(">" + wrapHtmlLinkText, linkText));
            System.Web.Mvc.MvcHtmlString mvcString = System.Web.Mvc.MvcHtmlString.Create(html);

            return mvcString;
        }
    }
}
