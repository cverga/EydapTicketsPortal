using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var users = UsersDAL.GetUsers();
            return PartialView("UserGridViewPartial", users);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(UsersModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => UsersDAL.InsertUser(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(UsersModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() =>
                {
                    UsersDAL.UpdateUser(model);
                    ClearUserFromCache();
                });
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}