using System;
using System.Collections.Generic;
using System.Linq;

using EydapTickets.Models;
using EydapTickets.Utils;
using System.Web.Mvc;
using System.Data;

namespace EydapTickets.Controllers
{
    public class ApomonoseisController : BaseController
    {
        [HttpGet]
        public ActionResult getVisitsOfApomonoseis(string id, string filter)
        {
            try
            {
                string aFilterParameters = filter;

                // call method to get data
                IEnumerable<object> ListOfApomonoseis = ApomonoseisDAL.getApomonoseis(filter);
                return Json(ListOfApomonoseis, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("getVisitsOfApomonoseis() failed.", ex);

                List<string> data = new List<string>();
                data.Add("Λάθος στην ανάκτηση Αναθέσεων Απομονώσεων [getVisitsOfApomonoseis].");
                var d = from c in data
                        select new
                        {
                            Id = c,
                            DisplayText = c
                        };

                return Json(d, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public void createNewEpanafora(string ApomonosiAssignmentId, string EpanaforaAssignmentId)
        {
            string p1 = ApomonosiAssignmentId;
            string p2 = EpanaforaAssignmentId;

            ApomonoseisDAL.CopyApomonosiToEpanafora(ApomonosiAssignmentId, EpanaforaAssignmentId);
        }
    }
}
