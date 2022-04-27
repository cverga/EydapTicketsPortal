using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using DevExpress.Web.Mvc;
using DevExpress.Web.Mvc.UI;
using System.IO;
using EydapTickets.Helpers;
using EydapTickets.Utils;

namespace EydapTickets.Controllers
{
    public class InvestigationsController : BaseController
    {
        // MIXED: Investigations
        public ActionResult Index()
        {
            ViewBag.ShowMainButtonStrip = false;
            return View();
        }

        // MIXED: /Investigations/InvestigationGridViewPartial
        [SetTempDataModelState]
        public PartialViewResult InvestigationGridViewPartial()
        {
            var currentUser = GetCurrentUser();

            var investigations =InvestigationsProvider
                .GetInvestigations(currentUser.SectorId, currentUser.DepartmentId);

            return PartialView("_InvestigationGridViewPartial", investigations);
        }

        // MIXED: /Investigations/AddNewInvestigationPartial
        public PartialViewResult AddNewInvestigationPartial(Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = GetCurrentUser();
                    InvestigationsProvider.AddInvestigationNew(
                        investigation,
                        currentUser.SectorId,
                        currentUser.DepartmentId
                    );
                }
                catch (Exception exception)
                {
                    ViewBag.EditError = exception.Message;
                    Logger.Instance().Error("Failed AddInvestigationNew", exception);
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
            }

            return InvestigationGridViewPartial();
        }

        // MIXED: /Investigations/UpdateInvestigationPartial
        public PartialViewResult UpdateInvestigationPartial(Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = GetCurrentUser();
                    InvestigationsProvider.UpdateInvestigation(
                        investigation,
                        currentUser.SectorId,
                        currentUser.DepartmentId
                    );
                }
                catch (Exception exception)
                {
                    ViewBag.EditError = exception.Message;
                    Logger.Instance().Error("Failed UpdateInvestigation", exception);
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
            }

            return InvestigationGridViewPartial();
        }

        // MIXED: /Investigations/StreetComboBoxPartial
        [RestoreModelStateFromTempData]
        public PartialViewResult StreetsComboBoxPartial(string municipality, string selectedValue)
        {
            var streets = (municipality != null)
                ? IncidentProvider.GetStreetsForMunicipality(municipality)
                : new string[]{};

            var items = streets.Select((s, i) => new Street(i, s));

            var model = new SelectList(items, selectedValue);

            return PartialView("_StreetComboBoxPartial", model);
        }
    }
}