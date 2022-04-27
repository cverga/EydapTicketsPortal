using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using EydapTickets.Helpers;
using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public partial class IncidentsController
    {
        // GET: /Incidents/Print/00000000-0000-0000-0000-000000000000
        [HttpGet]
        public ActionResult Print([Bind(Prefix="Id")]Guid? incidentId)
        {
            if (!incidentId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var incident = IncidentProvider.GetIncidentById(incidentId.Value, GetCurrentUser());

            if (incident == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var incidentDetails = IncidentProvider.GetIncidentDetails(incident.TTId);

            ViewBag.ProblemType = incidentDetails.ProblemType;
            ViewBag.AM = incidentDetails.AM;
            ViewBag.CounterNumber = incidentDetails.CounterNumber;
            ViewBag.BillNumber = incidentDetails.BillNumber;
            ViewBag.CorrelatedIncident = incidentDetails.CorrelatedIncident;

            // TODO: Make this a proper view with a print layout
            return PartialView(incident);
        }
    }
}