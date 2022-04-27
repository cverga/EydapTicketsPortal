using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class PersonnelController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var personnel = IncidentProvider.GetPersonnel();
            return PartialView("PersonnelGridViewPartial", personnel);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(Personnel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.AddPersonnel(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(Personnel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.UpdatePersonnel(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}