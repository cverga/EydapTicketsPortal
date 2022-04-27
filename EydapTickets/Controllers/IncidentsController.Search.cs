using EydapTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using EydapTickets.Helpers;

namespace EydapTickets.Controllers
{
    public partial class IncidentsController
    {
        // GET: /Incidents/Search
        [HttpGet]
        public ActionResult Search()
        {
            var currentUser = GetCurrentUser();

            var searchCriteria = new IncidentSearchCriteria
            {
                DepartmentId = currentUser.DepartmentId,
                RoleId = currentUser.RoleId
            };

            ClearCachedIncidentSearchCriteria();
            return View("Search", searchCriteria);
        }

        // POST: /Incidents/Search
        [HttpPost, ActionName("Search")]
        [SetTempDataModelState]
        public ActionResult SearchPost(IncidentSearchCriteria searchCriteria)
        {
            var currentUser = GetCurrentUser();

            searchCriteria.DepartmentId = currentUser.DepartmentId;
            searchCriteria.RoleId = currentUser.RoleId;

            if (ModelState.IsValid)
            {
                SetCachedSearchModel(searchCriteria);
            }

            return View("Search", searchCriteria);
        }

        protected void SetCachedSearchModel(IncidentSearchCriteria searchCriteria)
        {
            //HttpContext.Cache.Add("CachedSearchMode", model, null, DateTime.Now.Add(GetDefaultCacheTimeout), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            Session.Add("CachedIncidentSearchCriteria", searchCriteria);
        }

        protected void ClearCachedIncidentSearchCriteria()
        {
            Session.Remove("CachedIncidentSearchCriteria");
        }

        protected IncidentSearchCriteria GetCachedIncidentSearchCriteria()
        {
            IncidentSearchCriteria searchCriteria = null;

            if (Session["CachedIncidentSearchCriteria"] != null)
            {
                searchCriteria = Session["CachedIncidentSearchCriteria"] as IncidentSearchCriteria;
            }

            return searchCriteria;
        }
    }
}