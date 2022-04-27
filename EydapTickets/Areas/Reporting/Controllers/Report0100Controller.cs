using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Mvc;
using EydapTickets.Areas.Reporting.Models;
using EydapTickets.Helpers;

namespace EydapTickets.Areas.Reporting.Controllers
{
    public class Report0100Controller : BaseController
    {
        // GET: Report0100
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Report0100SearchModel();

            PrepareModel(model);

            return View(model);
        }

        // POST: Report0100
        [HttpPost, ActionName("Index")]
        [SetTempDataModelState]
        public ActionResult IndexPost(Report0100SearchModel model)
        {
            PrepareModel(model);

            if (ModelState.IsValid)
            {
                model.Results = FetchResults(
                    model.SectorId,
                    model.DateFrom,
                    model.DateTo,
                    model.Municipality,
                    model.StreetName,
                    model.StreetNumber,
                    model.TaskType,
                    model.TaskState,
                    model.Contractor
                );
            }

            return View(model);
        }

        public ActionResult GridViewCallback(Report0100SearchModel model)
        {
            PrepareModel(model);

            model.Results = FetchResults(
                model.SectorId,
                model.DateFrom,
                model.DateTo,
                model.Municipality,
                model.StreetName,
                model.StreetNumber,
                model.TaskType,
                model.TaskState,
                model.Contractor
            );

            ViewBag.CriteriaModel = model;

            return PartialView("_ResultsGridViewPartial", model.Results);
        }

        protected void PrepareModel(Report0100SearchModel model)
        {
            var currentUser = GetCurrentUser();

            model.SectorId = currentUser.SectorId;
            model.DepartmentId = currentUser.DepartmentId;
        }

