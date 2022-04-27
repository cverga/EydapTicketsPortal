using System;
using System.Globalization;
using System.Web.Mvc;
using DevExpress.DataAccess.Sql;
using EydapTickets.Areas.Reporting.Models;
using EydapTickets.Helpers;

namespace EydapTickets.Areas.Reporting.Controllers
{
    public class Report1100Controller : BaseController
    {
        // GET: Report1100
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ReportCommonSearchModel();

            PrepareModel(model);

            // Initially hide the report
            model.ShowReport = false;

            ViewBag.AccessToInvestigations = false;
            ViewBag.ShowMainButtonStrip = false;

            return View("Index", model);
        }

        // POST: Report1100
        [HttpPost, ActionName("Index")]
        [SetTempDataModelState]
        public ActionResult IndexPost(ReportCommonSearchModel model)
        {
            PrepareModel(model);

            // Show the report when the model is valid
            model.ShowReport = ModelState.IsValid;

            return View("Index", model);
        }

        [ChildActionOnly]
        public ActionResult WebDocViewerPartial(ReportCommonSearchModel model)
        {
            // if show the report is true ...
            if (model.ShowReport)
            {
                // 31.03.2018, Andreas Kasapleris, create the report ...
                var report = new Report1100();

                // 31.03.2018, Andreas Kasapleris,
                // set where the report gets data, when data are demanded!
                report.DataSourceDemanded += (s, e) => { PrepareReport(report, model); };

                // 31.03.2018, Andreas Kasapleris, return the report!
                ViewData["Report1100"] = report;
            }

            return PartialView("_WebDocViewerPartial", model);
        }

        protected void PrepareModel(ReportCommonSearchModel model)
        {
            var currentUser = GetCurrentUser();

            model.SectorId = currentUser.SectorId;
            model.DepartmentId = currentUser.DepartmentId;
        }

        protected void PrepareReport(Report1100 report, ReportCommonSearchModel model)
        {
            var cultureInfo = new CultureInfo("el-GR");

            report.FromDate.Value = model.DateFrom;
            report.ToDate.Value = model.DateTo;

            report.Municipality.Value = model.Municipality;
            report.StreetName.Value = model.StreetName;
            report.StreetNumber.Value = model.StreetNumber;
            report.TaskTypeDescription.Value = model.TaskType;
            report.TaskState.Value = model.TaskState;
            report.ErgName.Value = model.Contractor;

            DateTime dt1 = DateTime.Parse(model.DateFrom.ToString(), cultureInfo);
            DateTime dt2 = DateTime.Parse(model.DateTo.AddDays(1).ToString(), cultureInfo);

            string dtFrom = string.Format("{0}/{1}/{2} 00:00:00", dt1.Day, dt1.Month, dt1.Year);
            string dtTo = string.Format("{0}/{1}/{2} 00:00:00", dt2.Day, dt2.Month, dt2.Year);

            var dataSource = report.sqlDataSource1;
            var existingQuery = (CustomSqlQuery)dataSource.Queries[0];

            // create and configure a new query
            var extendedQuery = new CustomSqlQuery
            {
                Name = existingQuery.Name,
                Sql = existingQuery.Sql
            };

            extendedQuery.Sql += " WHERE 1 = 1";

            extendedQuery.Sql += " AND DateOfAssignment >= CONVERT(DATETIME, @DateFrom, 103)";
            extendedQuery.Parameters.Add(new QueryParameter("@DateFrom", typeof(string), dtFrom));

            extendedQuery.Sql += " AND DateOfAssignment < CONVERT(DATETIME, @DateTo, 103)";
            extendedQuery.Parameters.Add(new QueryParameter("@DateTo", typeof(string), dtTo));

            extendedQuery.Sql += " AND SectorId = @SectorId";
            extendedQuery.Parameters.Add(new QueryParameter("@SectorId", typeof(int), model.SectorId));

            extendedQuery.Sql += " AND DepartmentId = @DepartmentId";
            extendedQuery.Parameters.Add(new QueryParameter("@DepartmentId", typeof(int), model.DepartmentId));

            if (!string.IsNullOrEmpty(model.Municipality))
            {
                extendedQuery.Sql += " AND Municipality = @Municipality";
                extendedQuery.Parameters.Add(new QueryParameter("@Municipality", typeof(string), model.Municipality));
            }

            if (!string.IsNullOrEmpty(model.StreetName))
            {
                extendedQuery.Sql += " AND Street_Name = @StreetName";
                extendedQuery.Parameters.Add(new QueryParameter("@StreetName", typeof(string), model.StreetName));
            }

            if (!string.IsNullOrEmpty(model.StreetNumber))
            {
                extendedQuery.Sql += " AND Street_Number = @StreetNumber";
                extendedQuery.Parameters.Add(new QueryParameter("@StreetNumber", typeof(string), model.StreetNumber));
            }

            if (!string.IsNullOrEmpty(model.TaskType))
            {
                extendedQuery.Sql += " AND Task_Description = @TaskType";
                extendedQuery.Parameters.Add(new QueryParameter("@TaskType", typeof(string), model.TaskType));
            }

            if (!string.IsNullOrEmpty(model.TaskState))
            {
                extendedQuery.Sql += " AND State = @TaskState";
                extendedQuery.Parameters.Add(new QueryParameter("@TaskState", typeof(string), model.TaskState));
            }

            if (!string.IsNullOrEmpty(model.Contractor))
            {
                extendedQuery.Sql += " AND ( FName = @Contractor OR LName = @Contractor )";
                extendedQuery.Parameters.Add(new QueryParameter("@Contractor", typeof(string), model.Contractor));
            }

            // extend the existing query with 'ORDER BY'
            extendedQuery.Sql += " ORDER BY DateOfAssignment ASC";

            // replace the query and fill the data source
            dataSource.Queries[0] = extendedQuery;
            dataSource.Fill();

            // rebuild the result schema after filling the data source
            //dataSource.RebuildResultSchema();
        }
    }
}