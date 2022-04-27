using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;
using Newtonsoft.Json;
using DevExpress.Web.Mvc;
using DevExpress.Web.Mvc.UI;
using System.IO;
using EydapTickets.Helpers;
using EydapTickets.Utils;
using EydapTickets.gr.eydap.dominosrv2;
using System.Data;
using System.Net;
using System.Web.Http.Results;
using System.Web.UI;
using DevExpress.XtraSpreadsheet.Model;

namespace EydapTickets.Controllers
{
    public class HomeController : BaseController
    {
        // [Authorize]
        public ActionResult Index(int? aParameter)
        {
            return RedirectToAction("Index", "Incidents", new { viewMode = aParameter });
        }

        protected override void FixActiveMenu()
        {

        }

        public ActionResult VisitDetails(string aVisitCrew, string aAssignmentId)
        {
            VisitDetailsModel mDetsModel = new VisitDetailsModel();

            //string[] mCrews = aVisitCrew.Split(new char[1] {';'});

            VisitDetailsModel mVisitDetailModel = new VisitDetailsModel();
            List<VisitCrewLight> mVCL = new List<VisitCrewLight>();
            List<Personnel> mPersonnel = (List<Personnel>)IncidentProvider.GetPersonnelforrDepartmentId(GetCurrentUser().DepartmentId).ToList();

            for (int n = 0; n < mPersonnel.Count; n++)
            {
                mVCL.Add(new VisitCrewLight() { ID = n, VisitCrewName = mPersonnel[n].PersonnelName });
            }
            //mDetsModel.VisitCrew = mVCL;

            List<Vehicle> mVehicles = IncidentProvider.GetVehiclesForDepartment(GetCurrentUser().DepartmentId).ToList();
            List<VehicleLight> mvehs = new List<VehicleLight>();

            //mVisitDetailModel.SelectedPersonnel = new List<object>();
            //mVisitDetailModel.VisitEquipment = mvehs;

            List<string> Tokens = new List<string>();
            for (int n=0; n<mVehicles.Count;n++)
            {
                Tokens.Add(mVehicles[n].VehicleRegNumber);
            }

            //mVisitDetailModel.Tokens.Add("Jerry2");
            //mVisitDetailModel.Items = new List<Object>();
            //mVisitDetailModel.Items.Add("Jerry1");
            //mVisitDetailModel.Items.Add(2);

            ViewData["AssignmentId"] = aAssignmentId;
            ViewData["Tokens"] = Tokens;
            mVisitDetailModel.AssignmentGuid = aAssignmentId;
            //List<Vehicle> mveh = new List<Vehicle>();
            //for (int k = 0; k < 10;k++ )
            //{
            //    mveh.Add(new Vehicle(k, 1, 1, "XA-999"+k.ToString(), 2, true, "", ""));
            //}

            //mDetsModel.VisitEquipment = mVehicles;//IncidentProvider.GetVehiclesForDepartmetId(GetCurrentUser().DepartmentId);

            return PartialView("VisitPartialView", mVisitDetailModel);
        }


