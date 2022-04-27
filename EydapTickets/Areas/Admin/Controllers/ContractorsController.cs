using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class ContractorsController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var contractors = ErgolavoiDAL.GetErgolavoi();
            return PartialView("ContractorGridViewPartial", contractors);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(Ergolavoi model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => ErgolavoiDAL.AddNewErgolavos(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(Ergolavoi model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => ErgolavoiDAL.UpdateErgolavos(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}
