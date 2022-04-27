using System.Web.Mvc;

namespace EydapTickets.Areas.Reporting
{
    public class ReportingAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Reporting";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ReportingHome",
                "Reporting/Home/{action}/{id}",
                new { controller = "Reports", action = "Index", id = UrlParameter.Optional },
                new [] { "EydapTickets.Areas.Reporting.Controllers" }
            );

            context.MapRoute(
                "Reporting",
                "Reporting/{controller}/{action}/{id}",
                new { controller = "Reports", action = "Index", id = UrlParameter.Optional },
                new [] { "EydapTickets.Areas.Reporting.Controllers" }
            );
        }
    }
}