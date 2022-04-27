using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Admin.Controllers
{
    public class SectorsController : BaseController
    {
        public ActionResult GridViewPartial()
        {
            var sectors = SectorsDAL.GetSectors();
            return PartialView("SectorGridViewPartial", sectors);
        }

        public ActionResult GetDepartments(int? sectorId, int? departmentId)
        {
            var departments = UsersDAL.GetDepartmentsForSector(sectorId ?? -1);
            return GridExtensionBase.GetComboBoxCallbackResult(p => {
                p.BindList(departments);
                p.TextField = "DepartmentName";
                p.ValueField = "DepartmentId";
                p.ValueType = typeof(int);
            });
        }

        public ActionResult GetDepartmentsJson(int sectorId)
        {
            var departments = DepartmentsDAL.GetDepartments(sectorId)
                .ToList();

            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSectorsForReroutingJson()
        {
            var currentUser = GetCurrentUser();

            var sectors = SectorsDAL.GetSectorsForRerouting(currentUser.SectorId)
                .ToList();

            return Json(sectors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewRow(SectorsModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => SectorsDAL.InsertSector(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateRow(SectorsModel model)
        {
            if (ModelState.IsValid)
            {
                SafeExecute(() => SectorsDAL.UpdateSector(model));
            }
            else
            {
                ViewData["EditError"] = "Παρακαλώ διορθώστε τα λάθη.";
            }

            return GridViewPartial();
        }
    }
}