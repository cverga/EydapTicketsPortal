using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class DepartmentsController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var departments = DepartmentsDAL.GetAllDepartments();
            return PartialView("DepartmentGridViewPartial", departments);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(DepartmentsModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => DepartmentsDAL.InsertDepartment(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(DepartmentsModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => DepartmentsDAL.UpdateDepartment(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}