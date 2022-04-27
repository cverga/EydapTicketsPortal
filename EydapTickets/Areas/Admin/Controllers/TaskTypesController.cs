using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class TaskTypesController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var taskTypes = TaskTypeProvider.GetAllTaskTypes();
            return PartialView("TaskTypesGridViewPartial", taskTypes);
        }

        [HttpPost]
        public ActionResult AddNewRow(TaskType model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => TaskTypeProvider.InsertTaskType(model));
            }
            else
            {
                ViewBag.EditError = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost]
        public ActionResult UpdateRow(TaskType model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => TaskTypeProvider.UpdateTaskType(model));
            }
            else
            {
                ViewBag.EditError = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}