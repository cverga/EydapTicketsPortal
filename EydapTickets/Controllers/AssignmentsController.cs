using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EydapTickets.Helpers;
using EydapTickets.Models;
using EydapTickets.Utils;

namespace EydapTickets.Controllers
{
    public class AssignmentsController : BaseController
    {
        // MIXED: /Assignments/GridViewPartial
        [SetTempDataModelState]
        public ActionResult GridViewPartial(Guid? taskId, Guid? focusedRowKey = null)
        {
            if (!taskId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var task = TaskProvider.GetTaskById(taskId.Value);

            ViewBag.FocusedRowKey = focusedRowKey;
            ViewBag.MinDateConstraint = task.CreationDate;
            ViewBag.TaskId = task.TaskId;
            ViewBag.IncidentId = task.IncidentId;

            // 02.07.2018, Andreas Kasapleris
            ViewBag.TaskTypeId = task.TaskTypeId;
            ViewBag.TaskDepartmentId = task.DepartmentId;

            // configure permissions
            var isMeteringDepartmentTask = Constants.MeteringDepartments.Contains(task.DepartmentId);
            var isCurrentUserDepartmentTask = (ViewBag.DepartmentId == task.DepartmentId);
            var isOpenTask = (task.State == "Ανοιχτή");

            ViewBag.CanAddNewAssignments = isOpenTask && ( isCurrentUserDepartmentTask || ViewBag.IsAdmin ) && !isMeteringDepartmentTask;
            ViewBag.CanUpdateAssignments = ( isOpenTask && isCurrentUserDepartmentTask ) || ViewBag.IsAdmin;

            var assignments = IncidentProvider.GetAssignments(task.TaskId);
            return PartialView("_AssignmentGridViewPartial", assignments);
        }

        // POST: /Assignments/AddNewAssignmentPartial
        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewAssignmentPartial(Assignment assignment, Guid? taskId, Guid? focusedRowKey = null)
        {
            if (!taskId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.EditError = null;
            ViewBag.ValidationFailed = false;
            ViewBag.AssignmentModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    IncidentProvider.InsertAssignment(assignment, taskId.Value);
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("Failed To add Assignment", exception);
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationFailed = true;
                    ViewBag.AssignmentModel = assignment;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationFailed = true;
                ViewBag.AssignmentModel = assignment;
            }

            return GridViewPartial(taskId, focusedRowKey);
        }

        // POST: /Assignments/UpdateAssignmentPartial
        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateAssignmentPartial(Assignment assignment, Guid? taskId, Guid? focusedRowKey = null)
        {
            if (!taskId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.EditError = null;
            ViewBag.ValidationFailed = false;
            ViewBag.AssignmentModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    IncidentProvider.UpdateAssignment(assignment);
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("Failed To Update Assignment", exception);
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationFailed = true;
                    ViewBag.AssignmentModel = assignment;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationFailed = true;
                ViewBag.AssignmentModel = assignment;
            }

            return GridViewPartial(taskId, focusedRowKey);
        }
    }
}
