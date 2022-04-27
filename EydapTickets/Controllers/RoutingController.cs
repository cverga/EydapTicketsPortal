using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EydapTickets.Models;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using EydapTickets.Utils;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EydapTickets.Controllers
{
	public class RoutingController : BaseController
	{
		// GET: Route
		public ActionResult RouteIndex()
		{
			List<RouteDepartment> mDepartments = new List<RouteDepartment>();
			UsersModel mUser = GetCurrentUser();
			List<DepartmentsModel> mdeps = (List<DepartmentsModel>)UsersDAL.GetDepartmentsForSector(mUser.SectorId, false);
			IEnumerator<DepartmentsModel> mIter = mdeps.GetEnumerator();
			while (mIter.MoveNext())
			{
			    var routeName = !string.IsNullOrEmpty(mIter.Current.FriendlyName)
			        ? mIter.Current.FriendlyName
			        : mIter.Current.DepartmentName;

			    mDepartments.Add(new RouteDepartment(mIter.Current.DepartmentId, routeName, true));
			}
			ViewData["UserDepartment"] = mUser.DepartmentId;
			return PartialView(mDepartments);
		}

		public ActionResult AjaxRoutingPartial(string aparameter)
		{
			ViewBag.IncidentId = aparameter;
			UsersModel mUser = GetCurrentUser();

			List<DepartmentsModel> mdeps = (List<DepartmentsModel>)UsersDAL.GetDepartmentsForSector(mUser.SectorId, false);
			IEnumerable<TTRoute> mRoutes = IncidentProvider.GetRoutedDepartmentsForTicket(Guid.Parse(aparameter));
			List<RouteDepartment> mRouteDepartment = new List<RouteDepartment>();
			IEnumerator<DepartmentsModel> mIter = mdeps.GetEnumerator();
			bool routed = false;
			while (mIter.MoveNext())
			{
			    var routeName = !string.IsNullOrEmpty(mIter.Current.FriendlyName)
			        ? mIter.Current.FriendlyName
			        : mIter.Current.DepartmentName;

				mRouteDepartment.Add(new RouteDepartment(mIter.Current.DepartmentId, routeName, routed));
			}

			IEnumerator<TTRoute> mIterRoutes = mRoutes.GetEnumerator();
			while (mIterRoutes.MoveNext())
			{
				TTRoute mRoute = mIterRoutes.Current;
				int DepartmentId = mRoute.ToDepartmentId;
				RouteDepartment rd = mRouteDepartment.Find((x) => x.DepartmentId == DepartmentId);
				if (rd != null)
				{
					rd.IsRouted = true;
				}
			}
			ViewData["UserDepartment"] = mUser.DepartmentId;
			ViewData["RouteDepartment"] = mRouteDepartment;
			return PartialView("RouteIndex", mRouteDepartment);
		}

		public void Route(string aparameter, string aRRT)
		{
			UsersModel mUser = GetCurrentUser();
			if (aparameter != null)
			{
				string[] selecteddepartments = aparameter.Split(new char[1] { ',' });
				Router.Route(selecteddepartments, mUser, aRRT);
			}
		}

		[AllowAnonymous]
		public void RejectTicket(string aRRT)
		{
			UsersModel mUser = GetCurrentUser();
			IncidentProvider.RejectTicket(Guid.Parse(aRRT), mUser);
		}

		public int UnrouteTicket(string aRRT)
		{
			UsersModel mUser = GetCurrentUser();
			return IncidentProvider.UnRouteTicket(Guid.Parse(aRRT), mUser);
		}

		//
		// 21.04.2017, Andreas Kasapleris
		// Calls POST method to post (send) an Incident which arrived
		// from 1022 to the BackEnd Application
		// Same method definion as in Web Service which imports Tickets/Incidents
		// from 1022 to Portal, namely PostIncidentToTablet. When changes happen there,
		// these changes should also be made here. The method is renamed here to
		// PostIncidentToBackEnd.
		// Returns a string which is the id created at the BackEnd app
		// BackEnd SQL Db [EydapFieldWorks] Table [Incident] field [ID]
		//
		// Commented out by JerryC

		public static string PostIncidentToBackEnd(BackEndIncident aNewIncident)
		{
			string TabletUrlForm = null;

			try
			{
				if (aNewIncident != null)
				{
					var json = new JavaScriptSerializer().Serialize(aNewIncident);
					string lUrl = System.Configuration.ConfigurationManager.AppSettings.Get("TabletWebServiceUrl");

					TabletUrlForm = Router.POSTTOBACKEND(lUrl, json); // 07.04.2017, Andreas Kasapleris

					ExtentedIncident newExtentedIncident = new ExtentedIncident(aNewIncident);
					newExtentedIncident.Propagated = true; // 17.04.2017, Andreas Kasapleris
					newExtentedIncident.BackEndTabletId = TabletUrlForm; // 17.04.2017, Andreas Kasapleris

					//
					// MORE ... TO DO
					//

					// 1. Create the fields Propagated and BackEndTabletId in SQL Table [Incidents]

					// update Incident fields; ticket is propagated to BackEnd and
					// record id created in BackEnd app
					// UpdateIncident(aNewIncident.TTId, TabletUrlForm);

					return TabletUrlForm;

				}
				else
				{
					Logger.Instance().Error("Failed to PostIncidentToBackEnd() ...", null);
				}
			}
			catch (Exception ex)
			{
				Logger.Instance().Error("Failed to PostIncidentToBackEnd()", ex);
			}

			return TabletUrlForm;
		}


	public static class Router
	{
		public static void Route(string[] aSelectedDepartments, UsersModel aUser, string aTTId, bool aIsRelated = false)
		{
			IEnumerable<TTRoute> mRoutes = IncidentProvider.GetRoutedDepartmentsForTicket(Guid.Parse(aTTId));
			for (int n = 0; n < aSelectedDepartments.Length; n++)
			{
				Incident mIncident = IncidentProvider.GetIncidentById(Guid.Parse(aTTId), aUser);
				TTRoute mRoute = mRoutes.FirstOrDefault<TTRoute>((x) => x.ToDepartmentId.ToString() == aSelectedDepartments[n]);
				if (mRoute == null)
				{
					TTRoute mNewRoute = new TTRoute(Guid.Parse(aTTId), mIncident.Sector, aUser.DepartmentId, Convert.ToInt32(aSelectedDepartments[n]), DateTime.Now);
					IncidentProvider.InsertRoute(mNewRoute, aUser.Name == "1022" ? "1022" : aUser.Name);

						//
						// 20.04.2017, Andreas Kasapleris
						// send Indident to BackEnd Application
						//

						// EYDAP Departments of Maintenance
						// 1033 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΑΘΗΝΑΣ
						// 1039 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΠΕΙΡΑΙΑΣ
						// 1043 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΗΡΑΚΛΕΙΟΥ
						// 1082 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΑΣΠΡΟΠΥΡΓΟΥ (ΠΕΙΡΑΙΑΣ)
						// 1084 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΣΑΛΑΜΙΝΑΣ (ΠΕΙΡΑΙΑΣ)
						// 1097 = ΣΥΝΤΗΡΗΣΗΣ (ΒΛΑΒΩΝ) ΜΕΝΙΔΙΟΥ (ΗΡΑΚΛΕΙΟΥ)

						if (!aIsRelated)
						{

							if (mNewRoute.ToDepartmentId == 1033 ||
								mNewRoute.ToDepartmentId == 1039 ||
								mNewRoute.ToDepartmentId == 1043 ||
								mNewRoute.ToDepartmentId == 1082 ||
								mNewRoute.ToDepartmentId == 1084 ||
								mNewRoute.ToDepartmentId == 1097)
							{
								BackEndIncident IncidentToSendToBackEnd = prepareTicketForBackEnd(aTTId, mNewRoute.ToDepartmentId);
								//if (IncidentToSendToBackEnd != null)
								{
									// 21.04.2017, Andreas Kasapleris
									// post the Incident to BackEnd Application
									string BackEndIncidentID = PostIncidentToBackEnd(IncidentToSendToBackEnd);
									if (!String.IsNullOrEmpty(BackEndIncidentID))
									{
										// Code block to automatically create the Task for
										// Συντήρησης-Βλαβών in Portal
										{
											// go on and automaticaly create a Task under Incident
											// this Task will be related to the BackEnd Incident ID
											// to open the form

											// create a new Task class
											Task aTask = new Task();

											// set the Task Properties before calling Insert method
											aTask.Comments = "Αυτόματη δημιουργία Εργασίας από Δρομολόγηση στο Συντήρησης-Βλαβών";
											aTask.State = "Ανοιχτή";
											aTask.TaskTypeId = 1063; // Εργασία E301 = Ε301 - ΣΥΝΤΗΡΗΣΗ-ΕΠΙΣΚΕΥΗ ΒΛΑΒΗΣ ΔΙΚΤΥΟΥ
											aTask.DepartmentId = mNewRoute.ToDepartmentId;
											aTask.Propagated = 1;
											aTask.BackEndTabletId = BackEndIncidentID;
											aTask.IncidentId = Guid.Parse(aTTId);
											//
											// 20.10.2018, Andreas Kasapleris, bug fix
											//
											aTask.CreationDate = DateTime.Now;
											// now call method to add the Task to database
											IncidentProvider.InsertTask(aTask, Guid.Parse(aTTId), aUser.UserId);
										}

									} // if BackEndIncidentID

								} // if IncidentToSendToBackEnd

							} // check of departments
						}

					} // route
			}
		}

		public static string POSTTOBACKEND(string url, string jsonContent)
		{
			// 21.04.2017, Andreas Kasapleris
			// create your request object
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";

			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
			Byte[] byteArray = encoding.GetBytes(jsonContent);

			// do some settings for your request object
			request.ContentLength = byteArray.Length;
			request.ContentType = @"application/json";

			// write info into the request object
			using (Stream dataStream = request.GetRequestStream())
			{
				dataStream.Write(byteArray, 0, byteArray.Length);
			}
			long length = 0;
			// string statusResponse = null; // 21.04.2017, Andreas Kasapleris
			string Uri = null; // 21.04.2017, Andreas Kasapleris

			//
			// 21.04.2017, Andreas Kasapleris
			// you send your constructed request object ... and for this request
			// object, you will get back a response object ... see below
			//
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				length = response.ContentLength;
				string Location = response.Headers["Location"].ToString();
				Uri = Location.Substring(Location.LastIndexOf("/")+1);
				// statusResponse = response.StatusCode.ToString();
			}
			return Uri; // 21.04.2017, Andreas Kasapleris
			// return statusResponse; // 13.04.2017, Andreas Kasapleris
		}

			//
			// 21.04.2017, Andreas Kasapleris
			// method to find Ticket/Incident info from SQL Table Incidents and set the Class properties
			// method returns a 'BackEndIncident' class to be send to BackEnd Application
			// 30.08.2018, Andreas Kasapleris, modified to select also EidosProblimatosDescr and ProblimaDescr
			// together with the Comments and pass them as one string to BackEnd Incidents
			// Commented out by JerryC

			public static BackEndIncident prepareTicketForBackEnd(string TicketId, int ForwardToDeptId)
		{
			BackEndIncident rIncident = null;

			SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

			Logger.Instance().Error("TicketId for BackEnd = " + TicketId, null);

			SqlDataReader mReader = null;
			try
			{
				mConnection.Open();
				SqlCommand mSqlCommand = new SqlCommand();
				// mCommand.CommandText = String.Format("select * from Incidents where TT_Id = '{0}'", TicketId);
				mSqlCommand.CommandText = @"SELECT TT_Id                           AS TT_Id,
												   ID1022                          AS ID1022,
												   Customer_Name                   AS Customer_Name,
												   Customer_Name                   AS Customer_SurName,
												   Sectors.SectorDescription       AS SectorDescription,
												   Customer_Phone                  AS Customer_Phone,
												   Customer_Email                  AS Customer_Email,
												   Municipality                    AS Municipality,
												   Street_Name                     AS Street_Name,
												   Street_Number                   AS Street_Number,
												   Odos2                           AS Street_Name1,
												   ''                              AS Street_Number1,
												   ISNULL(Comments,'') + ' >> ΕΙΔΟΣ ΠΡΟΒΛΗΜΑΤΟΣ : ' + EidosProblimatosDescr + ' << ' + ' >> ΠΡΟΒΛΗΜΑ : ' + ProblimaDescr + ' << ' AS Comments,
												   Sector                          AS Sector,
												   SyntetagmenesVlavis_GeogrMikos  AS Latitude,
												   SyntetagmenesVlavis_GeogrPlatos AS Longitude,
												   'A'                             AS Shift,
												   Perioxi                         AS Perioxi,
												   TaxKodikas                      AS TaxKodikas,
												   ArithmosMetriti, ArithmosMitroou
											  FROM Incidents, Sectors
											 WHERE Incidents.Sector = Sectors.SectorId
											   AND TT_Id = @TT_Id";

				mSqlCommand.Parameters.AddWithValue("@TT_Id", TicketId);
				mSqlCommand.CommandType = CommandType.Text;
				mSqlCommand.Connection = mConnection;
				mReader = mSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch (Exception e)
			{
				Logger.Instance().Error("Error trying to send TT_Id to BackEnd = " +
										 TicketId + " ==> " + e.Message,
										 null);

				if (mConnection != null)
				{
					mConnection.Close();
					mConnection.Dispose();
				}
			}

			if (mReader != null)
			{
				if (mReader.HasRows)
				{
					while (mReader.Read())
					{
						rIncident = new BackEndIncident();

						BackEndUser rBackEndUser = new BackEndUser();
						rBackEndUser.FirstName = "Portal DDY Service";
						rBackEndUser.LastName = "Portal DDY Service";
						rBackEndUser.RegisterNumber = "portalddy";
						rBackEndUser.UserName = "portalddy";

						rIncident.Users = new List<BackEndUser>();
						rIncident.Users.Add(rBackEndUser);
						rIncident.Vehicles = new List<Vehicle>();

						rIncident = new BackEndIncident(
									  mReader.GetGuid(0),
									  mReader.IsDBNull(1) ? "" : mReader.GetString(1),
									  mReader.IsDBNull(2) ? "" : mReader.GetString(2),
									  mReader.IsDBNull(3) ? "" : mReader.GetString(3),
									  mReader.IsDBNull(4) ? "" : mReader.GetString(4),
									  mReader.IsDBNull(5) ? "" : mReader.GetString(5),
									  mReader.IsDBNull(6) ? "" : mReader.GetString(6),
									  mReader.IsDBNull(7) ? "" : mReader.GetString(7),
									  mReader.IsDBNull(8) ? "" : mReader.GetString(8),
									  mReader.IsDBNull(9) ? "" : mReader.GetString(9),
									  mReader.IsDBNull(10) ? "" : mReader.GetString(10),
									  mReader.IsDBNull(11) ? "" : mReader.GetString(11),
									  mReader.IsDBNull(12) ? "" : mReader.GetString(12),
									  mReader.IsDBNull(13) ? 0 : mReader.GetInt32(13),
									  ForwardToDeptId,
									  mReader.IsDBNull(14) ? 0 : mReader.GetDecimal(14),
									  mReader.IsDBNull(15) ? 0 : mReader.GetDecimal(15),
									  mReader.IsDBNull(16) ? "" : mReader.GetString(16),
									  mReader.IsDBNull(17) ? "" : mReader.GetString(17),
									  mReader.IsDBNull(18) ? "" : mReader.GetString(18),
									  mReader.IsDBNull(19) ? "" : mReader.GetString(19),
									  mReader.IsDBNull(20) ? "" : mReader.GetString(20),
									  rBackEndUser,
									  rIncident.Users,
									  rIncident.Vehicles);

						return rIncident;
					}
					mReader.Close();
					mReader.Dispose();
					mConnection.Close();
				}
				else
				{
					mReader.Close();
					mReader.Dispose();
					mConnection.Close();
				}

			}

			return rIncident;

		} // findTicketForBackEnd


		public static int UpdateIncidentWithBackEndID(string aIncidentId, string aBackEndTabletId)
		{
			SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
			SqlCommand mSqlCommand = new SqlCommand();
			mSqlCommand.Connection = mConnection;
			mSqlCommand.CommandText = @"UPDATE Incidents
											SET Propagated      = 1,
												BackEndTabletId = @BackEndTabletId
										  WHERE TT_Id = @TT_Id";
			mSqlCommand.CommandType = CommandType.Text;

			mSqlCommand.Parameters.AddWithValue("@TT_Id", aIncidentId);
			mSqlCommand.Parameters.AddWithValue("@BackEndTabletId", aBackEndTabletId);

			int nrOfAffectedRows = -1;

			try
			{
				mConnection.Open();
				nrOfAffectedRows = mSqlCommand.ExecuteNonQuery();
				mConnection.Close();
			}
			catch (Exception /* exception */)
			{
				if (mConnection != null)
				{
					mConnection.Close();
					mConnection.Dispose();
				}
			}

			return nrOfAffectedRows;

		}
	}

	}
}