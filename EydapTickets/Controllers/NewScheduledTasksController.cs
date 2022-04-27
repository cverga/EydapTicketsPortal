using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//
// Creation Date: 15.07.2018
// Author       : Andreas Kasapleris
// Purpose      : management of new Scheduled Tasks
//

using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public class NewScheduledTasksController : BaseController
    {
        // GET: NewScheduledTasks
        public ActionResult Index()
        {
            // 15.07.2018, Andreas Kasapleris, do not show app buttons
            ViewBag.ShowMainButtonStrip = false;

            // 15.07.2018, Andreas Kasapleris, pass user object to view
            ViewBag.User = GetCurrentUser();

            // 15.07.2018, Andreas Kasapleris, call Index view
            return View("Index", NewScheduledTasksProvider.GetNewScheduledTasks(ViewBag.User));
        }

        //
        // 15.07.2018, Andreas Kasapleris
        // Controller action called from NewScheduledTasksPartialView.cshtml, gets open
        // Scheduled Tasks
        //

        public ActionResult NewScheduledTasksPartial()
        {
            // 15.07.2018, Andreas Kasapleris, pass user object to view
            ViewBag.User = GetCurrentUser();

            return PartialView("NewScheduledTasksPartialView", NewScheduledTasksProvider.GetNewScheduledTasks(GetCurrentUser()));
        }

        //
        // 17.07.2018, Andreas Kasapleris
        // opens (returns) partial View of Assignments (Αναθέσεις) for a NewScheduledTask
        //
        public ActionResult NewScheduledTasksAssignmentsPartial(Guid aTaskGuid)
        {
            ViewData["TaskGuid"] = aTaskGuid;
            return PartialView("ScheduledTasksAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }

        //
        // 16.07.2018, Andreas Kasapleris
        //

        [HttpPost, ValidateInput(true)]
        public ActionResult AddNewScheduledTask(NewScheduledTask aNewScheduledTask, string State)
        {
            ViewData["ValidationFailed"] = false; // 29.03.2017, Andreas Kasapleris

            if (ModelState.IsValid)
            {
                try
                {
                    NewScheduledTasksProvider.AddNewScheduledTask(aNewScheduledTask, State, GetCurrentUser());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else //16.07.2018, Andreas Kasapleris
            {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["ValidationFailed"] = true; //16.07.2018, Andreas Kasapleris
                ViewData["PassedModel"] = aNewScheduledTask; //16.07.2018, Andreas Kasapleris, if something went wrong, return the model you received!
            }

            // 15.07.2018, Andreas Kasapleris, pass user object to view
            ViewBag.User = GetCurrentUser();

            return PartialView("NewScheduledTasksPartialView", NewScheduledTasksProvider.GetNewScheduledTasks(GetCurrentUser()));
        }

        //
        // 2 major things are posted
        // (a) the model, in this case 'NewScheduledTask' (this is standard behaviour)
        // (b) individual variables
        // NOTICE: walk-around to the case: when columns are not visible to grid or set
        // as readonly to the edit form, they are coming to the model as null! In this
        // case is OK, all columns are processed from the grid, therefore no need to
        // pass individual variables
        //

        [HttpPost, ValidateInput(true)]
        public ActionResult UpdateNewScheduledTask(NewScheduledTask aNewScheduledTask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NewScheduledTasksProvider.UpdateNewScheduledTask(aNewScheduledTask, GetCurrentUser().UserName);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            // 15.07.2018, Andreas Kasapleris, pass user object to view
            ViewBag.User = GetCurrentUser();

            return PartialView("NewScheduledTasksPartialView", NewScheduledTasksProvider.GetNewScheduledTasks(GetCurrentUser()));
        }

        //
        // 17.07.2018, Andreas Kasapleris
        // 2 major things are posted
        // (a) the model, in this case 'Assignment' (this is standard behaviour)
        // (b) from 'AddNewRowRouteValues' the ViewData variable TaskGuid
        // NOTES: changes were made to SQL Stored Procedure [InsertAssignment]
        //

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNewScheduledTaskAssignmentPartial(Assignment aAssignment, Guid aTaskGuid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IncidentProvider.InsertAssignment(aAssignment, aTaskGuid);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["TaskGuid"] = aTaskGuid;
            return PartialView("ScheduledTasksAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }

        //
        // 17.07.2018, Andreas Kasapleris
        // 2 major things are posted
        // (a) the model, in this case 'Assignment' (this is standard behaviour)
        // (b) from 'AddNewRowRouteValues' the ViewData variable TaskGuid
        //

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateNewScheduledTaskAssignmentPartial(Assignment aAssignment, Guid aTaskGuid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IncidentProvider.UpdateAssignment(aAssignment);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["TaskGuid"] = aTaskGuid;
            return PartialView("ScheduledTasksAssignmentsPartialView", IncidentProvider.GetAssignments(aTaskGuid));
        }

        //
        // 16.07.2018, Andreas Kasapleris
        //

        public ActionResult StreetsComboBoxPartial()
        {
            string mMunicipality = (Request.Params["SelectedMunicipality"] != null) ? Request.Params["SelectedMunicipality"] : null;
            string[] mStreets = null;
            if (mMunicipality != null)
            {
                mStreets = IncidentProvider.GetStreetsForMunicipality(mMunicipality);
            }

            if (mStreets != null)
            {
                List<Street> mStreetsList = new List<Street>();
                for (int n = 0; n < mStreets.Length; n++)
                {
                    mStreetsList.Add(new Street(n, mStreets[n]));
                }
                ViewData["Streets"] = mStreetsList;
            }
            else
            {
                ViewData["Streets"] = new List<Street>();
            }
            return PartialView("StreetsComboBoxPartialNewScheduledTasks");
        }

        //
        // 16.07.2018, Andreas Kasapleris
        //

        public ActionResult Odos2ComboBoxPartial()
        {
            string mMunicipality = (Request.Params["SelectedMunicipality"] != null) ? Request.Params["SelectedMunicipality"] : null;
            string[] mStreets = null;
            if (mMunicipality != null)
            {
                mStreets = IncidentProvider.GetStreetsForMunicipality(mMunicipality);
            }

            if (mStreets != null)
            {
                List<Street> mStreetsList = new List<Street>();
                for (int n = 0; n < mStreets.Length; n++)
                {
                    mStreetsList.Add(new Street(n, mStreets[n]));
                }
                ViewData["Streets"] = mStreetsList;
            }
            else
            {
                ViewData["Streets"] = new List<Street>();
            }
            return PartialView("Odos2ComboBoxPartialNewScheduledTasks");
        }

    }
}