using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class IncidentsRoutingController : BaseController
    {
        // GET: IncidentsRouting
        public ActionResult Index()
        {
            // return View();
            ViewBag.Title = "ΠΙΝΑΚΑΣ ΔΡΟΜΟΛΟΓΗΣΗΣ ΣΥΜΒΑΝΤΩΝ";

            // get Incidents Routings data
            return PartialView(IncidentsRoutingDAL.GetIncidentsRoutings());

        }

        public ActionResult GetIncidentsRoutings()
        {
            // get Incidents Routings data
            return PartialView("IncidentsRoutingMainGridPartialView", IncidentsRoutingDAL.GetIncidentsRoutings());
        }

        //
        // 23.07.2016, Andreas Kasapleris will handle the case of cascading
        // Departments when Sector is selected. See Partial View ComboBoxDepartmentsPartialRouting.cshtml
        //

        public ActionResult ComboBoxDepartmentsPartialRouting()
        {
            // 'SectorId' parameter is set with Java script in DepartmentsCombo_BeginCallback
            // int sectorId = (Request.Params["SectorId"] != null) ? int.Parse(Request.Params["SectorId"]) : -1;

            string SectorName = (Request.Params["SectorName"] != null) ? Request.Params["SectorName"] : "ΑΝΥΠΑΡΚΤΟΣ ΤΟΜΕΑΣ";
            return PartialView("ComboBoxDepartmentsPartialRouting", EydapTickets.Models.IncidentsRoutingDAL.GetDepartmentsForSector(SectorName));
        }

        public ActionResult ComboBoxRouteToDepartmentsPartial()
        {
            // 'SectorId' parameter is set with Java script in DepartmentsCombo_BeginCallback
            // int sectorId = (Request.Params["SectorId"] != null) ? int.Parse(Request.Params["SectorId"]) : -1;

            string SectorName = (Request.Params["SectorName"] != null) ? Request.Params["SectorName"] : "ΑΝΥΠΑΡΚΤΟΣ ΤΟΜΕΑΣ";
            return PartialView("ComboBoxRouteToDepartmentsPartial", EydapTickets.Models.IncidentsRoutingDAL.GetDepartmentsForSector(SectorName));
        }

        [HttpPost, ValidateInput(true)]
        //
        // action method which calls another C# method to insert a new
        // Incident Routing in SQL database table IncidentsRouting
        // userEnteredIncidentRoutingModel which is of type <IncidentsRoutingModel>
        // is the row currently processed in the View by the user
        //
        public ActionResult AddNewIncidentRouting(IncidentsRoutingModel userEnteredIncidentRoutingModel)
        {
            // 26.09.2016, Andreas Kasapleris
            ViewData["ValidationFailed"] = false;
            if (ModelState.IsValid)
            {
                try
                {
                    // call routine to insert IncidentsRouting in database; use data model processed
                    // by the user to do the insertion
                    IncidentsRoutingDAL.InsertIncidentRouting(userEnteredIncidentRoutingModel);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                // 26.09.2016, Andreas Kasapleris
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["ValidationFailed"] = true;
                ViewData["Passedmodel"] = userEnteredIncidentRoutingModel;
            }

            // for all other actions in Controller use return PartialView(...);
            return PartialView("IncidentsRoutingMainGridPartialView", IncidentsRoutingDAL.GetIncidentsRoutings());
        }


        [HttpPost, ValidateInput(true)]
        //
        // action method which calls another C# method to update
        // Incident Routing in SQL database table IncidentsRouting
        // userEnteredIncidentRoutingModel which is of type <IncidentsRoutingModel>
        // is the row currently processed in the View by the user
        //
        public ActionResult UpdateIncidentRouting(IncidentsRoutingModel userEnteredIncidentRoutingModel)
        {
            // 26.09.2016, Andreas Kasapleris
            ViewData["ValidationFailed"] = false;
            if (ModelState.IsValid)
            {
                try
                {
                    // call routine to update IncidentsRouting in database; use data model processed
                    // by the user to do the insertion
                    IncidentsRoutingDAL.UpdateIncidentRouting(userEnteredIncidentRoutingModel);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                // 26.09.2016, Andreas Kasapleris
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["ValidationFailed"] = true;
                ViewData["Passedmodel"] = userEnteredIncidentRoutingModel;
            }

            // for all other actions in Controller use return PartialView(...);
            return PartialView("IncidentsRoutingMainGridPartialView", IncidentsRoutingDAL.GetIncidentsRoutings());
        }

    }

}