using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;
using DevExpress.Web.Mvc;
using DevExpress.Web;
using System.Globalization;


namespace EydapTickets.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Statistics
        public ActionResult Index()
        {
            StatisticsCreteriaModel mModel = new StatisticsCreteriaModel();
            ViewBag.Malakia = "Jerry";
            ViewBag.ShowMainButtonStrip = false;
            return View(mModel);
        }

        public ActionResult GridCallback(string aMunicipality, string aStreetName, string aFrom, string aTo, string aStreetNumber, string aReport, string aSector)
        {
            //BasicStatisticsModel mModel = new BasicStatisticsModel(new List<string>(), new List<BasciValuesModel>());
            CultureInfo aFormat = new CultureInfo("el-GR");
            //BasicStatisticsModel mModel = StatisticsProvider.Report(aStatisticsCreteriaModelModel.MunicipalityStatistics, aStatisticsCreteriaModelModel.StreetNameStatistics, aStatisticsCreteriaModelModel.StreetNumberStatistics, aStatisticsCreteriaModelModel.FromStatistics.ToString(aFormat), aStatisticsCreteriaModelModel.ToStatistics.ToString(aFormat), aStatisticsCreteriaModelModel.ReportType);

            BasicStatisticsModel mModel = StatisticsProvider.Report(aMunicipality, aStreetName, aStreetNumber, aFrom.ToString(aFormat), aTo.ToString(aFormat), aReport, aSector);
            ViewBag.Municipality = aMunicipality;
            ViewBag.StreetName = aStreetName;
            ViewBag.FromDate = aFrom;
            ViewBag.ToDate = aTo;
            ViewBag.StreetNumber = aStreetNumber;
            ViewBag.ReportType = aReport;

            return PartialView("ResultsPartialView", mModel);
        }

        public ActionResult Municipalities()
        {
            return PartialView("Municipalities", new StatisticsCreteriaModel());
        }

        public ActionResult Sectors()
        {
            return PartialView("SectorsPartialView", new StatisticsCreteriaModel());
        }


        public ActionResult Streetnames()
        {
            string lMunicipality = (Request.Params["Municipality"] != null) ? Request.Params["Municipality"].ToString() : "";
            return PartialView("Streetnames", new StatisticsCreteriaModel { MunicipalityStatistics = lMunicipality });
        }

        public ActionResult GetReportTypes()
        {
            return PartialView("ReportTypesPartialView", IncidentProvider.GetReportTypes());
        }

        public ActionResult UpdateTestPartialView(string aMunicipality, string aStreetName, string aFrom, string aTo, string aStreetNumber, string aReport, string aSector)
        {
            //DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            //BasicStatisticsModel mModel = new BasicStatisticsModel(new List<string>(), new List<BasciValuesModel>());

            ViewBag.Municipality = aMunicipality;
            ViewBag.StreetName = aStreetName;
            ViewBag.FromDate = aFrom;
            ViewBag.ToDate = aTo;
            ViewBag.StreetNumber = aStreetNumber;
            ViewBag.ReportType = aReport;
            ViewBag.Sector = aSector;
            return PartialView("ResultsPartialView", StatisticsProvider.Report(aMunicipality, aStreetName, aStreetNumber, aFrom, aTo, aReport, aSector));
        }

        //public ActionResult Test()
        //{
        //    return View("ResultsPartialView", StatisticsProvider.Test());
        //}

        [HttpPost]
        public ActionResult ExportTo(StatisticsCreteriaModel aModel)
        {
            ViewBag.StatisticsCreteriaModel = aModel;
            string ReportType = Request.QueryString.ToString().Split(new char[1] {'='})[1];
            CultureInfo aFormat = new CultureInfo("el-GR");

            BasicStatisticsModel mModel = StatisticsProvider.Report(aModel.MunicipalityStatistics, aModel.StreetNameStatistics, aModel.StreetNumberStatistics, aModel.FromStatistics.ToString(aFormat), aModel.ToStatistics.ToString(aFormat), aModel.ReportType, aModel.SectorsStatistics);
            switch (ReportType)
            {
                case "CSV":
                    return GridViewExtension.ExportToCsv(GetGridViewSettings(mModel), mModel.Values);

                case "PDF":
                    return GridViewExtension.ExportToPdf(GetGridViewSettings(mModel), mModel.Values);

                case "XLS":
                    return GridViewExtension.ExportToXls(GetGridViewSettings(mModel), mModel.Values);

                case "XLSX":
                    return GridViewExtension.ExportToXlsx(GetGridViewSettings(mModel), mModel.Values);
            }

            //return GridViewExtension.ExportToPdf(GetGridViewSettings(aModel), aModel.Values);
            return null;
        }

        GridViewSettings GetGridViewSettings(BasicStatisticsModel aModel)
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "StatisticsGridView";
            settings.CallbackRouteValues = new { Controller = "Statistics", Action = "GridCallback" };
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            settings.SettingsPager.PageSize = 15;
            settings.ControlStyle.Paddings.PaddingLeft = System.Web.UI.WebControls.Unit.Pixel(100);
            settings.ControlStyle.Paddings.PaddingRight = System.Web.UI.WebControls.Unit.Pixel(100);
            settings.Width = System.Web.UI.WebControls.Unit.Pixel(800);
            settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0);
            settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1);
            settings.SettingsBehavior.AllowGroup = true;
            settings.SettingsBehavior.AllowSort = true;
            settings.Settings.ShowGroupPanel = false;
            settings.SettingsCommandButton.UpdateButton.Text = "Καταχώρηση";
            settings.SettingsCommandButton.CancelButton.Text = "Ακύρωση";
            settings.SettingsCookies.StoreColumnsWidth = true;
            settings.SettingsBehavior.AllowFocusedRow = false;
            settings.SettingsBehavior.AllowSelectByRowClick = false;
            settings.SettingsBehavior.AllowSelectSingleRowOnly = false;
            settings.Settings.ShowGroupPanel = false;
            settings.SettingsCookies.Enabled = false;
            settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.NextColumn;
            if (aModel.Descriptions != null)
            {
                for (int n = 0; n < aModel.Descriptions.Count; n++)
                {
                    switch (n)
                    {
                        case 0:
                            settings.Columns.Add(column =>
                            {
                                column.FieldName = "ONE";
                                column.Caption = aModel.Descriptions[n];
                                column.ReadOnly = true;
                                column.Visible = true;
                            });
                            break;
                        case 1:
                            settings.Columns.Add(column =>
                            {
                                column.FieldName = "TWO";
                                column.Caption = aModel.Descriptions[n];
                                column.ReadOnly = true;
                                column.Visible = true;
                            });
                            break;
                        case 2:
                            settings.Columns.Add(column =>
                            {
                                column.FieldName = "THREE";
                                column.Caption = aModel.Descriptions[n];
                                column.ReadOnly = true;
                                column.Visible = true;
                            });
                            break;
                        case 3:
                            settings.Columns.Add(column =>
                            {
                                column.FieldName = "FOUR";
                                column.Caption = aModel.Descriptions[n];
                                column.ReadOnly = true;
                                column.Visible = true;
                            });
                            break;
                        case 4:
                            settings.Columns.Add(column =>
                            {
                                column.FieldName = "FIVE";
                                column.Caption = aModel.Descriptions[n];
                                column.ReadOnly = true;
                                column.Visible = true;
                            });
                            break;
                    }
                }
            }
            return settings;
        }
    }
}