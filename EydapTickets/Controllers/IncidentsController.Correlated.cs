using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;



namespace EydapTickets.Controllers
{
    public partial class IncidentsController
    {
        // GET: /Incidents/Correlated
        [HttpGet]
        public ActionResult Correlated()
        {
            ViewBag.ShowMainButtonStrip = false;
            return View();
        }

        public ActionResult CorrelatedGridViewPartial()
        {
            var incidents = IncidentProvider.GetRelatedIncidents(GetCurrentUser());
            return PartialView("_CorrelatedGridViewPartial", incidents);
        }
    }
}