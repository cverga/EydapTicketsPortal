using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//
// 02.07.2018, Andreas Kasapleris
// Controller to print form 1070
// (Chemeio)
//

namespace EydapTickets.Controllers
{
    public class PrintForm1070Controller : BaseController
    {
        // GET: PrintForm1070
        public ActionResult Index(int? taskid, Guid? assignmentid)
        {
            // 03.07.2018, Andreas Kasapleris
            // create a report 1070 instance
            FormReport1070 report = new FormReport1070();

            // 03.07.2018, Andreas Kasapleris
            // obtain a parameter and set its value
            report.Parameters["AssignmentId"].Value = assignmentid;

            // 03.07.2018, Andreas Kasapleris
            // hide the parameters' UI from end-users (if you did not hide it at design time)
            report.Parameters["AssignmentId"].Visible = false;

            return View(report);
        }
    }
}