        protected IList<Report0100Result> FetchResults(
            int      sectorId,
            DateTime dateFrom,
            DateTime dateTo,
            string   municipality,
            string   streetName,
            string   streetNumber,
            string   taskType,
            string   taskState,
            string   contractor)
        {
            // Improvement for date format, 05.04.2018, Andreas Kasapleris
            var cultureInfo = new CultureInfo("el-GR"); // needed for dd/mm/yyyy format

            var currentUser = GetCurrentUser();

            var dt1 = DateTime.Parse(dateFrom.ToString(),          cultureInfo);
            var dt2 = DateTime.Parse(dateTo.AddDays(1).ToString(), cultureInfo);

            var dtFrom = string.Format("{0}/{1}/{2} 00:00:00", dt1.Day, dt1.Month, dt1.Year);
            var dtTo   = string.Format("{0}/{1}/{2} 00:00:00", dt2.Day, dt2.Month, dt2.Year);

            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = @"
                    SELECT * FROM
                    (
                        SELECT
                            A.ID1022                          AS ID1022,
                            B.SectorId                        AS SectorId,
                            B.DepartmentId                    AS DepartmentId,
                            B.BackEndTabletId                 AS BackEndTabletId,
                            B.TaskTypeId                      AS TaskTypeId,
                            A.Perioxi                         AS Perioxi,
                            A.Municipality                    AS Municipality,
                            A.Street_Name                     AS Street_Name,
                            A.Street_Number                   AS Street_Number,
                            A.Odos2                           AS Odos2,
                            B.Task_Description                AS Task_Description,
                            B.State                           AS State,
                            C.DateOfAssignment                AS DateOfAssignment,
                            D.ErgName                         AS ErgName,
                            B.ClosingDate                     AS DateOfCompletion,
                            C.Remarks                         AS Remarks,
                            C.AssignmentId                    AS AssingmentId,
                            C.BCC_ErgolaviaNeasParoxis        AS BCC_ErgolaviaNeasParoxis
                        FROM Incidents A, Tasks B, Visits C, Ergolavoi D
                        WHERE
                            A.Sector       = B.SectorId    AND
                            D.SectorId     = B.SectorId    AND
                            A.TT_Id        = B.Incident_Id AND
                            B.Incident_Id  = C.Incident_Id AND
                            B.Task_Id      = C.Task_Id     AND
                            B.TaskTypeId   = C.TaskTypeId  AND
                            B.TaskTypeId   != 1120         AND
                            C.BCC_ErgolaviaNeasParoxis > 0 AND
                            D.SectorId                 = B.SectorId AND
                            C.BCC_ErgolaviaNeasParoxis = D.ErgolavosID
                        UNION
                        (
                            SELECT
                                ID1022,
                                SectorId,
                                DepartmentId,
                                BackEndTabletId,
                                TaskTypeId,
                                Perioxi,
                                Municipality,
                                Street_Name,
                                Street_Number,
                                Odos2,
                                Task_Description,
                                State,
                                DateOfAssignment,
                                ErgName,
                                DateOfCompletion,
                                Remarks,
                                AssignmentId,
                                BCC_ErgolaviaNeasParoxis
                            FROM
                            (
                                SELECT
                                    A.ID1022,
                                    B.SectorId,
                                    B.DepartmentId,
                                    B.BackEndTabletId,
                                    B.TaskTypeId,
                                    A.Perioxi,
                                    A.Municipality  COLLATE Greek_CI_AS AS Municipality,
                                    A.Street_Name   COLLATE Greek_CI_AS As Street_Name,
                                    A.Street_Number COLLATE Greek_CI_AS As Street_Number,
                                    A.Odos2,
                                    B.Task_Description,
                                    B.State,
                                    (
                                        SELECT MAX(A.Assigned)
                                        FROM EydapFieldWorks.[dbo].WorkteamIncidents A
                                        WHERE A.Incident_ID = C.ID
                                        GROUP BY A.Incident_ID
                                    ) AS DateOfAssignment,
                                    (
                                        SELECT TOP 1 LastName
                                        FROM
                                            [EydapFieldWorks].[dbo].AspNetUsers A,
                                            [EydapFieldWorks].[dbo].UsersInWorkTeams B
                                        WHERE
                                            B.WorkTeam_ID = (
                                                SELECT MAX(Workteam_ID)
                                                FROM [EydapFieldWorks].[dbo].WorkteamIncidents
                                                WHERE Incident_ID = C.ID
                                             )
                                             AND B.User_ID = A.Id
                                    ) COLLATE Greek_CI_AS AS ErgName,
                                    C.ArchiveDate AS DateOfCompletion,
                                    E.Paratiriseis COLLATE Greek_CI_AS AS Remarks,
                                    NEWID() AS AssignmentId,
                                    '' AS BCC_ErgolaviaNeasParoxis
                                FROM
                                    [TT_db].[dbo].Incidents A,
                                    [TT_db].[dbo].Tasks B,
                                    [EydapFieldWorks].[dbo].Incident C,
                                    [TT_db].[dbo].Sectors D,
                                    [EydapFieldWorks].[dbo].FinalComments E
                                WHERE
                                    A.TT_Id = B.Incident_Id
                                    AND A.Municipality COLLATE Greek_CI_AS = C.dimos
                                    AND A.Street_Name COLLATE Greek_CI_AS = C.odos1
                                    AND A.Street_Number COLLATE Greek_CI_AS = C.StreetNumber1
                                    AND B.SectorId = A.Sector
                                    AND D.SectorId = B.SectorId
                                    AND B.TaskTypeId = 1120
                                    AND B.BackEndTabletId = C.ID
                                    AND (B.BackEndTabletId IS NOT NULL OR B.BackEndTabletId != '')
                                    AND C.ID = E.Incident_ID
                            ) RESULTS
                        )
                    ) RESULTS1
                WHERE 1 = 1 "
            };

