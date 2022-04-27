using EydapTickets.Models;
using SharedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using EydapTickets.Utils;

namespace EydapTickets.Controllers
{
    [System.Web.Mvc.Authorize]
    public class IntegrationController : ApiController
    {
        [System.Web.Mvc.AllowAnonymous]
        public IHttpActionResult TabletAction(TabletIncidentReportModel aTabletIncidentReportModel)
        {
            try
            {
                IncidentProvider.SaveIncidentFromTablet(aTabletIncidentReportModel.TTId, aTabletIncidentReportModel.ReportFromTheField);
            }
            catch (Exception e)
            {
                Logger.Instance().Error("Tablet Action Failed ", e);
                return  BadRequest(e.Message);
            }
            return StatusCode(HttpStatusCode.Accepted);
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpPut]
        //[System.Web.Http.Route("api/Integration/")]
        public IHttpActionResult RouteTicketExternal()
        {
            try
            {
                string aParameters = Request.Content.ReadAsStringAsync().Result;
                string[] mParameters = aParameters.Split(new char[1] { ',' });
                Models.UsersModel mUsersModel = new Models.UsersModel();
                mUsersModel.UserName = mParameters[1];
                mUsersModel.Name = mParameters[1];
                string[] mDepartments = new string[mParameters.Length - 2];
                for (int n = 2; n < mParameters.Length; n++)
                {
                    mDepartments[n - 2] = mParameters[n];
                }
                EydapTickets.Controllers.RoutingController.Router.Route(mDepartments, mUsersModel, mParameters[0], IncidentProvider.IsTicketRelated(Guid.Parse(mParameters[0])));
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                Logger.Instance().Error("Failed RouteTicketExternal() ", e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            //return new string[] { "Jerry", "Chiotelis" };
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpPut]
        [System.Web.Mvc.Route("UpdateTicketSubSectors")]
        public IHttpActionResult UpdateTicketSubSectors(/*[FromBody]string id*/)
        {
            string aParameters = Request.Content.ReadAsStringAsync().Result;

            // mParameters[0] = EydapFieldWors.Incident.ID, κωδικός (ID) του Incident
            // στην εφαρμογή του BackEnd (that's the BackEndTabletId in our Tasks SQL
            // table. Keeps relation between a Task in Portal and of an Incident in
            // BackEnd app)
            // mParameters[1] = True/False, εάν χαρακτηρίστηκε 'Διεκπαιρεωμένο' στο BackEnd
            // mParameters[2] = True/False, εάν απαιτείται Εργασία στο Τμήμα Ερευνών-Κατασκευών
            // mParameters[3] = True/False, εάν είναι προώθηση προς το Τμήμα Ερευνών-Κατασκευών
            // mParameters[4....x] = TaskTypeIds, ο τύπος των Εργασιών (Task) που πρέπει να
            // εκτελέσει το Τμήμα Ερευνών-Κατασκευών


            string[] mParameters = aParameters.Split(new char[1] { ';' });

            IncidentProvider.CloseTask(mParameters[0]);


            int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(mParameters[0]);
            String vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(mParameters[0]);

            // create new task for Ερευνων


            int vDepartmentId = 0;
            switch (vSectorId)
            {
                case 2:
                    vDepartmentId = 1038; // ΕΡΕΥΝΩΝ ΠΕΙΡΑΙΑΣ
                    break;
                case 3:
                    vDepartmentId = 1042; // ΕΡΕΥΝΩΝ ΗΡΑΚΛΕΙΟΥ
                    break;
            }

            int nrRecs2 = IncidentProvider.createTaskForMaintainance(
                                            Guid.NewGuid(),
                                            "ΣΥΝΤΗΡΗΣΗ-ΕΠΙΣΚΕΥΗ ΒΛΑΒΗΣ ΔΙΚΤΥΟΥ",
                                            "Αυτόματη Εργασία σε εξέλιξη ...",
                                            "Ανοιχτή",
                                            1063,
                                            Guid.Parse(vIncidentId),
                                            vSectorId,
                                            vDepartmentId,
                                            mParameters[0]);

            int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
            if (deptsFound == 0)
            {
                // if Incident is NOT routed to Ερευνών-Κατασκευών, create the RoutingHistory
                int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                // 29.05.2017, Andreas Kasapleris
                // then create a record in RoutingHistorylog table
                if (nrRecs0 > 0)
                {
                    int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                }
            }

            return StatusCode(HttpStatusCode.Accepted);
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpPut]
        //[System.Web.Http.Route("api/Integration/UpdateTicket")]
        public IHttpActionResult UpdateTicketFromBackend()
        {
            try
            {
                string aParameters = Request.Content.ReadAsStringAsync().Result;

                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(aParameters);


                //
                // 29.05.2017, Andreas Kasapleris
                // mParameters[0] = EydapFieldWors.Incident.ID, κωδικός (ID) του Incident
                // στην εφαρμογή του BackEnd (that's the BackEndTabletId in our Tasks SQL
                // table. Keeps relation between a Task in Portal and of an Incident in
                // BackEnd app)
                // mParameters[1] = True/False, εάν χαρακτηρίστηκε 'Διεκπαιρεωμένο' στο BackEnd
                // mParameters[2] = True/False, εάν απαιτείται Εργασία στο Τμήμα Ερευνών-Κατασκευών
                // mParameters[3] = True/False, εάν είναι προώθηση προς το Τμήμα Ερευνών-Κατασκευών
                // mParameters[4....x] = TaskTypeIds, ο τύπος των Εργασιών (Task) που πρέπει να
                // εκτελέσει το Τμήμα Ερευνών-Κατασκευών
                //

                if (data.IsArchived.Value  && !data.IsRouted.Value)
                //if (mParameters[3] == "False")
                {
                    // Close the task here
                    IncidentProvider.CloseTask(Convert.ToString(data.IncidentId.Value), data.IncidentDateClosed.Value, data.IncidentComments.Value);

                    //
                    // 23.05.2017, Andreas Kassapleris
                    // once Task is closed for Τμήμα Βλαβών-Συντήρησης automatically
                    // create a Task for Τμήμα Ερευνών-Κατασκευών in Portal
                    //
                    {
                        //
                        // in order to create the task for Τμήμα Ερευνών-Κατασκευών
                        // you first need to find some data ...
                        // with BackEndTabletId search Tasks to find the appropriate SectorId
                        //

                        if (data.IsPortalActionRequired.Value)
                        {
                            int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));
                            string vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));

                            int vDepartmentId = 0;
                            switch (vSectorId)
                            {
                                case 1:
                                    vDepartmentId = 1031; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΑΘΗΝΑΣ
                                    break;
                                case 2:
                                    vDepartmentId = 1038; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΠΕΙΡΑΙΑΣ
                                    break;
                                case 3:
                                    vDepartmentId = 1042; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΗΡΑΚΛΕΙΟΥ
                                    break;
                            }

                            //
                            // if Incident is already routed to Ερευνών-Κατασκευών, you don't need
                            // to create a record in RoutingHistory table; just create the Task
                            //

                            int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                            if (deptsFound == 0)
                            {
                                // if Incident is NOT routed to Ερευνών-Κατασκευών, create the RoutingHistory
                                int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                                // 29.05.2017, Andreas Kasapleris
                                // then create a record in RoutingHistorylog table
                                if (nrRecs0 > 0)
                                {
                                    int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                                }
                            }

                            // continue ...
                            // now automatically create a new Task for Ερευνών-Κατασκευών under Incident
                            // this Task will be related to the BackEndTabletId (Incident.ID in EydapFieldWorks db)
                            // storing the relation (TaskId/BackEndTabletId) in table Tasks, you can then call
                            // the Edit_FullCutDown form of BackEnd
                            //

                            //
                            // 13.06.2017, Andreas Kasapleris
                            // support for multiple Tasks for Ereunon dept sent from BackEnd app
                            //

                            //string[] TasksForEreunon = mParameters[3]; // split mParameters[3] into Task ids

                            foreach (var taskId in data.PortalSelectedTasks)
                            {
                                // 13.06.2017, Andreas Kasapleris, commented out
                                // previous implementation, there was only one Task for Ereunon sent from BackEnd
                                // string vTaskDescription = IncidentProvider.findTaskDescription(Convert.ToInt32(mParameters[3]));

                                int taskforereunon = Convert.ToInt32(taskId);
                                string vTaskDescription = IncidentProvider.findTaskDescription(taskforereunon);

                                // 13.06.2017, Andreas Kasapleris, commented out
                                // Insert a record in Tasks table
                                //int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                //                        Guid.NewGuid(),
                                //                        vTaskDescription,
                                //                        "Αυτόματη Εργασία σε εξέλιξη ...",
                                //                        "Ανοιχτή",
                                //                        Convert.ToInt32(mParameters[3]),
                                //                        Guid.Parse(vIncidentId),
                                //                        vSectorId,
                                //                        vDepartmentId,
                                //                        mParameters[0]);

                                // 13.06.2017, Andreas Kasapleris
                                int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                                        Guid.NewGuid(),
                                                        vTaskDescription,
                                                        "Αυτόματη Εργασία σε εξέλιξη ...",
                                                        "Ανοιχτή",
                                                        taskforereunon,
                                                        Guid.Parse(vIncidentId),
                                                        vSectorId,
                                                        vDepartmentId,
                                                        Convert.ToString(data.IncidentId.Value));

                            } // foreach
                        }
                    }
                } // end of Task creation for Τμήμα Ερευνών-Κατασκευών

