using EydapTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EydapTickets.Utils;  // Andreas Kasapleris, 18.09.2017, supports Logger() functionality
using System.Data;         // Andreas Kasapleris, 18.09.2017, supports DataTable object

namespace EydapTickets.Controllers
{
    public class ProvisionsController : BaseController
    {
        // GET: Provisions
        public ActionResult Index()
        {
            ViewBag.ShowMainButtonStrip = false;
            return View();
        }

        public ActionResult AjaxGetProvisionData(string aprovisionid)
        {
            //
            // 04.10.2017, Andreas Kasapleris
            // keep only Nea Paroxi Request Id, strip off Street and Street Number
            //

            char[] delimiterChars = { '-', ' ', ',', '.', ':', '\t', ';' };

            string searchRequestId = "";

            if (!String.IsNullOrEmpty(aprovisionid))
            {
                string[] filters = aprovisionid.Split(delimiterChars);
                searchRequestId = filters[0];
            }

            string aSearchReqId = searchRequestId;

            ProvisionDetails mProvisions = NeaParoxiDAL.GetNeaParoxiDetails(aSearchReqId);
            ViewBag.ShowMainButtonStrip = false;
            return PartialView("ProvisionsView", mProvisions);
        }

        [HttpPost]
        public ActionResult ProvisionUpdate(ProvisionDetails aProvisionDetails)
        {
            ViewBag.ShowMainButtonStrip = false;
            if (ModelState.IsValid)
            {
                NeaParoxiDAL.UpdateNeaParoxiDetails(aProvisionDetails);
            }
            return PartialView("ProvisionsView", aProvisionDetails);
        }

        //
        // 18.09.2017, Andreas Kasapleris
        // Controller Action to get Request Ids from Νέα Παροχή
        // database depernding on Municipality - StreetName - Street Number
        // as filters
        //

        [HttpGet]
        public ActionResult GetNewProvisionReqIds(string id, string filter)
        {
            ViewBag.ShowMainButtonStrip = false;
            try
            {
                string aFilterParameters = filter;

                // call method to get data
                IEnumerable<object> NewProvReqIdsTable = NeaParoxiDAL.GetNeaParoxiRequestIds(aFilterParameters);
                return Json(NewProvReqIdsTable, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("GetNewProvisionReqIds() failed.", ex);

                List<string> data = new List<string>();
                data.Add("Λάθος στην ανάκτηση Αιτημάτων Νέας Παροχής [GetNewProvisionReqIds].");
                var d = from c in data
                        select new
                        {
                            Id = c,
                            Name = c
                        };

                return Json(d, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
