using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EydapTickets.Models;
using Microsoft.Reporting.WebForms;

namespace EydapTickets.Controllers
{
    [Authorize]
    public class SSRSController : BaseController
    {
        /// <summary>Gets the SQL Server Reporting Services Url.</summary>
        /// <returns>The report server url.</returns>
        private static string ReportServerUrl => ConfigurationManager.AppSettings.Get("SSRSReportServerUrl");

        /// <summary>
        /// Στόκ Εργασιών
        /// </summary>
        /// <returns></returns>
        public ActionResult TaskStockReport()
        {
            ViewBag.Title = "Στόκ Εργασιών";
            return ReportView("/TT/TaskStockReport");
        }

        /// <summary>
        /// Καρτέλα (Ιστορικό) Συμβάντος
        /// </summary>
        public ActionResult IncidentDetailsReport()
        {
            ViewBag.Title = "Καρτέλα (Ιστορικό) Συμβάντος";
            return ReportView("/TT/IncidentDetails");
        }

        /// <summary>
        /// Δεικτες Τμηματος Αφανων Διαρροων
        /// </summary>
        public ActionResult AfanonDiaroonKpi1Report()
        {
            ViewBag.Title = "Δεικτες Τμηματος Αφανων Διαρροων";
            return ReportView("/TT/AfanonDiaroonKpi1");
        }

        /// <summary>
        /// Στατιστικά Εργασιών
        /// </summary>
        public ActionResult TaskAggregatesReport()
        {
            ViewBag.Title = "Στατιστικά Εργασιών";
            return ReportView("/TT/TaskAggregatesReport");
        }

        protected ActionResult ReportView(string reportPath)
        {
            ViewBag.ShowMainButtonStrip = false;

            var model = new ReportViewer()
            {
                ProcessingMode = ProcessingMode.Remote,
                SizeToReportContent = true,
                //AsyncRendering = false,
                ShowFindControls = false,
                Width = Unit.Percentage(100),
                Height = Unit.Percentage(100),
            };

            model.ServerReport.ReportServerUrl = new Uri(ReportServerUrl);
            model.ServerReport.ReportPath = reportPath;

            return View("ReportViewer", model);
        }
    }
}