                else if (data.IsRouted.Value)
                {
                    IncidentProvider.CloseTask(Convert.ToString(data.IncidentId.Value));
                    if (data.IsPortalActionRequired.Value)
                    {
                        int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));
                        string vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));

                        int vDepartmentId = 0;
                        switch (vSectorId)
                        {
                            case 1:
                                vDepartmentId = 1031; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΑΘΗΝΑΣ
                                break;
                            case 2:
                                vDepartmentId = 1038; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΠΕΙΡΑΙΑΣ
                                break;
                            case 3:
                                vDepartmentId = 1042; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΗΡΑΚΛΕΙΟΥ
                                break;
                        }

                        //
                        // if Incident is already routed to Ερευνών-Κατασκευών, you don't need
                        // to create a record in RoutingHistory table; just create the Task
                        //

                        int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                        if (deptsFound == 0)
                        {
                            // if Incident is NOT routed to Ερευνών-Κατασκευών, create the RoutingHistory
                            int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                            // 29.05.2017, Andreas Kasapleris
                            // then create a record in RoutingHistorylog table
                            if (nrRecs0 > 0)
                            {
                                int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                            }
                        }

                        foreach (var taskId in data.PortalSelectedTasks)
                        {
                            // 13.06.2017, Andreas Kasapleris, commented out
                            // previous implementation, there was only one Task for Ereunon sent from BackEnd
                            // string vTaskDescription = IncidentProvider.findTaskDescription(Convert.ToInt32(mParameters[3]));

                            int taskforereunon = Convert.ToInt32(taskId);
                            string vTaskDescription = IncidentProvider.findTaskDescription(taskforereunon);

                            // 13.06.2017, Andreas Kasapleris, commented out
                            // Insert a record in Tasks table
                            //int nrRecs2 = IncidentProvider.createTaskForEreunon(
                            //    Guid.NewGuid(),
                            //    vTaskDescription,
                            //    "Αυτόματη Εργασία σε εξέλιξη ...",
                            //    "Ανοιχτή",
                            //    Convert.ToInt32(mParameters[3]),
                            //    Guid.Parse(vIncidentId),
                            //    vSectorId,
                            //    vDepartmentId,
                            //    mParameters[0]);

                            // 13.06.2017, Andreas Kasapleris
                            int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                Guid.NewGuid(),
                                vTaskDescription,
                                "Αυτόματη Εργασία σε εξέλιξη ...",
                                "Ανοιχτή",
                                taskforereunon,
                                Guid.Parse(vIncidentId),
                                vSectorId,
                                vDepartmentId,
                                Convert.ToString(data.IncidentId.Value));

                        } // foreach
                    }
                }
                else
                {
                    IncidentProvider.CloseTask(Convert.ToString(data.IncidentId.Value));
                    // create new task for Maintenance
                    int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));
                    string vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(Convert.ToString(data.IncidentId.Value));

                    int vDepartmentId = 0;
                    switch (vSectorId)
                    {
                        case 1:
                            vDepartmentId = 1033; // ΣΥΝΤΗΡΗΣΗ ΑΘΗΝΑΣ
                            break;
                        case 2:
                            vDepartmentId = 1039; // ΣΥΝΤΗΡΗΣΗ ΠΕΙΡΑΙΑΣ
                            break;
                        case 3:
                            vDepartmentId = 1043; // ΣΥΝΤΗΡΗΣΗ ΗΡΑΚΛΕΙΟΥ
                            break;
                    }

                    int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                    if (deptsFound == 0)
                    {
                        int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                        // 29.05.2017, Andreas Kasapleris
                        // then create a record in RoutingHistorylog table
                        if (nrRecs0 > 0)
                        {
                            int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                        }
                    }

                    int nrRecs2 = IncidentProvider.createTaskForMaintainance(
                        Guid.NewGuid(),
                        "ΣΥΝΤΗΡΗΣΗ-ΕΠΙΣΚΕΥΗ ΒΛΑΒΗΣ ΔΙΚΤΥΟΥ",
                        "Αυτόματη Εργασία σε εξέλιξη ...",
                        "Ανοιχτή",
                        1063,
                        Guid.Parse(vIncidentId),
                        vSectorId,
                        vDepartmentId,
                        Convert.ToString(data.IncidentId.Value));
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Error("Failed RouteTicketExternal", e);
            }
            return StatusCode(HttpStatusCode.Accepted);
            //return new string[] { "Jerry", "Chiotelis" };
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpPut]
        //[System.Web.Http.Route("api/Integration/UpdateTicket")]
        public IHttpActionResult UpdateTicket(/*[FromBody]string id*/)
        {
            try
            {
                string aParameters = Request.Content.ReadAsStringAsync().Result;

                string[] mParameters = aParameters.Split(new char[1] { ';' });

                //
                // 29.05.2017, Andreas Kasapleris
                // mParameters[0] = EydapFieldWors.Incident.ID, κωδικός (ID) του Incident
                // στην εφαρμογή του BackEnd (that's the BackEndTabletId in our Tasks SQL
                // table. Keeps relation between a Task in Portal and of an Incident in
                // BackEnd app)
                // mParameters[1] = True/False, εάν χαρακτηρίστηκε 'Διεκπαιρεωμένο' στο BackEnd
                // mParameters[2] = True/False, εάν απαιτείται Εργασία στο Τμήμα Ερευνών-Κατασκευών
                // mParameters[3] = True/False, εάν είναι προώθηση προς το Τμήμα Ερευνών-Κατασκευών
                // mParameters[4....x] = TaskTypeIds, ο τύπος των Εργασιών (Task) που πρέπει να
                // εκτελέσει το Τμήμα Ερευνών-Κατασκευών
                //

                if (mParameters[1] == "True" && mParameters[3] == "False")
                //if (mParameters[3] == "False")
                {
                    // Close the task here
                    IncidentProvider.CloseTask(mParameters[0]);

                    //
                    // 23.05.2017, Andreas Kassapleris
                    // once Task is closed for Τμήμα Βλαβών-Συντήρησης automatically
                    // create a Task for Τμήμα Ερευνών-Κατασκευών in Portal
                    //
                    {
                        //
                        // in order to create the task for Τμήμα Ερευνών-Κατασκευών
                        // you first need to find some data ...
                        // with BackEndTabletId search Tasks to find the appropriate SectorId
                        //

                        if (mParameters[2] == "True")
                        {
                            int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(mParameters[0]);
                            String vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(mParameters[0]);

                            int vDepartmentId = 0;
                            switch (vSectorId)
                            {
                                case 1:
                                    vDepartmentId = 1031; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΑΘΗΝΑΣ
                                    break;
                                case 2:
                                    vDepartmentId = 1038; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΠΕΙΡΑΙΑΣ
                                    break;
                                case 3:
                                    vDepartmentId = 1042; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΗΡΑΚΛΕΙΟΥ
                                    break;
                            }

                            //
                            // if Incident is already routed to Ερευνών-Κατασκευών, you don't need
                            // to create a record in RoutingHistory table; just create the Task
                            //

                            int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                            if (deptsFound == 0)
                            {
                                // if Incident is NOT routed to Ερευνών-Κατασκευών, create the RoutingHistory
                                int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                                // 29.05.2017, Andreas Kasapleris
                                // then create a record in RoutingHistorylog table
                                if (nrRecs0 > 0)
                                {
                                    int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                                }
                            }

                            // continue ...
                            // now automaticaly create a new Task for Ερευνών-Κατασκευών under Incident
                            // this Task will be related to the BackEndTabletId (Incident.ID in EydapFieldWorks db)
                            // storing the relation (TaskId/BackEndTabletId) in table Tasks, you can then call
                            // the Edit_FullCutDown form of BackEnd
                            //

                            //
                            // 13.06.2017, Andreas Kasapleris
                            // support for multiple Tasks for Ereunon dept sent from BackEnd app
                            //

                            //string[] TasksForEreunon = mParameters[3]; // split mParameters[3] into Task ids

                            for (int k = 4; k < mParameters.Length;k++ )
                            {
                                // 13.06.2017, Andreas Kasapleris, commented out
                                // previous implementation, there was only one Task for Ereunon sent from BackEnd
                                // string vTaskDescription = IncidentProvider.findTaskDescription(Convert.ToInt32(mParameters[3]));

                                int taskforereunon = Convert.ToInt32(mParameters[k]);
                                string vTaskDescription = IncidentProvider.findTaskDescription(taskforereunon);

                                // 13.06.2017, Andreas Kasapleris, commented out
                                // Insert a record in Tasks table
                                //int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                //                        Guid.NewGuid(),
                                //                        vTaskDescription,
                                //                        "Αυτόματη Εργασία σε εξέλιξη ...",
                                //                        "Ανοιχτή",
                                //                        Convert.ToInt32(mParameters[3]),
                                //                        Guid.Parse(vIncidentId),
                                //                        vSectorId,
                                //                        vDepartmentId,
                                //                        mParameters[0]);

                                // 13.06.2017, Andreas Kasapleris
                                int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                                        Guid.NewGuid(),
                                                        vTaskDescription,
                                                        "Αυτόματη Εργασία σε εξέλιξη ...",
                                                        "Ανοιχτή",
                                                        taskforereunon,
                                                        Guid.Parse(vIncidentId),
                                                        vSectorId,
                                                        vDepartmentId,
                                                        mParameters[0]);

                            } // foreach
                        }
                    }
               } // end of Task creation for Τμήμα Ερευνών-Κατασκευών

                else if (mParameters[3] == "True")
                {
                    IncidentProvider.CloseTask(mParameters[0]);
                    if (mParameters[2] == "True")
                    {
                        int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(mParameters[0]);
                        String vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(mParameters[0]);

                        int vDepartmentId = 0;
                        switch (vSectorId)
                        {
                            case 1:
                                vDepartmentId = 1031; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΑΘΗΝΑΣ
                                break;
                            case 2:
                                vDepartmentId = 1038; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΠΕΙΡΑΙΑΣ
                                break;
                            case 3:
                                vDepartmentId = 1042; // ΕΡΕΥΝΩΝ-ΚΑΤΑΣΚΕΥΩΝ ΗΡΑΚΛΕΙΟΥ
                                break;
                        }

                        //
                        // if Incident is already routed to Ερευνών-Κατασκευών, you don't need
                        // to create a record in RoutingHistory table; just create the Task
                        //

                        int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                        if (deptsFound == 0)
                        {
                            // if Incident is NOT routed to Ερευνών-Κατασκευών, create the RoutingHistory
                            int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                            // 29.05.2017, Andreas Kasapleris
                            // then create a record in RoutingHistorylog table
                            if (nrRecs0 > 0)
                            {
                                int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                            }
                        }

                        for (int k = 4; k < mParameters.Length; k++)
                        {
                            // 13.06.2017, Andreas Kasapleris, commented out
                            // previous implementation, there was only one Task for Ereunon sent from BackEnd
                            // string vTaskDescription = IncidentProvider.findTaskDescription(Convert.ToInt32(mParameters[3]));

                            int taskforereunon = Convert.ToInt32(mParameters[k]);
                            string vTaskDescription = IncidentProvider.findTaskDescription(taskforereunon);

                            // 13.06.2017, Andreas Kasapleris, commented out
                            // Insert a record in Tasks table
                            //int nrRecs2 = IncidentProvider.createTaskForEreunon(
                            //                        Guid.NewGuid(),
                            //                        vTaskDescription,
                            //                        "Αυτόματη Εργασία σε εξέλιξη ...",
                            //                        "Ανοιχτή",
                            //                        Convert.ToInt32(mParameters[3]),
                            //                        Guid.Parse(vIncidentId),
                            //                        vSectorId,
                            //                        vDepartmentId,
                            //                        mParameters[0]);

                            // 13.06.2017, Andreas Kasapleris
                            int nrRecs2 = IncidentProvider.createTaskForEreunon(
                                                    Guid.NewGuid(),
                                                    vTaskDescription,
                                                    "Αυτόματη Εργασία σε εξέλιξη ...",
                                                    "Ανοιχτή",
                                                    taskforereunon,
                                                    Guid.Parse(vIncidentId),
                                                    vSectorId,
                                                    vDepartmentId,
                                                    mParameters[0]);

                        } // foreach
                    }
                }
                else
                {
                    IncidentProvider.CloseTask(mParameters[0]);
                    // create new task for Maintainance
                    int vSectorId = IncidentProvider.findSectorFromBackEndTabletId(mParameters[0]);
                    String vIncidentId = IncidentProvider.findIncidentIdFromBackEndTabletId(mParameters[0]);

                    int vDepartmentId = 0;
                    switch (vSectorId)
                    {
                        case 1:
                            vDepartmentId = 1033; // ΣΥΝΤΗΡΗΣΗ ΑΘΗΝΑΣ
                            break;
                        case 2:
                            vDepartmentId = 1039; // ΣΥΝΤΗΡΗΣΗ ΠΕΙΡΑΙΑΣ
                            break;
                        case 3:
                            vDepartmentId = 1043; // ΣΥΝΤΗΡΗΣΗ ΗΡΑΚΛΕΙΟΥ
                            break;
                    }

                    int deptsFound = IncidentProvider.checkTicketInRoutingHistory(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                    if (deptsFound == 0)
                    {
                        int nrRecs0 = IncidentProvider.RouteToDepartMent(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);

                        // 29.05.2017, Andreas Kasapleris
                        // then create a record in RoutingHistorylog table
                        if (nrRecs0 > 0)
                        {
                            int nrRecs1 = IncidentProvider.createRoutingHistorylog(Guid.Parse(vIncidentId), vSectorId, vDepartmentId);
                        }
                    }



                    int nrRecs2 = IncidentProvider.createTaskForMaintainance(
                                                    Guid.NewGuid(),
                                                    "ΣΥΝΤΗΡΗΣΗ-ΕΠΙΣΚΕΥΗ ΒΛΑΒΗΣ ΔΙΚΤΥΟΥ",
                                                    "Αυτόματη Εργασία σε εξέλιξη ...",
                                                    "Ανοιχτή",
                                                    1063,
                                                    Guid.Parse(vIncidentId),
                                                    vSectorId,
                                                    vDepartmentId,
                                                    mParameters[0]);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Error("Failed RouteTicketExternal", e);
            }
            return StatusCode(HttpStatusCode.Accepted);
            //return new string[] { "Jerry", "Chiotelis" };
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpGet]
        //[System.Web.Http.Route("api/Integration/CloseTE")]
        public IHttpActionResult CloseTE(string aTEID)
        {
            Logger.Instance().Info("CloseTE with aTEID = " + aTEID.ToString());
            return StatusCode(HttpStatusCode.Accepted);
        }

        [System.Web.Mvc.AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
