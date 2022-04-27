using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EydapTickets;
using EydapTickets.Utils;
using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public partial class IncidentsController
    {
        // GET: /Incidents/Print/00000000-0000-0000-0000-000000000000
        [HttpGet]
        public ActionResult Details([Bind(Prefix="Id")]Guid? incidentId)
        {
            if (!incidentId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var incidentDetails = IncidentProvider
                .GetIncidentDetails(incidentId.Value);

            return PartialView("_DetailsFormLayoutPartial", incidentDetails);
        }
    }
}