            sqlCommand.CommandText += " AND DateOfAssignment >= CONVERT(DATETIME, @DateFrom, 103) ";
            sqlCommand.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime) {
                Value = dtFrom
            });

            sqlCommand.CommandText += " AND DateOfAssignment < CONVERT(DATETIME, @DateTo, 103) ";
            sqlCommand.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime) {
                Value = dtTo
            });

            sqlCommand.CommandText += " AND SectorId = @SectorId ";
            sqlCommand.Parameters.Add(new SqlParameter("@SectorId", SqlDbType.Int)
            {
                Value = currentUser.SectorId
            });

            sqlCommand.CommandText += " AND DepartmentId = @DepartmentId ";
            sqlCommand.Parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.Int)
            {
                Value = currentUser.DepartmentId
            });

            if (!string.IsNullOrEmpty(municipality))
            {
                sqlCommand.CommandText += " AND Municipality = @Municipality ";
                sqlCommand.Parameters.AddWithValue("@Municipality", municipality);
            }

            if (!string.IsNullOrEmpty(streetName))
            {
                sqlCommand.CommandText += " AND Street_Name = @StreetName ";
                sqlCommand.Parameters.AddWithValue("@StreetName", streetName);
            }

            if (!string.IsNullOrEmpty(streetNumber))
            {
                sqlCommand.CommandText += " AND Street_Number = @StreetNumber ";
                sqlCommand.Parameters.AddWithValue("@StreetNumber", streetNumber);
            }

            if (!string.IsNullOrEmpty(taskType))
            {
                sqlCommand.CommandText += " AND Task_Description = @TaskDescription ";
                sqlCommand.Parameters.AddWithValue("@TaskDescription", taskType);
            }

            if (!string.IsNullOrEmpty(taskState))
            {
                sqlCommand.CommandText += " AND State = @state ";
                sqlCommand.Parameters.AddWithValue("@state", taskState);
            }

            if (!string.IsNullOrEmpty(contractor))
            {
                sqlCommand.CommandText += " AND ErgName = @contractor ";
                sqlCommand.Parameters.AddWithValue("@contractor", contractor);
            }

            sqlCommand.CommandText += " ORDER BY Municipality, DateOfAssignment ASC ";

            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();

            }
            catch (Exception /* exception */)
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            // if not a db error ... continue ...

            var results = new List<Report0100Result>();

            if (sqlDataReader == null)
            {
                return results;
            }

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var result = new Report0100Result
                    {
                        ID1022                   = sqlDataReader.IsDBNull(0) ? string.Empty : sqlDataReader.GetString(0),
                        SectorId                 = sqlDataReader.GetInt32(1),
                        DepartmentId             = sqlDataReader.GetInt32(2),
                        BackEndTabletId          = sqlDataReader.IsDBNull(3) ? string.Empty : sqlDataReader.GetString(3),
                        TaskTypeId               = sqlDataReader.GetInt32(4),
                        Perioxi                  = sqlDataReader.IsDBNull(5) ? string.Empty : sqlDataReader.GetString(5),
                        Municipality             = sqlDataReader.IsDBNull(6) ? string.Empty : sqlDataReader.GetString(6),
                        Street_Name              = sqlDataReader.IsDBNull(7) ? string.Empty : sqlDataReader.GetString(7),
                        Street_Number            = sqlDataReader.IsDBNull(8) ? string.Empty : sqlDataReader.GetString(8),
                        Odos2                    = sqlDataReader.IsDBNull(9) ? string.Empty : sqlDataReader.GetString(9),
                        Task_Description         = sqlDataReader.IsDBNull(10) ? string.Empty : sqlDataReader.GetString(10),
                        State                    = sqlDataReader.IsDBNull(11) ? string.Empty : sqlDataReader.GetString(11),
                        DateOfAssignment         = sqlDataReader.IsDBNull(12) ? (DateTime?)null : sqlDataReader.GetDateTime(12),
                        ErgName                  = sqlDataReader.IsDBNull(13) ? string.Empty : sqlDataReader.GetString(13),
                        DateOfCompletion         = sqlDataReader.IsDBNull(14) ? (DateTime?)null : sqlDataReader.GetDateTime(14),
                        Remarks                  = sqlDataReader.IsDBNull(15) ? string.Empty : sqlDataReader.GetString(15),
                        AssignmentId             = sqlDataReader.GetGuid(16), // key
                        BCC_ErgolaviaNeasParoxis = sqlDataReader.IsDBNull(17) ? string.Empty : sqlDataReader.GetString(17)
                    };

                    results.Add(result);
                }
            }

            sqlDataReader.Close();
            sqlDataReader.Dispose();

            sqlConnection.Close();
            sqlConnection.Dispose();

            return results;
        }
    }
}