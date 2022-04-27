using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EydapTickets.Models;
using EydapTickets.Utils;

namespace EydapTickets.Controllers
{
    public partial class IncidentsController : BaseController
    {
        // GET: /Incidents
        // [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ViewMode = IncidentGridViewMode.Open;
            return View("Index");
        }

        // GET: /Incidents/ClosedSeventyTwoHours
        [HttpGet]
        public ActionResult ClosedSeventyTwoHours()
        {
            ViewBag.ViewMode = IncidentGridViewMode.ClosedSeventyTwoHours;
            return View("Index");
        }

        // GET: /Incidents/ClosedWithPendingTasks
        [HttpGet]
        public ActionResult ClosedWithPendingTasks()
        {
            ViewBag.ViewMode = IncidentGridViewMode.ClosedWithPendingTasks;
            return View("Index");
        }

        // MIXED: /Incidents/GridViewPartial
        public ActionResult GridViewPartial(IncidentGridViewMode viewMode = IncidentGridViewMode.Open, Guid? incidentId = null, Guid? focusedRowKey = null,  bool hideMine = false)
        {
            var currentUser = GetCurrentUser();

            IEnumerable<Incident> incidents;
            if (incidentId.HasValue)
            {
                var incident = IncidentProvider.GetIncidentById(incidentId.Value, currentUser);
                incidents = new List<Incident>() {incident};
            }
            else
            {
                switch (viewMode)
                {
                    case IncidentGridViewMode.ClosedSeventyTwoHours:
                        incidents = IncidentProvider.GetIncidentsClosedSeventyTwoHours(currentUser);
                        break;

                    case IncidentGridViewMode.ClosedWithPendingTasks:
                        incidents = IncidentProvider.GetIncidentsClosedWithPendingTasks(currentUser);
                        break;

                    case IncidentGridViewMode.Search:
                        var searchCriteria = GetCachedIncidentSearchCriteria();
                        incidents = searchCriteria != null
                            ? IncidentProvider.GetIncidentsForSearch(searchCriteria, currentUser)
                            : new List<Incident>();
                        break;

                    //case IncidentGridViewMode.Open:
                    default:
                        incidents = IncidentProvider.GetIncidents(currentUser);
                        break;
                }
            }

            // Feature: Hide Mine
            // Filter out incidents from other departments.
            if (viewMode != IncidentGridViewMode.Search && hideMine)
            {
                incidents = incidents.Where(i => i.MyDepartmentColor != 1);
            }

            ViewBag.ViewMode = viewMode;
            ViewBag.IncidentId = incidentId;
            ViewBag.FocusedRowKey = focusedRowKey;
            ViewBag.TotalIncidents = incidents.Count();
            //Session["TotalIncidents"] = ViewBag.TotalIncidents;

            return PartialView("_IncidentGridViewPartial", incidents);
        }

        // POST: /Incidents/AddNewIncident
        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewIncident(Incident incident, IncidentGridViewMode viewMode = IncidentGridViewMode.Open)
        {
            ViewBag.EditError = null;
            ViewBag.ValidationError = false;
            ViewBag.IncidentModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = GetCurrentUser();
                    incident.Sector = currentUser.SectorId;

                    var incidentId = IncidentProvider.InsertIncident(incident);

                    var incidentRoute = new TTRoute(
                        incidentId,
                        incident.Sector,
                        currentUser.DepartmentId,
                        currentUser.DepartmentId,
                        DateTime.Now);

                    IncidentProvider.InsertRoute(incidentRoute, currentUser.Name);

                    try
                    {
                        gr.eydap.dominosrv21.TTCreationService ticketTraceService = new gr.eydap.dominosrv21.TTCreationService();
                        gr.eydap.dominosrv21.RESPONSE response = ticketTraceService.CREATETT("", "", "", "Υ", incident.Municipality, incident.StreetName, incident.StreetNumber, "", "", "", GetCurrentUser().Name, "ΜΕΤΡΙΑ", "ΝΕΟ", incident.Comments, "ΤΗΛΕΦΩΝΟ", "ΠΟΛΛΑ ΝΕΡΑ", "", incidentId.ToString());
                        if (!response.SUCCESS)
                        {
                            Logger.Instance().Warning("Failed to Create TT in TicketTrace :" + response.REASON + "/" + response.ERRORCODE);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance().Error("Failed to Create TT in TicketTrace......", ex);
                    }
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("Failed to Create TT in TicketTrace......", exception);
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationError = true;
                    ViewBag.IncidentModel = incident;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationError = true;
                ViewBag.IncidentModel = incident;
            }

            return GridViewPartial(viewMode);
        }
    }
}
