using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class DepartmentTasksController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var departmentTasks = IncidentProvider.GetDepartmentsToTasksModels();
            return PartialView("DepartmentTaskGridViewPartial", departmentTasks);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(DepartmentsToTasksModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.InsertDepartmentsToTasks(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(DepartmentsToTasksModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.UpdateDepartmentsToTasks(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}