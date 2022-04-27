using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Areas.Reporting.Models;

namespace EydapTickets.Areas.Reporting.Controllers
{
	public class StatisticalController : BaseController
	{
		// GET: Reports/Reports
		public ActionResult Index()
		{
			// see Views\Shared\HeaderPartialView.cshtml
			// do not show buttons
			ViewBag.ShowMainButtonStrip = false;

			var model = FetchReports();

			return View(model);
		}

		protected IList<Report> FetchReports()
		{
			var currentUser = GetCurrentUser();

			var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

			var sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandType = CommandType.Text,
				CommandText = @"
					SELECT
						r.*
					FROM 
						Report r
						INNER JOIN ReportDepartment rd ON rd.ReportId = r.ReportId
					WHERE 
						1 = 1
						AND rd.DepartmentId = @DepartmentId
						AND r.ReportTypeId = 2
						AND r.Enabled = 1"
			};

			sqlCommand.Parameters.AddWithValue("@DepartmentId", currentUser.DepartmentId);

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

			var reports = new List<Report>();

			if (sqlDataReader == null)
			{
				return reports;
			}

			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					var report = new Report
					{
						ReportId      = sqlDataReader.GetInt32(0),
						Name          = sqlDataReader.GetString(1),
						Description   = sqlDataReader.IsDBNull(2) ? string.Empty : sqlDataReader.GetString(2),
						Url           = sqlDataReader.GetString(3),
						Enabled       = sqlDataReader.GetBoolean(4),
						ReportGroupId = sqlDataReader.GetInt32(5),
						ReportTypeId  = sqlDataReader.GetInt32(6)
					};

					reports.Add(report);
				}
			}

			sqlDataReader.Close();
			sqlDataReader.Dispose();

			sqlConnection.Close();
			sqlConnection.Dispose();

			return reports;
		}
	}
}