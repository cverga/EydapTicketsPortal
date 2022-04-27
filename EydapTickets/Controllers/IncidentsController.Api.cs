using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public partial class IncidentsController
    {
        [HttpPost]
        public ActionResult Correlate([Bind(Prefix = "Id")] Guid? incidentId, string correlateCode)
        {
            if (!incidentId.HasValue)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "The incident Id is required." }, JsonRequestBehavior.AllowGet);
            }

            if (correlateCode == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "The correlation code is required." }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                IncidentProvider
                    .CorrelateTT(incidentId.Value, correlateCode);

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new {success = true, responseText = "The incident was correlated successfully."}, JsonRequestBehavior.AllowGet);
            }
            catch(Exception exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { success = false, responseText = exception.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ClearCorrelation([Bind(Prefix = "Id")] Guid? incidentId)
        {
            if (!incidentId.HasValue)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {success = false, responseText = "The incident Id is required."}, JsonRequestBehavior.AllowGet);
            }

            try
            {
                IncidentProvider
                    .ClearTTCorrelation(incidentId.Value);

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new {success = true, responseText = "The incident correlation was cleared."},
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { success = false, responseText = exception.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}