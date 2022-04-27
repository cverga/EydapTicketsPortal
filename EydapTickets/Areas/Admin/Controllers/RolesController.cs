using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class RolesController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var roles = RolesDAL.GetRoles();
            return PartialView("RoleGridViewPartial", roles);
        }
    }
}