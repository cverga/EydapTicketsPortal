using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Web.Mvc;
using EydapTickets.Areas.Reporting.Models;
using EydapTickets.Helpers;

namespace EydapTickets.Areas.Reporting.Controllers
{
    public class Report0700Controller : BaseController
    {
        // GET: Report700
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Report0700SearchModel();

            PrepareModel(model);

            return View(model);
        }

        // POST: Report700
        [HttpPost, ActionName("Index")]
        [SetTempDataModelState]
        public ActionResult IndexPost(Report0700SearchModel model)
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
                    model.TaskState
                );
            }

            return View(model);
        }

        public ActionResult GridViewCallback(Report0700SearchModel model)
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
                model.TaskState
            );

            ViewBag.CriteriaModel = model;

            return PartialView("_ResultsGridViewPartial", model.Results);
        }

        protected void PrepareModel(Report0700SearchModel model)
        {
            var currentUser = GetCurrentUser();

            model.SectorId = currentUser.SectorId;
            model.DepartmentId = currentUser.DepartmentId;
        }

        protected IList<Report0700Result> FetchResults(
            int      sectorId,
            DateTime dateFrom,
            DateTime dateTo,
            string   municipality,
            string   streetName,
            string   streetNumber,
            string   taskType,
            string   taskState)
        {
            // Improvement for date format, 09.05.2018, Andreas Kasapleris
            var cultureInfo = new CultureInfo("el-GR"); // needed for dd/mm/yyyy format

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
                    SELECT *
                    FROM
                    (
                        SELECT
                            i.ID1022              AS ID1022,
                            t.DepartmentId        AS DepartmentId,
                            t.TaskTypeId          AS TaskTypeId,
                            i.Perioxi             AS Perioxi,
                            i.Municipality        AS Municipality,
                            i.Street_Name         AS Street_Name,
                            i.Street_Number       AS Street_Number,
                            i.Odos2               AS Odos2,
                            t.Task_Description    AS Task_Description,
                            t.State               AS State,
                            v.DateOfAssignment    AS DateOfAssignment,
                            t.ClosingDate         AS DateOfCompletion,
                            v.Remarks             AS Remarks,
                            i.HmerominiaAnagelias AS HmerominiaAnagelias,
                            v.Energeies           AS Energeies,
                            (SELECT ProblemDescription          FROM ProblemsCategories WHERE ProblemCategoryId  = v.ProblemCategory)  AS ProblemDescription,
                            (SELECT EidosProblimatosDescription FROM ProblemsEidos      WHERE EidosProblimatosId = v.EidosProblematos) AS EidosProblimatosDescription,
                            v.Diagnosi            AS Diagnosis,
                            v.Symperasma          AS Conclusion,
                            v.AssignmentId        AS AssingmentId
                        FROM
                            Tasks t, Incidents i, Visits v
                        WHERE
                            t.DepartmentId    = 1109
                            AND t.Incident_Id = i.TT_Id
                            AND t.Incident_Id = v.Incident_Id
                            AND t.Task_Id     = v.Task_Id
                            AND t.TaskTypeId  = v.TaskTypeId
                    ) RESULTS
                    WHERE 1 = 1"
            };

            sqlCommand.CommandText += string.Format(" AND HmerominiaAnagelias >= CONVERT(DATETIME, '{0}', 103) ", dtFrom);
            sqlCommand.CommandText += string.Format(" AND HmerominiaAnagelias <  CONVERT(DATETIME, '{0}', 103) ", dtTo);

            // mCommand.Parameters.AddWithValue("@sectorid", mUser.SectorId);
            // mCommand.CommandText += String.Format(" AND SectorId     = {0} ", mUser.SectorId);
            // mCommand.CommandText += String.Format(" AND DepartmentId = {0} ", mUser.DepartmentId);

            // mCommand.Parameters.AddWithValue("@fromdate", fromdate.AddDays(-1));
            // mCommand.Parameters.AddWithValue("@todate",   todate.AddDays(1));

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
                sqlCommand.CommandText += " AND Task_Description = @TaskType ";
                sqlCommand.Parameters.AddWithValue("@TaskType", taskType);
            }

            if (!string.IsNullOrEmpty(taskState))
            {
                sqlCommand.CommandText += " AND State = @TaskState ";
                sqlCommand.Parameters.AddWithValue("@TaskState", taskState);
            }

            sqlCommand.CommandText += " ORDER BY HmerominiaAnagelias ASC ";

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

            var results = new List<Report0700Result>();

            if (sqlDataReader == null)
            {
                return results;
            }

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var result = new Report0700Result
                    {
                        ID1022                      = sqlDataReader.IsDBNull(0) ? string.Empty : sqlDataReader.GetString(0),
                        DepartmentId                = sqlDataReader.GetInt32(1),
                        TaskTypeId                  = sqlDataReader.GetInt32(2),
                        Perioxi                     = sqlDataReader.IsDBNull(3) ? string.Empty : sqlDataReader.GetString(3),
                        Municipality                = sqlDataReader.IsDBNull(4) ? string.Empty : sqlDataReader.GetString(4),
                        Street_Name                 = sqlDataReader.IsDBNull(5) ? string.Empty : sqlDataReader.GetString(5),
                        Street_Number               = sqlDataReader.IsDBNull(6) ? string.Empty : sqlDataReader.GetString(6),
                        Odos2                       = sqlDataReader.IsDBNull(7) ? string.Empty : sqlDataReader.GetString(7),
                        Task_Description            = sqlDataReader.IsDBNull(8) ? string.Empty : sqlDataReader.GetString(8),
                        State                       = sqlDataReader.IsDBNull(9) ? string.Empty : sqlDataReader.GetString(9),
                        DateOfAssignment            = sqlDataReader.IsDBNull(10) ? null as DateTime? : sqlDataReader.GetDateTime(10),
                        DateOfCompletion            = sqlDataReader.IsDBNull(11) ? null as DateTime? : sqlDataReader.GetDateTime(11),
                        Remarks                     = sqlDataReader.IsDBNull(12) ? string.Empty : sqlDataReader.GetString(12),
                        HmerominiaAnagelias         = sqlDataReader.IsDBNull(13) ? null as DateTime? : sqlDataReader.GetDateTime(13),
                        Energeies                   = sqlDataReader.IsDBNull(14) ? string.Empty : sqlDataReader.GetString(14),
                        ProblemDescription          = sqlDataReader.IsDBNull(15) ? string.Empty : sqlDataReader.GetString(15),
                        EidosProblimatosDescription = sqlDataReader.IsDBNull(16) ? string.Empty : sqlDataReader.GetString(16),
                        Diagnosis                   = sqlDataReader.IsDBNull(17) ? string.Empty : sqlDataReader.GetString(17),
                        Conclusion                  = sqlDataReader.IsDBNull(18) ? string.Empty : sqlDataReader.GetString(18),
                        AssignmentId                = sqlDataReader.GetGuid(19) // key
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
