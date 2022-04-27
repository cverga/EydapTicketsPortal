using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.ShowMainButtonStrip = false;

            return View();
        }

        public ActionResult SectionTabsPartial()
        {
            ViewBag.ShowMainButtonStrip = false;

            UsersModel user = GetCurrentUser();
            if (user.Role == UsersModel.UserRole.Administrator)
            {
                return PartialView("SectionTabsPartial");
            }

            return PartialView("NoAccess");
        }

        protected override void FixActiveMenu()
        {
            ViewBag.IsOnAdminMenu = true;
        }
    }
}