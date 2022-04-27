using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//
// Creation Date: 10.07.2018
// Author       : Andreas Kasapleris
// Purpose      : management of Open Tasks
//

using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public class OpenTasksController : BaseController
    {
        // GET: /OpenTasks
        public ActionResult Index()
        {
            ViewBag.ShowMainButtonStrip = false;

            return View("Index");
        }

        // MIXED: /OpenTasks/OpenTaskGridViewPartial
        public ActionResult OpenTaskGridViewPartial(Guid? incidentId = null, string focusedRowKey = null)
        {
            var currentUser = GetCurrentUser();
            var openTasks = OpenTasksProvider.GetOpenTasks(currentUser);

            ViewBag.FocusedRowKey = focusedRowKey;

            var incident = incidentId.HasValue
                ? IncidentProvider.GetIncidentById(incidentId.Value, currentUser)
                : null;

            ViewBag.MinDateConstraint = incident?.DateCreated ?? DateTime.Now;

            // configure permissions
            ViewBag.CanUpdateTasks = true;

            return PartialView("_OpenTaskGridViewPartial", openTasks);
        }

        // 2 major things are posted
        // (a) the model, in this case 'OpenTask' (this is standard behaviour)
        // (b) individual variables NOTICE: walk-around to the case: when columns are not
        // visible to grid or readonly to the edit form, are coming to the model as null!
        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateOpenTaskPartial(OpenTask openTask, Guid? incidentId = null, string focusedRowKey = null)
        {
            ViewBag.EditError = null;
            ViewBag.ValidationError = false;
            ViewBag.OpenTaskModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    OpenTasksProvider.UpdateOpenTask(
                        openTask.IncidentId,
                        openTask.TaskId,
                        openTask.TaskTypeId,
                        openTask.Comments,
                        openTask.State,
                        openTask.ClosingDate,
                        GetCurrentUser().UserName
                     );
                }
                catch (Exception exception)
                {
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationError = true;
                    ViewBag.OpenTaskModel = openTask;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationError = true;
                ViewBag.OpenTaskModel = openTask;
            }

            return OpenTaskGridViewPartial(incidentId, focusedRowKey);
        }
    }
}