        [HttpPost]
        public ActionResult VisitDetailsSave([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))] VisitDetailsModel aModel)
        {
            //ViewData["AssignmentId"] = aModel.AssignmentGuid;
            //VisitDetailsModel mDetsModel = new VisitDetailsModel();
            VisitDetailsModel mVisitDetailModel = new VisitDetailsModel();
            List<VisitCrewLight> mVCL = new List<VisitCrewLight>();
            List<Personnel> mPersonnel = (List<Personnel>)IncidentProvider.GetPersonnelforrDepartmentId(GetCurrentUser().DepartmentId).ToList();

            for (int n = 0; n < mPersonnel.Count; n++)
            {
                mVCL.Add(new VisitCrewLight() { ID = n, VisitCrewName = mPersonnel[n].PersonnelName });
            }

            List<Vehicle> mVehicles = IncidentProvider.GetVehiclesForDepartment(GetCurrentUser().DepartmentId).ToList();
            List<VehicleLight> mvehs = new List<VehicleLight>();

            List<string> Tokens = new List<string>();

            for (int n = 0; n < mVehicles.Count; n++)
            {
                Tokens.Add(mVehicles[n].VehicleRegNumber);
            }
            ViewData["Tokens"] = Tokens;
            return View("VisitPartialView", mVisitDetailModel);
            //return View("Index");
        }

        public ActionResult GetAllAssignmentComments(Guid aTaskId)
        {
            //string teststring = "sghcvgihvoerhgvqwiopehehgggvwumhgdfhgpvghvrtghgri\n\rsdfbgadfjkgbfvuigbuigbiodvgbiogvbiodg\n\rfdjgbvsdfuhgvbiosdfubh dfuibhsdfuiohvhgid";
            string mAllComments = IncidentProvider.GetAllCommentsForTask(aTaskId);
            ViewData["AllComments"] = IncidentProvider.StripHTML(mAllComments);
            return PartialView("CommentsPartialView");
        }

        public ActionResult IncidentState(string aparameter)
        {
            string mStatus = IncidentProvider.GetIncidentStatus(Guid.Parse(aparameter));
            ViewData["IncidentState"] = mStatus;
            return PartialView("StateViewPartial", IncidentProvider.GetStatusDefinitions(aparameter));
        }

        //
        // 08.01.2018, Andreas Kasapleris
        // code improvement; comments are passed when PORTAL calls 1022 Web Service
        // to update status of an Incident
        //
        // 22.05.2018, Andreas Kasapleris
        // fixed code issue with UTF-8 Greek characters
        // added case 8=Αφορά Αποχέτευση
        //
        public void SaveIncidentState(
            string aparameter,
            int anewstate,
            string acomment,
            string anewsectorid,
            string anewdeptid)
        {
            try
            {
                var incidentId = Guid.Parse(aparameter);
                var currentUser = GetCurrentUser();

                // Verify that the incident exists.
                var incident = IncidentProvider.GetIncidentById(incidentId, currentUser);
                if (incident == null)
                {
                    throw new ApplicationException(string.Format("The incident with id: {0} does not exist.", incidentId));
                }

                // Verify that the incident status has indeed changed.
                if (incident.Status != anewstate)
                {
                    SaveIncidentStateImplementation(incidentId, anewstate, acomment, anewsectorid, anewdeptid, currentUser);
                }
            }
            catch (Exception exception)
            {
                Logger.Instance().Error("Failed Save Incident State", exception);
            }
        }

        // TODO: This logic needs to go somewhere else.
        protected void SaveIncidentStateImplementation(
            Guid incidentId,
            int newState,
            string comment,
            string newSectorId,
            string newDepartmentId,
            UsersModel currentUser)
        {
            DataTable mRelatedTable = IncidentProvider.UpdateIncidentStatus(incidentId, newState, currentUser);

            gr.eydap.dominosrv2.TTUpdateService mDominoService = new TTUpdateService();
            string TicketTraceId = IncidentProvider.GetTicketTraceId(incidentId);
            string dtstring = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (newState == 3 || newState == 4 || newState == 6)
            {
                //
                // 22.05.2018, Andreas Kasapleris
                //
                //RESPONSE mRESPONSE = mDominoService.UPDATEDRAINSTT(TicketTraceId, "ΟΛΟΚΛΗΡΩΜΕΝΟ", dtstring);
                RESPONSE mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(TicketTraceId, "ΟΛΟΚΛΗΡΩΜΕΝΟ", dtstring, comment);
                if (!mRESPONSE.SUCCESS)
                {
                    throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                }

                //
                // 22.05.2018, Andreas Kasapleris, Σχετιζόμενα
                //
                for (int n = 0; n < mRelatedTable.Rows.Count; n++)
                {
                    mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(mRelatedTable.Rows[n][0].ToString(), "ΟΛΟΚΛΗΡΩΜΕΝΟ", dtstring, comment);
                    if (!mRESPONSE.SUCCESS)
                    {
                        throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                    }
                }
            }
            else if (newState == 5) // 22.05.2018, Andreas Kasapleris, 5=ΑΚΥΡΟ (ΑΦΟΡΑ ΑΚΥΡΩΣΗ ΣΗΜΑΤΟΣ)
            {
                // 22.05.2018, Andreas Kasapleris
                RESPONSE mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(TicketTraceId, "ΑΚΥΡΟ", dtstring, comment);
                if (!mRESPONSE.SUCCESS)
                {
                    throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                }
                IncidentProvider.RejectTicket(incidentId, currentUser);

                //
                // 22.05.2018, Andreas Kasapleris, Σχετιζόμενα
                //
                for (int n = 0; n < mRelatedTable.Rows.Count; n++)
                {
                    mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(mRelatedTable.Rows[n][0].ToString(), "ΑΚΥΡΟ", dtstring, comment);
                    if (!mRESPONSE.SUCCESS)
                    {
                        throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                    }
                }
            }
            else if (newState == 7) // 22.05.2018, Andreas Kasapleris, 7=ΕΠΑΝΑΔΡΟΜΟΛΟΓΗΣΗ (ΣΕ ΑΛΛΟ ΤΟΜΕΑ/ΤΜΗΜΑ)
            {
                //if (IncidentProvider.RerouteToOtherSector(Convert.ToInt32(anewsectorid), Convert.ToInt32(anewsectorid), currentUser))
                {
                    IncidentProvider.UnRouteTicketFromSector(incidentId, currentUser, Convert.ToInt32(newSectorId));
                    IncidentProvider.RerouteToOtherSector(incidentId, Convert.ToInt32(newSectorId), Convert.ToInt32(newDepartmentId), currentUser);
                    IncidentProvider.DeleteTicketFromBackEnd(incidentId);
                    EydapTickets.Controllers.RoutingController.Router.Route(new string[1] { newDepartmentId }, currentUser, incidentId.ToString());
                }
            }
            else if (newState == 8) // 22.05.2018, added by Andreas Kasapleris, 8=ΑΠΟΧΕΤΕΥΣΗ
            {
                //
                // 22.05.2018, Andreas Kasapleris
                //
                //RESPONSE mRESPONSE = mDominoService.UPDATEDRAINSTT(TicketTraceId, "ΟΛΟΚΛΗΡΩΜΕΝΟ", dtstring);
                comment = "Αναδιαβίβαση από Ύδρευση";
                RESPONSE mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(TicketTraceId, "ΟΛΟΚΛΗΡΩΜΕΝΟ-ΑΠΟΧΕΤΕΥΣΗ", dtstring, comment);
                if (!mRESPONSE.SUCCESS)
                {
                    throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                }

                //
                // 22.05.2018, Andreas Kasapleris, Σχετιζόμενα
                //
                for (int n = 0; n < mRelatedTable.Rows.Count; n++)
                {
                    comment = "Αναδιαβίβαση από Ύδρευση";
                    mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(mRelatedTable.Rows[n][0].ToString(), "ΟΛΟΚΛΗΡΩΜΕΝΟ-ΑΠΟΧΕΤΕΥΣΗ", dtstring, comment);
                    if (!mRESPONSE.SUCCESS)
                    {
                        throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                    }
                }
            }
            else
            {
                // 22.05.2018, Andreas Kasapleris, fix UTF-8 Greek characters issue
                RESPONSE mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(TicketTraceId, "ΕΝΕΡΓΟ", dtstring, comment);
                if (!mRESPONSE.SUCCESS)
                {
                    throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                }
                for (int n = 0; n < mRelatedTable.Rows.Count; n++)
                {
                    // 22.05.2018, Andreas Kasapleris, fix UTF-8 Greek characters issue
                    mRESPONSE = mDominoService.UPDATEWATERSUPPLYTT(mRelatedTable.Rows[n][0].ToString(), "ΕΝΕΡΓΟ", dtstring, comment);
                    if (!mRESPONSE.SUCCESS)
                    {
                        throw new Exception("TicketTraceId: " + TicketTraceId + "/" + mRESPONSE.REASON + "/" + mRESPONSE.ERRORCODE);
                    }
                }
            }
        }

        /*public ActionResult StreetsComboBoxPartial(string SelectedMunicipality)
        {
            //int countryID = (Request.Params["CountryID"] != null) ? int.Parse(Request.Params["CountryID"]) : -1;
            List<Street> mList = new List<Street>();
            mList.Add(new Street(1, SelectedMunicipality + "Name 1"));
            mList.Add(new Street(2, SelectedMunicipality + "Name 2"));
            mList.Add(new Street(3, SelectedMunicipality + "Name 3"));
            mList.Add(new Street(4, SelectedMunicipality + "Name 4"));
            ViewData["Streets"] = mList;
            return PartialView(ViewData["Streets"]);
        }*/

        public ActionResult GetDepartmentTaskTypes(int? departmentId)
        {
            var taskTypes = (departmentId.HasValue && departmentId.Value > 0)
                ? TaskTypeProvider.GetActiveTaskTypesForDepartment(departmentId.Value)
                : new List<TaskType>();

            return GridViewExtension.GetComboBoxCallbackResult(p => {
                p.TextField = "Description";
                p.ValueField = "Id";
                p.ValueType = typeof(int);
                p.BindList(taskTypes);
            });
        }

        public ActionResult GetCities(string aMunicipality, string textField)
        {
            string mMunicipality = (Request.Params["SelectedMunicipality"] != null) ? Request.Params["SelectedMunicipality"] : null;

            List<SelectListItem> mstreets =  IncidentProvider.GetIncidentStreetNames(mMunicipality);

            List<Street> mStreets = new List<Street>();
            for (int n=0; n< mstreets.Count;n++)
            {
                mStreets.Add(new Street(n, mstreets[n].Text));
            }
            return GridViewExtension.GetComboBoxCallbackResult(p => {
                p.TextField = textField;
                p.BindList(mStreets);
            });
        }

        public ActionResult StreetsComboBoxPartial(string aMunicipality)
        {
            string mMunicipality = (Request.Params["SelectedMunicipality"] != null) ? Request.Params["SelectedMunicipality"] : null;
            List<SelectListItem> mStreets = null;


            //mMunicipality = "¢ÈÇÍÁ";
            ViewData["Municipality"] = mMunicipality;

            if (!String.IsNullOrEmpty(mMunicipality))
            {
                mStreets = IncidentProvider.GetIncidentStreetNames(mMunicipality);
            }

            if (mStreets != null)
            {
                //List<Street> mStreetsList = new List<Street>();
                //for (int n = 0; n < mStreets.Length;n++)
                //{
                //    mStreetsList.Add(new Street(n, mStreets[n]));
                //}
                ViewData["Streets"] = mStreets;
            }
            else
            {
                ViewData["Streets"] = new List<Street>();
            }
            //return PartialView("FilterComboBox");
            //return PartialView("IncidentsPartialView");
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult AccessRequired()
        {
            //string mUser = this.GetCurrentUser().Name;logout
            //ViewData["UserName"] = mUser;
            return View();
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies["TSWA-Last-User"];

            //clear cache from current user
            ClearUserFromCache();
            Logger.Instance().Info("Entering Logout routine with Identity NameL" + User.Identity.Name);
            if (User.Identity.IsAuthenticated == false || cookie == null || StringComparer.OrdinalIgnoreCase.Equals(User.Identity.Name, cookie.Value))
            {
                Logger.Instance().Info(" Entering if case of logout..... ");
                string name = string.Empty;
                if (Request.IsAuthenticated)
                {
                    name = User.Identity.Name;
                }

                cookie = new HttpCookie("TSWA-Last-User", name);
                Response.Cookies.Set(cookie);

                Response.AppendHeader("Connection", "close");
                Response.StatusCode = 401; // Unauthorized;
                Response.Clear();

                Response.Write("Unauthorized. Reload the page to try again...");
                Response.End();
                return RedirectToAction("Index");
            }

            Logger.Instance().Info(" Logging out cookies expired..... ");
            cookie = new HttpCookie("TSWA-Last-User", string.Empty)
            {
                Expires = DateTime.Now.AddYears(-5)
            };

            Response.Cookies.Set(cookie);
            return RedirectToAction("Index");
        }


        public ActionResult AjaxTTInfoPartial(string aparameter)
        {
            ViewBag.IncidentId = aparameter;
            IEnumerable<IncidentRoutingElement> mLog = IncidentProvider.GetIncidentLog(Guid.Parse(aparameter));

            return PartialView("TTInfoView", mLog);
        }
    }
}