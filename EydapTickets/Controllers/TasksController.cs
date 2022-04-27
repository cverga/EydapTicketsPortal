using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using EydapTickets.Helpers;
using EydapTickets.Models;
using EydapTickets.Utils;
using Task = System.Threading.Tasks.Task;

namespace EydapTickets.Controllers
{
    public class TasksController : BaseController
    {
        // MIXED: /Tasks/GridViewPartial
        [SetTempDataModelState]
        public ActionResult GridViewPartial(Guid? incidentId, Guid? focusedRowKey = null)
        {
            if (!incidentId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentUser = GetCurrentUser();

            var incident = IncidentProvider.GetIncidentById(incidentId.Value, currentUser);
            if (incident == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.FocusedRowKey = focusedRowKey;
            ViewBag.IncidentId = incident.TTId;
            ViewBag.TEBCC = incident.TEBCC;
            ViewBag.MinDateConstraint = incident.DateCreated ?? DateTime.Now;

            // configure permissions
            ViewBag.CanAddNewTasks = incident.Status == 1;
            ViewBag.CanUpdateTasks = true;

            var tasks = TaskProvider.GetTasks(incidentId.Value, currentUser);
            return PartialView("_TaskGridViewPartial", tasks);
        }

        // POST: /Tasks/AddNewTaskPartial
        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewTaskPartial(Models.Task task, Guid incidentId, Guid? focusedRowKey = null)
        {
            ViewBag.EditError = null;
            ViewBag.ValidationFailed = false;
            ViewBag.TaskModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    // route here.......
                    IEnumerable<TTRoute> mRoutes = IncidentProvider.GetRoutedDepartmentsForTicket(incidentId);
                    var currentUser = GetCurrentUser();
                    TTRoute mRoute = mRoutes.FirstOrDefault<TTRoute>((x) => x.ToDepartmentId == task.DepartmentId);
                    if (mRoute == null)
                    {
                        TTRoute mNewRoute = new TTRoute(incidentId, currentUser.SectorId, currentUser.DepartmentId, task.DepartmentId, DateTime.Now);
                        IncidentProvider.InsertRoute(mNewRoute, currentUser.Name == "1022" ? "1022" : currentUser.Name);
                    }
                    // 1033 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΑΘΗΝΑΣ
                    // 1039 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΠΕΙΡΑΙΑΣ
                    // 1043 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΗΡΑΚΛΕΙΟΥ
                    // 1082 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΑΣΠΡΟΠΥΡΓΟΥ (ΠΕΙΡΑΙΑΣ)
                    // 1084 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΣΑΛΑΜΙΝΑΣ (ΠΕΙΡΑΙΑΣ)
                    // 1097 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΜΕΝΙΔΙΟΥ (ΗΡΑΚΛΕΙΟΥ)
                    // Check if it is routed in one of the above departments
                    // Then post it to backend.....
                    if (task.DepartmentId == 1033 || task.DepartmentId == 1039 || task.DepartmentId == 1043 || task.DepartmentId == 1082 || task.DepartmentId == 1084 || task.DepartmentId == 1097)
                    {
                        BackEndIncident IncidentToSendToBackEnd = RoutingController.Router.prepareTicketForBackEnd(incidentId.ToString(), task.DepartmentId);

                        // Added to update the backend incident with the date from UI
                        IncidentToSendToBackEnd.CreationDate = task.CreationDate;

                        string BackEndIncidentID = RoutingController.PostIncidentToBackEnd(IncidentToSendToBackEnd);
                        task.BackEndTabletId = BackEndIncidentID;
                    }

                    IncidentProvider.InsertTask(task, incidentId, GetCurrentUser().UserId);
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("Failed To add Task ", exception);
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationFailed = true;
                    ViewBag.TaskModel = task;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationFailed = true;
                ViewBag.TaskModel = task;
            }

            return GridViewPartial(incidentId, focusedRowKey);
        }

        // POST: /Tasks/UpdateTaskPartial
        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateTaskPartial(Models.Task task, Guid incidentId, Guid? focusedRowKey = null)
        {
            ViewBag.EditError = null;
            ViewBag.ValidationFailed = false;
            ViewBag.TaskModel = null;

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = GetCurrentUser();
                    IncidentProvider.UpdateTask(task, incidentId, currentUser.Name);
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("Failed To Update Task", exception);
                    ViewBag.EditError = exception.Message;
                    ViewBag.ValidationFailed = true;
                    ViewBag.TaskModel = task;
                }
            }
            else
            {
                ViewBag.EditError = "Please, correct all errors.";
                ViewBag.ValidationFailed = true;
                ViewBag.TaskModel = task;
            }

            return GridViewPartial(incidentId, focusedRowKey);
        }
    }
}
