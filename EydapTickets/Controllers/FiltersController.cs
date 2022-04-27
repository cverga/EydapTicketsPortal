using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EydapTickets.Models;
using EydapTickets.Helpers;

namespace EydapTickets.Controllers
{
    [Authorize]
    public class FiltersController : BaseController
    {
        [RestoreModelStateFromTempData]
        public ActionResult Code1022Partial(string selectedValue)
        {
            return PartialView("Code1022Partial", selectedValue);
        }

        [RestoreModelStateFromTempData]
        public ActionResult DateFromPartial(DateTime? selectedValue)
        {
            return PartialView("DateFromPartial", selectedValue);
        }

        [RestoreModelStateFromTempData]
        public ActionResult DateToPartial(DateTime? selectedValue)
        {
            return PartialView("DateToPartial", selectedValue);
        }

        [RestoreModelStateFromTempData]
        public ActionResult ContractorPartial(int sectorId, string selectedValue)
        {
            var contractors = IncidentProvider.GetErgolavoi(sectorId);

            var items = contractors
                .Select(s => new SelectListItem()
                {
                    Text = s.ErgName,
                    Value = s.ErgName
                })
                .ToList();

            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult CallerFullNamePartial(string selectedValue)
        {
            return PartialView("CallerFullNamePartial", selectedValue);
        }

        [RestoreModelStateFromTempData]
        public ActionResult MunicipalityPartial(string selectedValue)
        {
            var items = IncidentProvider.GetIncidentMunicipalities();
            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult Odos2Partial(string municipality, string selectedValue)
        {
            var items = IncidentProvider.GetIncidentDistinctOdos2(municipality);
            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult PerioxiPartial(string municipality, string selectedValue)
        {
            var items = IncidentProvider.GetIncidentPerioxes(municipality);
            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult StreetNamePartial(string municipality, string selectedValue)
        {
            var items = IncidentProvider.GetIncidentStreetNames(municipality);
            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult StreetNumberPartial(string selectedValue)
        {
            return PartialView("StreetNumberPartial", selectedValue);
        }

        [RestoreModelStateFromTempData]
        public ActionResult TaskStatePartial(string selectedValue)
        {
            var taskStates = new List<string>
            {
                "Ανοιχτή", "Ολοκληρωμένη", "Ακυρωμένη"
            };

            var items = taskStates
                .Select(s => new SelectListItem()
                {
                    Text = s,
                    Value = s
                })
                .ToList();


            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult TaskTypePartial(string selectedValue)
        {
            UsersModel currentUser = GetCurrentUser();

            var taskTypes = TaskTypeProvider
                .GetAllTaskTypesForDepartment(currentUser.DepartmentId);

            var items = taskTypes
                .Select(s => new SelectListItem()
                {
                    Text = s.Description,
                    Value = s.Description
                })
                .ToList();

            var model = new SelectList(items, selectedValue);
            return PartialView(model);
        }
    }
}
