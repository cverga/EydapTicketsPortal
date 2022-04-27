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
    public class ReporterController : Controller
    {
        // GET: Reporter
        public ActionResult Index()
        {
            if (Request.QueryString.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.CustomerServiceId = Request.QueryString[0];
            ViewBag.ViewMode = ReporterGridViewMode.User;

            return PartialView("Index");
        }

        public ActionResult SuperVisor()
        {
            if (Request.QueryString.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.CustomerServiceId = Request.QueryString[0];
            ViewBag.ViewMode = ReporterGridViewMode.Supervisor;

            return PartialView("Index");
        }

        public ActionResult TaskGridViewPartial(string customerServiceId, ReporterGridViewMode viewMode = ReporterGridViewMode.User)
        {
            ViewBag.CustomerServiceId = customerServiceId;
            ViewBag.ViewMode = viewMode;

            var tasks = TaskProvider.GetTasksForCustomerServiceId(customerServiceId);

            return PartialView("_TaskGridViewPartial", tasks);
        }

        public ActionResult AssignmentGridViewPartial(Guid? taskId)
        {
            if (!taskId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var task = TaskProvider.GetTaskById(taskId.Value);

            if (task == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.TaskId = task.TaskId;
            ViewBag.IncidentId = task.TaskId;

            var assignments = IncidentProvider.GetAssignments(task.TaskId);

            return PartialView("_AssignmentGridViewPartial", assignments);
        }
    }
}