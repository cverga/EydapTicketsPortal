using EydapTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EydapTickets.Controllers
{
    public class ScheduledTasksController : BaseController
    {
        // GET: ScheduledTasks
        public ActionResult Index()
        {
            ViewBag.ShowMainButtonStrip = false;
            return View(IncidentProvider.GetScheduledTasks(null, GetCurrentUser()));
        }

        public ActionResult ScheduledTasksPartialView(Guid? value1)
        {
            return PartialView("ScheduledTasksPartialView", IncidentProvider.GetScheduledTasks(null, GetCurrentUser()));
        }

        public ActionResult ScheduledAssignmentsPartialView(Guid aTaskGuid)
        {
            ViewData["TaskGuid"] = aTaskGuid;

            return PartialView("ScheduledAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewTask(Task aTask)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(IncidentProvider.InsertScheduledTask, aTask, GetCurrentUser());
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return PartialView("ScheduledTasksPartialView", IncidentProvider.GetScheduledTasks(null, GetCurrentUser()));
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateTask(Task aTask)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(IncidentProvider.UpdateTask, aTask, (Guid?)null, GetCurrentUser().UserName);
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return PartialView("ScheduledTasksPartialView", IncidentProvider.GetScheduledTasks(null, GetCurrentUser()));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNewAssignmentPartial(Assignment aAssignment, Guid aTaskGuid)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(IncidentProvider.InsertAssignment, aAssignment, aTaskGuid);
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            ViewData["TaskGuid"] = aTaskGuid;

            return PartialView("ScheduledAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAssignmentPartial(Assignment aAssignment, Guid aTaskGuid)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(IncidentProvider.UpdateAssignment, aAssignment);
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            ViewData["TaskGuid"] = aTaskGuid;

            return PartialView("ScheduledAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }
    }
}