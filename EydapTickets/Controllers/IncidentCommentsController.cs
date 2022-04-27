using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public class IncidentCommentsController : BaseController
    {
        // GET: Route
        /*public ActionResult CommentsIndex(Guid aIncidentId)
        {
            IEnumerable<IncidentComments> mIncidentComments = IncidentProvider.GetIncidentComments(aIncidentId);
            return PartialView(mIncidentComments);
        }*/

        public ActionResult AjaxCommentsPartial(string aparameter)
        {
            ViewBag.IncidentId = aparameter;
            List<IncidentComments> mIncidentComments = IncidentProvider.GetIncidentComments(Guid.Parse(aparameter));
            return PartialView("CommentsIndex", mIncidentComments);
        }

        public void SaveComment(string aparameter, string anewcomment)
        {
            UsersModel mUser = GetCurrentUser();
            IncidentProvider.SaveIncidentComments(Guid.Parse(aparameter), anewcomment);
        }
    }
}