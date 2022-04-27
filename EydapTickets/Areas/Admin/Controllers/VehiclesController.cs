using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class VehiclesController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var vehicles = IncidentProvider.GetVehicles();
            return PartialView("VehicleGridViewPartial", vehicles);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(Vehicle model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.InsertVehicle(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(Vehicle model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => IncidentProvider.UpdateVehicle(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}