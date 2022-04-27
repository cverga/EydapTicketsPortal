using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// added
using EydapTickets.Models;
using DevExpress.Web.Mvc;
using DevExpress.Web;
using System.Globalization;
// added
using System.Configuration;
using EydapTickets.Helpers;

namespace EydapTickets.Controllers
{
    public class MigrationController : BaseController
    {

        // GET: /Migration
        [HttpGet]
        [SetTempDataModelState]
        public ActionResult Index()
        {
            return View("Index", new MigrationSearchCriteria());
        }

        // POST: /Migration
        [HttpPost, ActionName("Index")]
        [SetTempDataModelState]
        public ActionResult IndexPost(MigrationSearchCriteria criteria)
        {
            return View("Index", criteria);
        }

        // MIXED: /Migration/GridViewPartial
        [ValidateInput(false)]
        public ActionResult GridViewPartial(MigrationSearchCriteria criteria)
        {
            var searchQuery = new MigrationSearchQueryResults(criteria);

            if (ModelState.IsValid)
            {
                searchQuery.Results = MigrationDataProvider.GetMigrationData(
                    criteria.Sector,
                    criteria.Municipality,
                    criteria.StreetName,
                    criteria.StreetNumber,
                    criteria.DateFrom,
                    criteria.DateTo
                );
            }

            return PartialView("_MigrationResultsGridViewPartial", searchQuery);
        }

        [RestoreModelStateFromTempData]
        public ActionResult SectorComboBoxPartial(string selectedValue)
        {
            var items = MigrationDataProvider.GetSectors();
            var model = new SelectList(items, selectedValue);
            return PartialView("_SectorComboBoxPartial", model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult MunicipalityComboBoxPartial(string sector, string selectedValue)
        {
            var items = MigrationDataProvider.GetSectorMunicipalities(sector);
            var model = new SelectList(items, selectedValue);
            return PartialView("_MunicipalityComboBoxPartial", model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult StreetNameComboBoxPartial(string sector, string municipality, string selectedValue)
        {
            var items = MigrationDataProvider.GetSectorMunicipalityStreetNames(sector, municipality);
            var model = new SelectList(items, selectedValue);
            return PartialView("_StreetNameComboBoxPartial", model);
        }

        [RestoreModelStateFromTempData]
        public ActionResult StreetNumberTextBoxPartial(string selectedValue)
        {
            return PartialView("_StreetNumberTextBoxPartial", selectedValue);
        }

        public ActionResult DetailsFormLayoutPartial(string sector, string code)
        {
            var model = MigrationDataProvider.GetMigrationRowDetails(sector, code);
            return PartialView("_DetailsFormLayoutPartial", model);
        }
    }
}