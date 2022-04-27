using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using DevExpress.Web;
using DevExpress.Web.Mvc;
using DevExpress.XtraReports.Security; // 31.03.2018, Andreas Kasapleris

namespace EydapTickets
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // 31.03.2018, Andreas Kasapleris
            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Unrestricted);

            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default;

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //AuthConfig.RegisterAuth();

            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();

            ApplicationInsightsConfig.Configure();

            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            razorEngine.ViewLocationFormats =
            razorEngine.ViewLocationFormats.Concat(new string[] {
                "~/Home/{1}/{0}.cshtml",
                "~/Home/{0}.cshtml"
                // add other folders here (if any)
            }).ToArray();

            ASPxWebControl.CallbackError += Application_Error;
            MVCxWebDocumentViewer.StaticInitialize();

            // 18.10.2018, SQL Server Type Support for Microsoft Report Viewer 14
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
        }

        protected void Application_PreRequestHandlerExecute()
        {
            DevExpressHelper.Theme = "Office365";
            DevExpressHelper.GlobalThemeBaseColor = "#013974";
            DevExpressHelper.GlobalThemeFont = "14px 'Segoe UI', Helvetica, 'Droid Sans', Tahoma, Geneva, sans-serif";
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}