using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DevExpress.Data.Helpers;
using EydapTickets.Utils;

namespace EydapTickets.Models
{
    // DXCOMMENT: Configure a data model (In this sample, we do this in file NorthwindDataProvider.cs. You would better create your custom file for a data model.)

    public static class IncidentProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        private static readonly Hashtable _departments = new Hashtable();

        // TODO: Move this into HtmlHelper class
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        // TODO: Move this into backend service class
        public static void DeleteTicketFromBackEnd(Guid aTTID)
        {
            // create your request object
            string url = ConfigurationManager.AppSettings.Get("TabletWebServiceUrlDeleteIncident") + "/" + aTTID.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var encoding = new UTF8Encoding();

            // write info into the request object
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    var statusResponse = response.StatusCode.ToString();
                }
            }
            catch (Exception exception)
            {
                Logger.Instance().Error("Error Deleting Ticket from BackEnd ", exception);
            }
        }

        public static void SaveLayout(int userId, string layoutData)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = "UPDATE Users SET Layout = @Layout WHERE UserId = @UserId"
            };

            sqlCommand.Parameters.AddWithValue("@Layout", layoutData);
            sqlCommand.Parameters.AddWithValue("@UserId", userId);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteScalar();
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public static string LoadLayout(int userId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT Layout FROM Users WHERE UserId = @UserId"
            };

            sqlCommand.Parameters.AddWithValue("@UserId", userId);

            try
            {
                sqlConnection.Open();
                return sqlCommand.ExecuteScalar() as string;
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public static string GetDepartmentName(int aDepartmentId)
        {
            if (_departments.Count == 0)
            {
                var sqlConnection = new SqlConnection(ConnectionString);
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT DepartmentId, DepartmentName FROM Departments"
                };

                var dataTable = new DataTable();
                try
                {
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    sqlConnection.Close();
                }
                catch (Exception /* exception */)
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }

                try
                {
                    for (int n = 0; n < dataTable.Rows.Count; n++)
                    {
                        DataRow dataRow = dataTable.Rows[n];
                        _departments.Add(Convert.ToInt32(dataRow[0]), dataRow[1].ToString());
                    }
                }
                catch (Exception e)
                {
                    Logger.Instance().Error("Exception in GetDepartmentName - DepartmentId=" + aDepartmentId.ToString(), e);
                }
            }

            if (_departments[aDepartmentId] != null)
            {
                return _departments[aDepartmentId].ToString();
            }

            return null;
        }

        public static IncidentDetails GetIncidentDetails(Guid incidentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = @"
                        SELECT
                            TicketTraceId,
                            ID1022,
                            HmerominiaAnagelias,
                            OraAnagelias,
                            OnomaKalountos,
                            Customer_Phone,
                            EidosProblimatosDescr,
                            ArithmosMitroou,
                            ArithmosMetriti,
                            ArithmosLogariasmou,
                            ProblimaDescr,
                            Comments,
                            RelatedID1022,
                            Status
                        FROM
                            Incidents
                        WHERE
                            TT_Id = @IncidentId"
                };

                sqlCommand.Parameters.AddWithValue("@IncidentId", incidentId);

                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                // TODO: Maybe handle exception
            }

            IncidentDetails incidentDetails = null;

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        incidentDetails = new IncidentDetails(
                            incidentId,
                            dataReader.IsDBNull(0) ? null : dataReader.GetString(0),
                            dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? (DateTime?)null : dataReader.GetDateTime(2),
                            dataReader.IsDBNull(3) ? (DateTime?)null : dataReader.GetDateTime(3),
                            dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? null : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? null : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? null : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? null : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? null : dataReader.GetString(9),
                            dataReader.IsDBNull(10) ? null : dataReader.GetString(10),
                            dataReader.IsDBNull(11) ? null : dataReader.GetString(11),
                            dataReader.IsDBNull(12) ? null : dataReader.GetString(12),
                            dataReader.GetInt32(13)
                        );
                    }
                }
                dataReader.Close();
                dataReader.Dispose();
                sqlConnection.Close();
            }

            return incidentDetails;
        }

        public static IEnumerable<Municipality> GetMunicipalities()
        {
            List<Municipality> mList = new List<Municipality>();

            try
            {
                ServiceReferenceGIS.eydap1022PortTypeClient mClient = new ServiceReferenceGIS.eydap1022PortTypeClient("eydap1022Port");
                ServiceReferenceGIS.getMunicipalitiesRequest mres = new ServiceReferenceGIS.getMunicipalitiesRequest();
                ServiceReferenceGIS.getMunicipalitiesResponse1 mResponse = mClient.getMunicipalities(mres);

                List<string> results = mResponse.getMunicipalitiesResponse.municipalitiesList.ToList<string>();

                for (int n = 0; n < results.Count; n++)
                {
                    mList.Add(new Municipality(n, results[n]));
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("GetMunicipalities failed", ex);
            }
            return mList;
        }

        public static string[] GetStreetsForMunicipality(string municipality)
        {
            var results = new string[0];

            if (!string.IsNullOrEmpty(municipality))
            {
                try
                { 
                    ServiceReferenceGIS.eydap1022PortTypeClient mClient = new ServiceReferenceGIS.eydap1022PortTypeClient("eydap1022Port");
                    ServiceReferenceGIS.getStreetsRequest mres = new ServiceReferenceGIS.getStreetsRequest(municipality);
                    ServiceReferenceGIS.getStreetsResponse mResponse = mClient.getStreets(mres);
                    results = mResponse.streetsList;
                }
                catch (Exception exception)
                {
                    Logger.Instance().Error("GetStreetsForMunicipality failed", exception);
                }
            }

            return results;
        }

        /*public static IEnumerable<Street> GetStreets()
        {
            List<Street> mList = new List<Street>();
            mList.Add(new Street(1, aMunicipality + "Athina"));
            mList.Add(new Street(2, aMunicipality + "Pireas"));
            mList.Add(new Street(2, aMunicipality + "Boula"));
            return mList;
        }*/

        public static Incident GetIncidentById(Guid incidentId, UsersModel user)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetIncidentById"
                };

                sqlCommand.Parameters.AddWithValue("@Incident_Id", incidentId);
                sqlCommand.Parameters.AddWithValue("@DepertmentId", user.DepartmentId);

                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                // TODO: Maybe handle exception
            }

            Incident incident = null;

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        incident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? (DateTime?)null : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21),
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24))
                        );
                    }
                }
                dataReader.Close();
                dataReader.Dispose();
                sqlConnection.Close();
            }

            return incident;
        }

        public static string GetTabletSectorName(int sectorId)
        {
            switch (sectorId)
            {
                case 1:
                    return "ΤΟΜΕΑΣ ΑΘΗΝΩΝ";
                case 2:
                    return "ΤΟΜΕΑΣ ΠΕΙΡΑΙΑ";
                case 3:
                    return "ΤΟΜΕΑΣ ΗΡΑΚΛΕΙΟΥ";
                case 4:
                    return "ΥΠΗΡΕΣΙΑ ΛΕΙΤΟΥΡΓΙΑΣ";
                case 5:
                    return "ΥΠΗΡΕΣΙΑ Η/Μ ΕΓΚΑΤΑΣΤΑΣΕΩΝ";
                case 6:
                    return "ΥΠΗΡΕΣΙΑ ΥΔΡΟΜΕΤΡΗΤΩΝ";
                case 7:
                    return "ΥΠΗΡΕΣΙΑ ΕΛΕΓΧΟΥ ΠΟΙΟΤΗΤΑΣ ΥΔΑΤΟΣ";
                case 8:
                    return "ΥΠΗΡΕΣΙΑ ΑΥΤΟΚΑΤΑΣΚΕΥΩΝ Κ ΜΕΓΑΛΩΝ ΜΕΤΡΗΤΩΝ";
                default:
                    throw new Exception("Invalid SectorId");
            }
        }

        public static string GetSectorName(int sectorId)
        {
            switch (sectorId)
            {
                case 1:
                    return "ΤΟΜΕΑΣ ΑΘΗΝΩΝ";
                case 2:
                    return "ΤΟΜΕΑΣ ΠΕΙΡΑΙΑ";
                case 3:
                    return "ΤΟΜΕΑΣ ΗΡΑΚΛΕΙΟΥ";
                case 4:
                    return "ΥΠΗΡΕΣΙΑ ΛΕΙΤΟΥΡΓΙΑΣ";
                case 5:
                    return "ΥΠΗΡΕΣΙΑ Η/Μ ΕΓΚΑΤΑΣΤΑΣΕΩΝ";
                case 6:
                    return "ΥΠΗΡΕΣΙΑ ΥΔΡΟΜΕΤΡΗΤΩΝ";
                case 7:
                    return "ΥΠΗΡΕΣΙΑ ΕΛΕΓΧΟΥ ΠΟΙΟΤΗΤΑΣ ΥΔΑΤΟΣ";
                case 8:
                    return "ΥΠΗΡΕΣΙΑ ΑΥΤΟΚΑΤΑΣΚΕΥΩΝ Κ ΜΕΓΑΛΩΝ ΜΕΤΡΗΤΩΝ";
                default:
                    throw new Exception("Invalid SectorId");
            }
        }

        //public static IEnumerable<Incident> GetIncidentByIdInternal(Guid aGuid, UsersModel aModel)
        //{
        //    var sqlConnection = new SqlConnection(ConnectionString);
        //    SqlDataReader dataReader;
        //    try
        //    {
        //        sqlConnection.Open();
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.CommandType = CommandType.Text;
        //        sqlCommand.CommandText = String.Format("select TT_Id, ID1022, Customer_Name, Customer_Phone, Customer_Email, Municipality, Street_Name, Odos2, Street_Number, Comments, Sector, DateOfRegistry, Status, dbo.gethasComments(TT_Id) as CommentCount, STR(dbo.getClosedTaskCountForIncidentId(TT_Id)) + '/' + STR(dbo.getOpenTaskCountForIncidentId(TT_Id)) as Percentage, TicketTraceId, RelatedID1022, EidosProblimatosDescr, AitiaDescr, TEBCC, dbo.getColorOfTTIdForUserDepartment(TT_Id, {1}) as myDepColor, dbo.getColorOfTTIdForOtherDepts(TT_Id, {2}) as otherDepColor ,SyntetagmenesVlavis_GeogrMikos, SyntetagmenesVlavis_GeogrPlatos   from Incidents where TT_Id='{0}'", aGuid, aModel.DepartmentId, aModel.DepartmentId);
        //        sqlCommand.Connection = sqlConnection;
        //        dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception e)
        //    {
        //        sqlConnection.Close();
        //        sqlConnection.Dispose();
        //        yield break;
        //    }

        //    if (dataReader != null)
        //    {
        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                DateTime? lDate = null;

        //                Incident mIncident = new Incident(dataReader.GetGuid(0), dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1), dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
        //                   dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3), dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4), dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5), dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6), dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
        //                   dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8), dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9), dataReader.GetInt32(10), dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
        //                   dataReader.GetInt32(12), dataReader.GetInt32(13), dataReader.GetString(14), dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
        //                   dataReader.IsDBNull(16) ? null : dataReader.GetString(16), dataReader.IsDBNull(17) ? null : dataReader.GetString(17), dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
        //                   dataReader.IsDBNull(19) ? null : dataReader.GetString(19), dataReader.GetInt32(20), dataReader.GetInt32(21), dataReader.IsDBNull(22) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(22)), dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)));

        //                yield return mIncident;
        //            }
        //            dataReader.Close();
        //            dataReader.Dispose();
        //            sqlConnection.Close();
        //        }
        //        else
        //        {
        //            dataReader.Close();
        //            dataReader.Dispose();
        //            sqlConnection.Close();
        //        }
        //    }
        //    yield break;
        //}

        public static IEnumerable<Incident> GetIncidentsClosedWithPendingTasks(UsersModel aModel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetSectorIncidentsClosedWithPendingTasks";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@SectorID", aModel.SectorId);
                sqlCommand.Parameters.AddWithValue("@UserId", aModel.UserId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? lDate = null;

                        var mIncident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21) ,
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24)));
                        yield return mIncident;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Incident> GetIncidentsClosedSeventyTwoHours(UsersModel aModel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetSectorIncidentsClosedSeventyTwoHours";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@SectorID", aModel.SectorId);
                sqlCommand.Parameters.AddWithValue("@UserId", aModel.UserId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? lDate = null;

                        var mIncident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21),
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24)));
                        yield return mIncident;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Incident> GetIncidents(UsersModel aModel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetSectorIncidents";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@SectorID", aModel.SectorId);
                sqlCommand.Parameters.AddWithValue("@UserId", aModel.UserId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? lDate = null;

                        var mIncident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21),
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24)));
                        yield return mIncident;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Incident> GetRelatedIncidents(UsersModel aModel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetRelatedSectorIncidents";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@SectorID", aModel.SectorId);
                sqlCommand.Parameters.AddWithValue("@UserId", aModel.UserId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? lDate = null;

                        var mIncident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21),
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24))
                        );

                        yield return mIncident;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Task> GetScheduledTasks(Guid? aGuid, UsersModel currentUser)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetScheduledTasks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Incident_Id", Guid.Empty);
                    command.Parameters.AddWithValue("@User_id", currentUser.UserId);

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return CreateScheduledTask(dataReader);
                        }
                    }
                }
            }
        }

        private static Task CreateScheduledTask(IDataRecord dataRecord)
        {
            return new Task(
                dataRecord.GetGuid(0),
                dataRecord.IsDBNull(1) ? null : dataRecord.GetString(1),
                dataRecord.IsDBNull(2) ? null : dataRecord.GetString(2),
                dataRecord.IsDBNull(3) ? null : dataRecord.GetString(3),
                dataRecord.GetInt32(4),
                dataRecord.IsDBNull(5) ? Guid.Empty : dataRecord.GetGuid(5),
                dataRecord.GetInt32(6),
                dataRecord.GetInt32(7),
                dataRecord.GetString(8),
                dataRecord.GetDateTime(9),
                dataRecord.IsDBNull(10) ? (DateTime?) null : dataRecord.GetDateTime(10),
                dataRecord.GetInt32(11),
                dataRecord.IsDBNull(12) ? 0 : dataRecord.GetInt32(12),
                dataRecord.IsDBNull(13) ? string.Empty : dataRecord.GetString(13)
            );
        }

        public static IEnumerable<Assignment> GetAssignments(Guid aTaskId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                // sqlCommand.CommandText = String.Format("select * from Visits where Task_Id = '{0}' ", aTaskId);
                sqlCommand.CommandText = string.Format("select AssignmentId, DateOfAssignment, DateOfCompletion, Status, Task_Id, Comments, BackEndTabletId from Visits where Task_Id = '{0}' order by  DateOfAssignment desc", aTaskId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? mTime = null;
                        if (!dataReader.IsDBNull(2))
                        {
                            mTime = dataReader.GetDateTime(2);
                        }

                        // Assignment mAssignment = new Assignment(dataReader.GetGuid(0), dataReader.GetDateTime(1), mTime, dataReader.IsDBNull(3) ? null : dataReader.GetString(3), dataReader.IsDBNull(4) ? Guid.Empty : dataReader.GetGuid(4), dataReader.IsDBNull(5) ? null : dataReader.GetString(5)); // 07.04.2017, Andreas Kasapleris
                        Assignment mAssignment = new Assignment(dataReader.GetGuid(0), dataReader.GetDateTime(1), mTime, dataReader.IsDBNull(3) ? null : dataReader.GetString(3), dataReader.IsDBNull(4) ? Guid.Empty : dataReader.GetGuid(4), dataReader.IsDBNull(5) ? null : dataReader.GetString(5), dataReader.IsDBNull(6) ? null : dataReader.GetString(6));
                        yield return mAssignment;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static List<Tuple<string, string>> GetKeyValueStoredProcedure(string aStoredProcedure, UsersModel aModel)
        {
            List<Tuple<string, string>> lExit = new List<Tuple<string, string>>();

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = aStoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@UserId", aModel.UserId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (dataReader != null)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Tuple<string, string> lnew = new Tuple<string, string>(dataReader.IsDBNull(0) ? string.Empty : dataReader.GetString(0), dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1));
                            lExit.Add(lnew);
                        }
                        dataReader.Close();
                        dataReader.Dispose();
                        sqlConnection.Close();
                    }
                    else
                    {
                        dataReader.Close();
                        dataReader.Dispose();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception /* exception */)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return lExit;
        }

        //
        // 23.05.2017, Andreas Kasapleris
        // using BackEndTabletId search in Tasks table to find
        // and return SectorId
        //

        public static int findSectorFromBackEndTabletId(string BackEndTabletId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand    sqlCommand = new SqlCommand();
            sqlCommand.Connection    = sqlConnection;

            sqlCommand.CommandText = string.Format("SELECT TOP 1 TASKS.SectorId FROM TASKS WHERE TASKS.BackEndTabletId = '{0}'", BackEndTabletId);
            int rSectorId = 0;
            try
            {
                sqlConnection.Open();
                rSectorId = (int)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return rSectorId;
        }

        //
        // 23.05.2017, Andreas Kasapleris
        // using BackEndTabletId search in Tasks table to find
        // and return Incident_Id
        //

        public static string findIncidentIdFromBackEndTabletId(string BackEndTabletId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format("SELECT TOP 1 TASKS.Incident_Id FROM TASKS WHERE TASKS.BackEndTabletId = '{0}'", BackEndTabletId);
            string rIncidentId = "-1";
            try
            {
                sqlConnection.Open();
                rIncidentId = (sqlCommand.ExecuteScalar()).ToString();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return rIncidentId;
        }


        public static string findTaskDescription(int TaskTypeId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format("SELECT TaskDescription FROM TaskTypes WHERE TaskTypeId = '{0}'", TaskTypeId);
            string rTaskDescription = null;
            try
            {
                sqlConnection.Open();
                rTaskDescription = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return rTaskDescription;
        }




        public static int checkTicketInRoutingHistory(Guid incidentid, int sectorid, int departmentid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format(@"SELECT COUNT(DepartmentId)
                                                        FROM RoutingHistory
                                                  WHERE TTId         = '{0}'
                                                    AND SectorId     = {1}
                                                    AND DepartmentId = {2}",
                                                    incidentid,
                                                    sectorid,
                                                    departmentid);
            int recsFound = -1;
            try
            {
                sqlConnection.Open();
                recsFound = (int)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return recsFound;
        }


        public static int RouteToDepartMent(Guid incidentid, int sectorid, int departmentid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format(@"INSERT INTO RoutingHistory (TTId, SectorId, DepartmentId, RouteDate)
                                            VALUES  ( '{0}', {1}, {2}, GETDATE())",
                                            incidentid, sectorid, departmentid);

            int recsInserted = -1;
            try
            {
                sqlConnection.Open();
                recsInserted = (int)sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return recsInserted;
        }

        public static int createTaskForEreunon(
            Guid     taskid,
            string   taskdescription,
            string   comments,
            string   state,
            int      tasktypeid,
            Guid     incidentid,
            int      sectorid,
            int      departmentid,
            string   backendtabletid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format(@"INSERT INTO Tasks (Task_Id, Task_Description, Comments, State, TaskTypeId, Incident_Id, SectorId, DepartmentId, CreationDate, Propagated, BackEndTabletId)
                                            VALUES  ( '{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6}, {7}, GETDATE(), 0, '{8}' )",
                                            taskid, taskdescription, comments, state, tasktypeid, incidentid, sectorid, departmentid, backendtabletid);

            int recsInserted = -1;
            try
            {
                sqlConnection.Open();
                recsInserted = (int)sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return recsInserted;
        }

        public static int createTaskForMaintainance(
            Guid taskid,
            string taskdescription,
            string comments,
            string state,
            int tasktypeid,
            Guid incidentid,
            int sectorid,
            int departmentid,
            string backendtabletid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format(@"INSERT INTO Tasks (Task_Id, Task_Description, Comments, State, TaskTypeId, Incident_Id, SectorId, DepartmentId, CreationDate, Propagated, BackEndTabletId)
                                            VALUES  ( '{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6}, {7}, GETDATE(), 0, '{8}' )",
                                            taskid, taskdescription, comments, state, tasktypeid, incidentid, sectorid, departmentid, backendtabletid);

            int recsInserted = -1;
            try
            {
                sqlConnection.Open();
                recsInserted = (int)sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return recsInserted;
        }

        public static int createRoutingHistorylog(Guid incidentid, int sectorid, int departmentid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format(@"INSERT INTO RoutingHistorylog (Id, TTId, SectorId, DepartmentId, Date, Action, [User])
                                            VALUES  ( NEWID(), '{0}', {1}, {2}, GETDATE(), 'Route', 'BackEnd' )",
                                            incidentid, sectorid, departmentid);

            int recsInserted = -1;
            try
            {
                sqlConnection.Open();
                recsInserted = (int)sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                throw exception;
            }

            return recsInserted;
        }

        public const string GetTicketTraceIdCommandText =
            "SELECT TicketTraceId FROM Incidents WHERE TT_Id = @incidentId";

        public static string GetTicketTraceId(Guid incidentId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(GetTicketTraceIdCommandText, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@incidentId", incidentId);

                    sqlConnection.Open();
                    return (string)sqlCommand.ExecuteScalar();
                }
            }
        }

        /*public static VisitDetailsModel GetVisitDetails(Guid aVisitId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            DataTable VisitCrewTable = new DataTable();
            DataTable VisitEquipmentTable = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = String.Format("select * from VisitCrew where VisitID = '{0}' ", aVisitId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                {
                    a.Fill(VisitCrewTable);
                }

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.CommandText = String.Format("select * from VisitEquipment where VisitID = '{0}' ", aVisitId);
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.Connection = sqlConnection;

                using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand1))
                {
                    a.Fill(VisitEquipmentTable);
                }
                sqlConnection.Close();
                sqlConnection.Dispose();

                List<VisitCrew> VisitsCrewList = new List<VisitCrew>();
                List<VisitEquipment> EquipmentList = new List<VisitEquipment>();

                DataRow mRow = null;
                for (int n=0; n<VisitCrewTable.Rows.Count;n++)
                {
                    mRow = VisitCrewTable.Rows[n];
                    VisitsCrewList.Add(new VisitCrew((Guid)mRow[0], (Guid)mRow[0], mRow[2].ToString(), mRow[3].ToString(), (int)mRow[4]));
                }

                for (int i=0; i<VisitEquipmentTable.Rows.Count;i++)
                {
                    mRow = VisitEquipmentTable.Rows[i];
                    EquipmentList.Add(new VisitEquipment((Guid)mRow[0], (Guid)mRow[0], mRow[2].ToString(), mRow[3].ToString()));
                }

                VisitDetailsModel mVisitDetailsmodel = new VisitDetailsModel();
                //mVisitDetailsmodel.VisitCrew = VisitsCrewList;
                mVisitDetailsmodel.VisitEquipment = EquipmentList;
                return mVisitDetailsmodel;
            }
            catch(Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }*/

        public static void ClearTTCorrelation(Guid aGuid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.CommandText = string.Format("update Incidents set RelatedID1022 = null where TT_Id = '{0}'", aGuid.ToString());
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static void CorrelateTT(Guid aGuid, string aCorrelation)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;


            sqlCommand.CommandText = "CorrelateIncident";
            sqlCommand.Parameters.AddWithValue("@TTID", aGuid);
            sqlCommand.Parameters.AddWithValue("@Related1022ID", aCorrelation);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static Guid InsertIncident(Incident aIncident)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            Guid mGuid = Guid.NewGuid();

            if (aIncident.TicketTraceId == null)
            {
                sqlCommand.CommandText = string.Format("insert into Incidents (TT_Id, ID1022, Customer_Name,Customer_Phone,  Customer_Email, Municipality, Street_Name, Street_Number, Comments, Sector, TicketTraceId) VALUES('{9}', '{0}', '{1}', '{2}', '{3}','{4}', '{5}', '{6}','{7}', {8}, '{9}')", aIncident.ID1022, aIncident.CustomerName, aIncident.CustomerPhone, aIncident.CustomerEmail, aIncident.Municipality, aIncident.StreetName, aIncident.StreetNumber, aIncident.Comments, aIncident.Sector, mGuid);
            }
            else
            {
                sqlCommand.CommandText = string.Format("insert into Incidents (TT_Id, ID1022, Customer_Name,Customer_Phone,  Customer_Email, Municipality, Street_Name, Street_Number, Comments, Sector) VALUES('{9}', '{0}', '{1}', '{2}', '{3}','{4}', '{5}', '{6}','{7}', {8})", aIncident.ID1022, aIncident.CustomerName, aIncident.CustomerPhone, aIncident.CustomerEmail, aIncident.Municipality, aIncident.StreetName, aIncident.StreetNumber, aIncident.Comments, aIncident.Sector, mGuid);
            }
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return mGuid;
        }

        public static void InsertScheduledTask(Task aTask, UsersModel aUser)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "InsertScheduledTask";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TaskId", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@Comments", aTask.Comments == null ? string.Empty : aTask.Comments);
            sqlCommand.Parameters.AddWithValue("@State", aTask.State);
            sqlCommand.Parameters.AddWithValue("@TaskTypeId", aTask.TaskTypeId);
            sqlCommand.Parameters.AddWithValue("@User_id", aUser.UserId);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", aUser.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@SectorId", aUser.SectorId);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        //
        // 17.10.2018, Andreas Kasapleris, table Field Tasks.CreationDate is now entered by user
        //
        public static void InsertTask(Task task, Guid? incidentId, int userId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "InsertTask",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@TaskId", Guid.NewGuid());
                sqlCommand.Parameters.AddWithValue("@Comments", task.Comments == null ? string.Empty : task.Comments);
                sqlCommand.Parameters.AddWithValue("@State", task.State);
                sqlCommand.Parameters.AddWithValue("@TaskTypeId", task.TaskTypeId);
                sqlCommand.Parameters.AddWithValue("@Incident_Id", incidentId != null ? incidentId : new Guid());
                sqlCommand.Parameters.AddWithValue("@User_id", userId);

                //
                // 31.03.2013, Andreas Kasapleris
                // new implementation; pass the DepartmentId which the selected TaskTypeId is executed from;
                // previous implementation used the DepartmentId of the user (changes are done in Stored Procedure 'InsertTask')
                //
                sqlCommand.Parameters.AddWithValue("@new31032017_DepartmentId", task.DepartmentId);

                // 17.10.2018, Andreas Kasapleris, from now on Tasks.CreationDate is entered by the user
                sqlCommand.Parameters.AddWithValue("@DateCreated", task.CreationDate);

                if (task.ClosingDate.HasValue)
                {
                    sqlCommand.Parameters.AddWithValue("@DateClosed", task.ClosingDate.Value);
                }
                else
                {
                    sqlCommand.Parameters.Add("@DateClosed", SqlDbType.DateTime).Value = DBNull.Value;
                }

                sqlCommand.Parameters.AddWithValue("@Propagated", task.Propagated == null ? 0 : task.Propagated);
                sqlCommand.Parameters.AddWithValue("@BackEndTabletId",
                    task.BackEndTabletId == null ? string.Empty : task.BackEndTabletId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void InsertTaskAutomated(Task aTask)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "InsertTaskAutomated";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TaskId", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@Comments", aTask.Comments);
            sqlCommand.Parameters.AddWithValue("@State", aTask.State);
            sqlCommand.Parameters.AddWithValue("@TaskTypeId", aTask.TaskTypeId);
            sqlCommand.Parameters.AddWithValue("@BackEndTabletId", aTask.BackEndTabletId);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static void CloseTask(string incidentBackendId, DateTime? incidentBackendClosedDate, string incidentBackendNotes)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("CloseTaskBackEndWithAdditionalInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BackEndId", incidentBackendId);
                    command.Parameters.AddWithValue("@BackEndClosedDate", incidentBackendClosedDate ?? DateTime.Now);
                    command.Parameters.AddWithValue("@BackEndNotes", incidentBackendNotes ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CloseTask(string aBackEndId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "CloseTaskBackEnd";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@BackEndId", aBackEndId);
            try
            {
                sqlConnection.Open();
                int ret = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        //
        // 17.10.2018, Andreas Kasapleris, table Field Tasks.CreationDate is now entered by user
        //
        public static void UpdateTask(Task aTask, Guid? aIncidentId, string aUserName)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UpdateTask";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TaskId", aTask.TaskId);
            sqlCommand.Parameters.AddWithValue("@LastUserName", aUserName);
            if (aTask.Comments == null)
            {
                sqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Comments", aTask.Comments);
            }
            sqlCommand.Parameters.AddWithValue("@State", aTask.State);
            sqlCommand.Parameters.AddWithValue("@TaskTypeId", aTask.TaskTypeId);
            sqlCommand.Parameters.AddWithValue("@Incident_Id", aIncidentId != null ? aIncidentId : new Guid());

            // 17.10.2018, Andreas Kasapleris, from now on handling CreationDate field
            sqlCommand.Parameters.AddWithValue("@DateCreated", aTask.CreationDate);

            if (aTask.ClosingDate == null)
            {
                sqlCommand.Parameters.AddWithValue("@ClosingDate", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ClosingDate", aTask.ClosingDate);
            }

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception /* exception */)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        public static void InsertAssignment(Assignment aAssignment, Guid aTaskGuid)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "InsertAssignment";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@DateFrom", aAssignment.DateOfAssignment);
            if (aAssignment.DateOfCompletion == null)
            {
                sqlCommand.Parameters.AddWithValue("@DateTo", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@DateTo", aAssignment.DateOfCompletion);
            }
            sqlCommand.Parameters.AddWithValue("@TaskId", aTaskGuid);

            if (aAssignment.Comments == null)
            {
                sqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Comments", aAssignment.Comments);
            }
            sqlCommand.Parameters.AddWithValue("@State", aAssignment.Status);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception /* exception */)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        public static void UpdateAssignment(Assignment aAssignment)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UpdateAssignment";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@AssignmentId", aAssignment.AssignmentId);
            sqlCommand.Parameters.AddWithValue("@DateFrom", aAssignment.DateOfAssignment);
            if (aAssignment.DateOfCompletion == null)
            {
                sqlCommand.Parameters.AddWithValue("@DateTo", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@DateTo", aAssignment.DateOfCompletion);
            }
            if (aAssignment.Comments == null)
            {
                sqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Comments", aAssignment.Comments);
            }
            sqlCommand.Parameters.AddWithValue("@State", aAssignment.Status);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception /* exception */)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        public static IEnumerable<Personnel> GetPersonnel()
        {
            return GetPersonnel(null);
        }

        public static IEnumerable<Personnel> GetPersonnel(string aCommaSeparatedIds)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();

                if (aCommaSeparatedIds == null)
                {
                    sqlCommand.CommandText = string.Format("select * from Personnel");
                }
                else
                {
                    sqlCommand.CommandText = string.Format("select * from Personnel where PersonnelID in ({0})", aCommaSeparatedIds);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Personnel mPersonnel = new Personnel(dataReader.GetInt32(0), dataReader.IsDBNull(1) ? null : dataReader.GetString(1), dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                                        dataReader.GetInt32(3), dataReader.GetInt32(4), dataReader.GetInt32(5),
                                                        dataReader.GetInt32(6), dataReader.GetBoolean(7));
                        yield return mPersonnel;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static void AddPersonnel(Personnel aPersonnel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format("insert into Personnel (PersonnelName,PersonnelSurName ,PersonnelType,PersonnelAM ,PersonnelSectorId ,PersonnelDepartmentID,IsActive) VALUES ('{0}', '{1}', {2}, {3},{4}, {5}, {6})",
                aPersonnel.PersonnelName, aPersonnel.PersonnelSurName, aPersonnel.PersonnelType, aPersonnel.PersonnelAM, aPersonnel.PersonnelSectorId, aPersonnel.PersonnelDepartmentID, aPersonnel.IsActive == true ? 1 : 0);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static void UpdatePersonnel(Personnel aPersonnel)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = string.Format("update Personnel set PersonnelName = '{0}' ,PersonnelSurName = '{1}' ,PersonnelType = {2}, PersonnelAM = {3} ,PersonnelSectorId = {4} ,PersonnelDepartmentID = {5} ,IsActive = {6} where PersonnelID = {7}",
                aPersonnel.PersonnelName, aPersonnel.PersonnelSurName, aPersonnel.PersonnelType, aPersonnel.PersonnelAM, aPersonnel.PersonnelSectorId, aPersonnel.PersonnelDepartmentID, aPersonnel.IsActive == true ? 1 : 0, aPersonnel.PersonnelID);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static IEnumerable<Vehicle> GetVehiclesForDepartment(int adepartmentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = string.Format("select * from Vehicles where VehicleDepartment={0}", adepartmentId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Vehicle mTask = new Vehicle(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetInt32(2),
                                dataReader.IsDBNull(3) ? null : dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetBoolean(5),
                                dataReader.IsDBNull(6) ? null : dataReader.GetString(6), dataReader.IsDBNull(7) ? null : dataReader.GetString(7));
                        yield return mTask;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Vehicle> GetVehicles()
        {
            return GetVehicles(null);
        }

        public static IEnumerable<Vehicle> GetVehicles(string aVehicleId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();

                if (aVehicleId == null)
                {
                    sqlCommand.CommandText = string.Format("select * from Vehicles");
                }
                else
                {
                    sqlCommand.CommandText = string.Format("select * from Vehicles where VehicleID in ({0})", aVehicleId);
                }

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Vehicle mTask = new Vehicle(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetInt32(2),
                                dataReader.IsDBNull(3) ? null : dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetBoolean(5),
                                dataReader.IsDBNull(6) ? null : dataReader.GetString(6), dataReader.IsDBNull(7) ? null : dataReader.GetString(7));
                        yield return mTask;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<Vehicle> GetVehiclesForDepartmetId(int aDepId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.CommandText = String.Format("select * from Vehicles where VehicleDepartment=" + aDepId.ToString());
                sqlCommand.CommandText = string.Format("select * from Vehicles");
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Vehicle mTask = new Vehicle(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetInt32(2),
                                                        dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetBoolean(5),
                                                        dataReader.IsDBNull(6) ? null : dataReader.GetString(6), dataReader.IsDBNull(7) ? null : dataReader.GetString(7));
                        yield return mTask;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static void InsertVehicle(Vehicle aVehicle)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = string.Format("insert into Vehicles (VehicleSector,VehicleDepartment,VehicleRegNumber,VehicleType,IsEydap,OwnerName,OwnerSurName) VALUES({0}, {1}, '{2}', {3},{4}, '{5}', '{6}')",
                aVehicle.VehicleSector, aVehicle.VehicleDepartment, aVehicle.VehicleRegNumber, aVehicle.VehicleType, aVehicle.IsEydap == true ? 1 : 0, aVehicle.OwnerName, aVehicle.OwnerSurName);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static void UpdateVehicle(Vehicle aVehicle)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = string.Format("update Vehicles set VehicleSector = {0} ,VehicleDepartment = {1} ,VehicleRegNumber = '{2}', VehicleType = {3} ,IsEydap = {4} ,OwnerName = '{5}' ,OwnerSurName = '{6}' where VehicleID = {7}",
                aVehicle.VehicleSector, aVehicle.VehicleDepartment, aVehicle.VehicleRegNumber, aVehicle.VehicleType, aVehicle.IsEydap == true ? 1 : 0, aVehicle.OwnerName, aVehicle.OwnerSurName, aVehicle.VehicleID);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }


        public static IEnumerable<VehicleType> GetVehicleTypes()
        {
            List<VehicleType> mList = new List<VehicleType>();

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = string.Format("select * from VehicleTypes");
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        VehicleType mVehicleType = new VehicleType(dataReader.GetInt32(0), dataReader.GetString(1));
                        yield return mVehicleType;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }

            // mList.Add(new VehicleType(1, "Åêóêáöéêü"));
            // mList.Add(new VehicleType(2, "ÁåñïóõìðéåóôÞò"));
            // mList.Add(new VehicleType(3, "Åðéâáôéêü"));
            // return mList;
        }

        public static IEnumerable<PersonnelType> GetPersonnelTypes()
        {
            List<PersonnelType> mList = new List<PersonnelType>();
            mList.Add(new PersonnelType(1, "Επικεφαλής"));
            mList.Add(new PersonnelType(2, "Εργοδηγός"));
            mList.Add(new PersonnelType(3, "Οδηγός"));
            mList.Add(new PersonnelType(4, "Εργάτης"));
            return mList;
        }

        #region this has been cached in the hashtable
        /*public static string GetDepartmentName(int aDeptId)
        {
            string lExit = "-";

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = String.Format("select DepartmentName from Departments where DepartmentId={0}", aDeptId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        lExit = dataReader.GetString(0);
                    }
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }


            return lExit;
        }*/
        #endregion


        public static IEnumerable<DepartmentsToTasksModel> GetDepartmentsToTasksModels()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = string.Format("select * from DepartmentsToTasks");
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var task = new DepartmentsToTasksModel()
                        {
                            ID = dataReader.GetGuid(0),
                            DDTSectorID = dataReader.GetInt32(1),
                            DDTDepartmentID = dataReader.GetInt32(2),
                            DDTTaskId = dataReader.GetInt32(3),
                            DDTIsActive = dataReader.GetInt32(4)
                        };
                        yield return task;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        //
        // 13.12.2017, Andreas Kasapleris, change to model
        //
        public static void InsertDepartmentsToTasks(DepartmentsToTasksModel departmentTask)
        {
            try
            {
                if (departmentTask.ID != Guid.Empty)
                {
                    throw new Exception($"Ο κωδικός της εγγραφής πρέπει να είναι {Guid.Empty}");
                }

                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        Connection = sqlConnection,
                        CommandType = CommandType.Text,
                        CommandText = @"
                        INSERT INTO DepartmentsToTasks (
                            ID,
                            SectorID,
                            DepartmentId,
                            TaskId,
                            IsActive
                        ) VALUES (
                            @Id,
                            @SectorId,
                            @DepartmentId,
                            @TaskId,
                            @Active
                        )"
                    };

                    sqlCommand.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    sqlCommand.Parameters.AddWithValue("@SectorId", departmentTask.DDTSectorID);
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentTask.DDTDepartmentID);
                    sqlCommand.Parameters.AddWithValue("@TaskId", departmentTask.DDTTaskId);
                    sqlCommand.Parameters.AddWithValue("@Active", departmentTask.DDTIsActive);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Η δημιουργία της εγγραφής απέτυχε!", exception);
            }
        }

        //
        // 13.12.2017, Andreas Kasapleris, change to model
        //
        public static void UpdateDepartmentsToTasks(DepartmentsToTasksModel departmentTask)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = @"
                    UPDATE DepartmentsToTasks
                    SET
                        SectorID = @SectorId,
                        DepartmentId = @DepartmentId,
                        TaskId = @TaskId,
                        IsActive = @Active
                    WHERE
                        ID = @Id"
                };

                sqlCommand.Parameters.AddWithValue("@Id", departmentTask.ID);
                sqlCommand.Parameters.AddWithValue("@SectorId", departmentTask.DDTSectorID);
                sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentTask.DDTDepartmentID);
                sqlCommand.Parameters.AddWithValue("@TaskId", departmentTask.DDTTaskId);
                sqlCommand.Parameters.AddWithValue("@Active", departmentTask.DDTIsActive);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new ApplicationException("Η ενημέρωση της εγγραφής απέτυχε!", exception);
                }
            }
        }

        public static IEnumerable<ReportType> GetReportTypes()
        {
            SqlDataReader dataReader;
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                // TODO: Call a stored procedure that gets the task types according to the users department and role
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM ReportConfig rc WHERE rc.Enabled = 1 ORDER BY rc.ReportConfigId"
                };

                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var reportType = new ReportType(
                        dataReader.GetInt32(0),
                        dataReader.GetString(1),
                        dataReader.GetString(2)
                    );
                    yield return reportType;
                }
            }

            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        public static IEnumerable<Personnel> GetPersonnelforrDepartmentId(int aDepartmentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = string.Format("select * from Personnel where PersonnelDepartmentID = {0}", aDepartmentId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Personnel mPersonnel = new Personnel(dataReader.GetInt32(0), dataReader.IsDBNull(1) ? null : dataReader.GetString(1), dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                                        dataReader.GetInt32(3), dataReader.GetInt32(4), dataReader.GetInt32(5),
                                                        dataReader.GetInt32(6), dataReader.GetBoolean(7));
                        yield return mPersonnel;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }


        public static IEnumerable<Incident> GetIncidentsForSearch(IncidentSearchCriteria searchCriteria, UsersModel user)
        {
            // Improvement for date format, 28.06.2018, Andreas Kasapleris
            var format = new CultureInfo("el-GR"); // needed for dd/mm/yyyy format

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = $@"
                        SELECT
                            DISTINCT(TT_Id),
                            ID1022,
                            Customer_Name,
                            Customer_Phone,
                            Customer_Email,
                            Incidents.Municipality,
                            Street_Name,
                            Odos2,
                            Street_Number,
                            Incidents.Comments,
                            Sector,
                            DateOfRegistry,
                            Status,
                            dbo.gethasComments(TT_Id) as CommentCount,
                            STR(dbo.getClosedTaskCountForIncidentId(TT_Id)) + '/' + STR(dbo.getOpenTaskCountForIncidentId(TT_Id)) as Percentage,
                            TicketTraceId,
                            RelatedID1022,
                            EidosProblimatosDescr,
                            ProblimaDescr,
                            TEBCC,
                            dbo.getColorOfTTIdForUserDepartment(TT_Id, {user.DepartmentId}) as myDepColor,
                            dbo.getColorOfTTIdForOtherDepts(TT_Id, {user.DepartmentId}) as otherDepColor,
                            Perioxi,
                            SyntetagmenesVlavis_GeogrMikos,
                            SyntetagmenesVlavis_GeogrPlatos,
                            HmerominiaAnagelias
                        FROM Incidents"
                };

                // Maybe extend query to tasks table
                if (searchCriteria.TaskType != null || searchCriteria.TaskState != null)
                {
                    sqlCommand.CommandText += " JOIN Tasks ON Incidents.TT_Id = Tasks.Incident_Id";
                }

                if (!string.IsNullOrEmpty(searchCriteria.Code1022))
                {
                    sqlCommand.CommandText += " WHERE [ID1022] = @Code1022";
                    sqlCommand.Parameters.AddWithValue("@Code1022", searchCriteria.Code1022);
                }
                else
                {
                    sqlCommand.CommandText += " WHERE [ID1022] IS NOT NULL";
                }

                if (!string.IsNullOrEmpty(searchCriteria.CallerFullName))
                {
                    sqlCommand.CommandText += " AND [OnomaKalountos] LIKE @CallerFullName";
                    sqlCommand.Parameters.AddWithValue("@CallerFullName", "%" + searchCriteria.CallerFullName + "%");
                }

                if (!string.IsNullOrEmpty(searchCriteria.Municipality))
                {
                    sqlCommand.CommandText += " AND [Municipality] = @Municipality";
                    sqlCommand.Parameters.AddWithValue("@Municipality", searchCriteria.Municipality);
                }

                if (!string.IsNullOrEmpty(searchCriteria.StreetName))
                {
                    sqlCommand.CommandText += " AND [Street_Name] = @StreetName";
                    sqlCommand.Parameters.AddWithValue("@StreetName", searchCriteria.StreetName);
                }

                if (!string.IsNullOrEmpty(searchCriteria.Perioxi))
                {
                    sqlCommand.CommandText += " AND [Perioxi] = @Perioxi";
                    sqlCommand.Parameters.AddWithValue("@Perioxi", searchCriteria.Perioxi);
                }

                if (!string.IsNullOrEmpty(searchCriteria.StreetNumber))
                {
                    sqlCommand.CommandText += " AND [Street_Number] LIKE @StreetNumber";
                    sqlCommand.Parameters.AddWithValue("@StreetNumber", "%" + searchCriteria.StreetNumber + "%");
                }

                if (!string.IsNullOrEmpty(searchCriteria.Odos2))
                {
                    sqlCommand.CommandText += " AND [Odos2] = @Odos2";
                    sqlCommand.Parameters.AddWithValue("@Odos2", searchCriteria.Odos2);
                }

                if (searchCriteria.DateFrom.HasValue)
                {
                    sqlCommand.CommandText += " AND [DateOfRegistry] >= @DateFrom ";
                    sqlCommand.Parameters.AddWithValue("@DateFrom", searchCriteria.DateFrom.Value);
                }

                if (searchCriteria.DateTo.HasValue)
                {
                    sqlCommand.CommandText += " AND [DateOfRegistry] <= @DateTo ";

                    //
                    // 28.06.2018, Andreas Kasapleris
                    //
                    DateTime dt1 = searchCriteria.DateTo.Value;
                    DateTime dt2;
                    if (DateTime.TryParse(dt1.ToString(), out dt2)) {
                        dt1 = DateTime.Parse(dt2.AddDays(1).ToString(), format);
                    }

                    sqlCommand.Parameters.AddWithValue("@DateTo", dt1);
                }

                // 15.01.2018, Andreas Kasapleris, extend SQL Query to search also with Task Type
                // you can use either TaskTypeID or TaskTypeDescription
                if (searchCriteria.TaskType != null)
                {
                    sqlCommand.CommandText += " AND Tasks.Task_Description = @TaskType ";
                    sqlCommand.Parameters.AddWithValue("@TaskType", searchCriteria.TaskType);
                }

                // 16.01.2018, Andreas Kasapleris, extend SQL Query to search also with Task State
                if (searchCriteria.TaskState != null)
                {
                    sqlCommand.CommandText += " AND Tasks.State = @TaskState ";
                    sqlCommand.Parameters.AddWithValue("@TaskState", searchCriteria.TaskState);
                }

                var showCrossSectorResults = searchCriteria.ShowCrossSectorResults ?? false;

                if (!showCrossSectorResults)
                {
                    if (user.RoleId == 1 || user.RoleId == 2)
                    {
                        sqlCommand.CommandText += " AND TT_Id IN (SELECT rh.TTId FROM dbo.RoutingHistory rh WHERE dbo.SectorContains(@SectorId, rh.DepartmentId) = 'TRUE')";
                        sqlCommand.Parameters.AddWithValue("@SectorId", user.SectorId);
                    }
                    else
                    {
                        sqlCommand.CommandText += " AND TT_Id IN (SELECT rh.TTId FROM dbo.RoutingHistory rh WHERE rh.DepartmentId = @DepartmentId)";
                        sqlCommand.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                    }
                }

                sqlCommand.CommandText += " ORDER BY [HmerominiaAnagelias] DESC";

                sqlConnection.Open();

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime? lDate = null;

                        var mIncident = new Incident(
                            dataReader.GetGuid(0),
                            dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                            dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                            dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                            dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4),
                            dataReader.IsDBNull(5) ? string.Empty : dataReader.GetString(5),
                            dataReader.IsDBNull(6) ? string.Empty : dataReader.GetString(6),
                            dataReader.IsDBNull(7) ? string.Empty : dataReader.GetString(7),
                            dataReader.IsDBNull(8) ? string.Empty : dataReader.GetString(8),
                            dataReader.IsDBNull(9) ? string.Empty : dataReader.GetString(9),
                            dataReader.GetInt32(10),
                            dataReader.IsDBNull(11) ? lDate : dataReader.GetDateTime(11),
                            dataReader.GetInt32(12),
                            dataReader.GetInt32(13),
                            dataReader.GetString(14),
                            dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                            dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                            dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                            dataReader.IsDBNull(18) ? null : dataReader.GetString(18),
                            dataReader.IsDBNull(19) ? null : dataReader.GetString(19),
                            dataReader.GetInt32(20),
                            dataReader.GetInt32(21),
                            dataReader.IsDBNull(22) ? null : dataReader.GetString(22),
                            dataReader.IsDBNull(23) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(23)),
                            dataReader.IsDBNull(24) ? 0.0 : Convert.ToDouble(dataReader.GetDecimal(24))
                        );

                        yield return mIncident;
                    }

                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public const string GetIncidentMunicipalitiesCommandText = "SELECT DISTINCT [Municipality] FROM [dbo].[Incidents] ORDER BY [Municipality]";

        public static List<SelectListItem> GetIncidentMunicipalities()
        {
            var result = new List<SelectListItem>();
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandText = GetIncidentMunicipalitiesCommandText,
                    CommandType = CommandType.Text,
                    Connection = sqlConnection
                };
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                // TODO: Maybe handle exception
            }

            if (dataReader == null)
            {
                return result;
            }

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        var selectListItem = new SelectListItem
                        {
                            Text = dataReader.GetString(0),
                            Value = dataReader.GetString(0)
                        };
                        result.Add(selectListItem);
                    }
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();

            return result;
        }

        public const string GetIncidentStreetNamesCommandText = "SELECT DISTINCT [Street_Name] FROM [dbo].[Incidents] WHERE [Municipality] = @municipality ORDER BY [Street_Name]";

        public static List<SelectListItem> GetIncidentStreetNames(string aMunicipality)
        {
            List<SelectListItem> lExit = new List<SelectListItem>();
            if (string.IsNullOrEmpty(aMunicipality))
            {
                return lExit;
            }

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandText = GetIncidentStreetNamesCommandText,
                    CommandType = CommandType.Text,
                    Connection = sqlConnection
                };

                sqlCommand.Parameters.AddWithValue("@municipality", aMunicipality);

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(0))
                        {
                            string lVal = dataReader.GetString(0);
                            if (!string.IsNullOrEmpty(lVal))
                            {
                                var lItem = new SelectListItem
                                {
                                    Text = lVal,
                                    Value = lVal
                                };

                                lExit.Add(lItem);
                            }
                        }
                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                sqlConnection.Close();
            }
            return lExit;
        }

        public const string GetIncidentPerioxesCommandText = "SELECT DISTINCT [Perioxi] FROM [dbo].[Incidents] WHERE [Municipality] = @municipality ORDER BY [Perioxi]";

        public static List<SelectListItem> GetIncidentPerioxes(string aMunicipality)
        {
            var lExit = new List<SelectListItem>();
            if (string.IsNullOrEmpty(aMunicipality))
            {
                return lExit;
            }

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandText = GetIncidentPerioxesCommandText,
                    CommandType = CommandType.Text,
                    Connection = sqlConnection
                };

                sqlCommand.Parameters.AddWithValue("@municipality", aMunicipality);

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(0))
                        {
                            string lVal = dataReader.GetString(0);
                            if (!string.IsNullOrEmpty(lVal))
                            {
                                var lItem = new SelectListItem
                                {
                                    Text = lVal,
                                    Value = lVal
                                };

                                lExit.Add(lItem);
                            }
                        }
                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                sqlConnection.Close();
            }
            return lExit;
        }

        public const string GetIncidentDistinctOdos2CommandText = "SELECT DISTINCT [Odos2] FROM [dbo].[Incidents] WHERE [Municipality] = @municipality ORDER BY [Odos2]";

        public static List<SelectListItem> GetIncidentDistinctOdos2(string aMunicipality)
        {
            List<SelectListItem> lExit = new List<SelectListItem>();
            if (string.IsNullOrEmpty(aMunicipality))
            {
                return lExit;
            }

            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandText = GetIncidentDistinctOdos2CommandText,
                    CommandType = CommandType.Text,
                    Connection = sqlConnection
                };

                sqlCommand.Parameters.AddWithValue("@municipality", aMunicipality);

                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(0))
                        {
                            string lVal = dataReader.GetString(0);
                            if (!string.IsNullOrEmpty(lVal))
                            {
                                var lItem = new SelectListItem
                                {
                                    Text = lVal,
                                    Value = lVal
                                };

                                lExit.Add(lItem);
                            }
                        }
                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                sqlConnection.Close();
            }
            return lExit;
        }

        public static IEnumerable<IncidentRoutingElement> GetIncidentLog(Guid aTTId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "GetIncidentLog";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@TTId", aTTId);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        IncidentRoutingElement mIncidentRoutingElement = new IncidentRoutingElement(dataReader.GetGuid(0), dataReader.GetGuid(1), dataReader.GetString(2), dataReader.GetDateTime(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7));
                        yield return mIncidentRoutingElement;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<TTRoute> GetRoutedDepartmentsForTicket(Guid aTTId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = string.Format("select * from RoutingHistory where TTId = '{0}'", aTTId);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        TTRoute mRoutedDepartment = new TTRoute(dataReader.GetGuid(0), dataReader.GetInt32(1), dataReader.IsDBNull(4) ? (int?)null : dataReader.GetInt32(4), dataReader.GetInt32(2), dataReader.GetDateTime(3));
                        yield return mRoutedDepartment;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public static void RejectTicket(Guid aTTId, UsersModel aUser)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = string.Format("update Incidents set Status = 5 where TT_Id = '{0}'", aTTId.ToString());

            SqlCommand sqlCommandLog = new SqlCommand();
            sqlCommandLog.Connection = sqlConnection;
            sqlCommandLog.CommandText = "insert into RoutingHistoryLog VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";//

            sqlCommandLog.Parameters.AddWithValue("@param1", Guid.NewGuid());
            sqlCommandLog.Parameters.AddWithValue("@param2", aTTId);
            sqlCommandLog.Parameters.AddWithValue("@param3", aUser.SectorId);
            sqlCommandLog.Parameters.AddWithValue("@param4", aUser.DepartmentId);
            sqlCommandLog.Parameters.AddWithValue("@param5", DateTime.Now);
            sqlCommandLog.Parameters.AddWithValue("@param6", "Reject");
            sqlCommandLog.Parameters.AddWithValue("@param7", aUser.Name);

            SqlTransaction mTrans = null;
            try
            {
                sqlConnection.Open();
                mTrans = sqlConnection.BeginTransaction();
                sqlCommand.Transaction = mTrans;
                sqlCommandLog.Transaction = mTrans;

                sqlCommand.ExecuteNonQuery();
                sqlCommandLog.ExecuteNonQuery();
                mTrans.Commit();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (mTrans != null)
                {
                    mTrans.Rollback();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }

        public static int UnRouteTicket(Guid aTTId, UsersModel aUser)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            SqlCommand sqlCommandepartmentsdcount = new SqlCommand();
            sqlCommandepartmentsdcount.Connection = sqlConnection;
            sqlCommandepartmentsdcount.CommandText = "select count(*) from RoutingHistory where TTId = @param1";
            sqlCommandepartmentsdcount.Parameters.AddWithValue("@param1", aTTId);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "delete from RoutingHistory where TTId = @param1 and DepartmentId=@param2";

            sqlCommand.Parameters.AddWithValue("@param1", aTTId);
            sqlCommand.Parameters.AddWithValue("@param2", aUser.DepartmentId);

            SqlCommand sqlCommandLog = new SqlCommand();
            sqlCommandLog.Connection = sqlConnection;
            sqlCommandLog.CommandText = "insert into RoutingHistoryLog VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";//

            sqlCommandLog.Parameters.AddWithValue("@param1", Guid.NewGuid());
            sqlCommandLog.Parameters.AddWithValue("@param2", aTTId);
            sqlCommandLog.Parameters.AddWithValue("@param3", aUser.SectorId);
            sqlCommandLog.Parameters.AddWithValue("@param4", aUser.DepartmentId);
            sqlCommandLog.Parameters.AddWithValue("@param5", DateTime.Now);
            sqlCommandLog.Parameters.AddWithValue("@param6", "UnRoute");
            sqlCommandLog.Parameters.AddWithValue("@param7", aUser.Name);

            SqlCommand sqlCommandTaskcount = new SqlCommand();
            sqlCommandTaskcount.Connection = sqlConnection;
            sqlCommandTaskcount.CommandText = "select count(*) from Tasks where Incident_Id = @param1 and DepartmentId = @param2";
            sqlCommandTaskcount.Parameters.AddWithValue("@param1", aTTId);
            sqlCommandTaskcount.Parameters.AddWithValue("@param2", aUser.DepartmentId);

            SqlTransaction mTrans = null;
            try
            {
                sqlConnection.Open();
                int taskcount = Convert.ToInt32(sqlCommandTaskcount.ExecuteScalar());
                if (taskcount != 0)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return 2; // cannot unroute has tasks
                }

                int ret = (int)sqlCommandepartmentsdcount.ExecuteScalar();
                if (ret != 1)
                {
                    mTrans = sqlConnection.BeginTransaction();
                    sqlCommand.Transaction = mTrans;
                    sqlCommandLog.Transaction = mTrans;

                    sqlCommand.ExecuteNonQuery();
                    sqlCommandLog.ExecuteNonQuery();
                    mTrans.Commit();
                }
                sqlConnection.Close();
                if (ret == 1)
                {
                    return 1; //cannot uroute only one department - route to other first
                }
                else
                {
                    return 0; // OK
                }
            }
            catch (Exception e)
            {
                if (mTrans != null)
                {
                    mTrans.Rollback();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
        }
        public static bool RerouteToOtherSector(Guid aTTId, int aSectorId, int aDepartmentId, UsersModel auser)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select DepartmentName from Departments where DepartmentId = @param1";
                sqlCommand.Parameters.AddWithValue("@param1", aDepartmentId);

                string ret = sqlCommand.ExecuteScalar().ToString();

                SqlCommand sqlCommandUpdateSector = new SqlCommand();
                sqlCommandUpdateSector.Connection = sqlConnection;
                sqlCommandUpdateSector.CommandText = "update Incidents set Sector = @param1, TmimaID = @param2, TmimaName = @param3, Status = 1 where TT_Id = @param4";
                sqlCommandUpdateSector.Parameters.AddWithValue("@param1", Convert.ToInt32(aSectorId));
                sqlCommandUpdateSector.Parameters.AddWithValue("@param2", Convert.ToInt32(aDepartmentId));
                sqlCommandUpdateSector.Parameters.AddWithValue("@param3", ret);
                sqlCommandUpdateSector.Parameters.AddWithValue("@param4", aTTId);
                sqlCommandUpdateSector.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();

            }
            return true;
        }

        public static void UnRouteTicketFromSector(Guid aTTId, UsersModel aUser, int aToSector)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select *  from RoutingHistory where TTId = @param1 and SectorId = @param2";

            sqlCommand.Parameters.AddWithValue("@param1", aTTId);
            sqlCommand.Parameters.AddWithValue("@param2", aUser.SectorId);

            DataTable mTable = new DataTable("Unroute");

            try
            {
                sqlConnection.Open();
                mTable.Load(sqlCommand.ExecuteReader());
                sqlConnection.Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }


            DataRow mRow = null;
            for (int n=0; n< mTable.Rows.Count;n++)
            {
                mRow = mTable.Rows[n];
                SqlCommand sqlCommandDeleteRoute = new SqlCommand();
                sqlCommandDeleteRoute.Connection = sqlConnection;
                sqlCommandDeleteRoute.CommandText = "delete from RoutingHistory where TTId = @param1 and DepartmentId = @param2";//
                sqlCommandDeleteRoute.Parameters.AddWithValue("@param1", aTTId);
                sqlCommandDeleteRoute.Parameters.AddWithValue("@param2", Convert.ToInt32(mRow["DepartmentId"]));


                SqlCommand sqlCommandLog = new SqlCommand();
                sqlCommandLog.Connection = sqlConnection;
                sqlCommandLog.CommandText = "insert into RoutingHistoryLog VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";//

                sqlCommandLog.Parameters.AddWithValue("@param1", Guid.NewGuid());
                sqlCommandLog.Parameters.AddWithValue("@param2", aTTId);
                sqlCommandLog.Parameters.AddWithValue("@param3", aUser.SectorId);
                sqlCommandLog.Parameters.AddWithValue("@param4", aUser.DepartmentId);
                sqlCommandLog.Parameters.AddWithValue("@param5", DateTime.Now);
                sqlCommandLog.Parameters.AddWithValue("@param6", "UnRouteFromSector");
                sqlCommandLog.Parameters.AddWithValue("@param7", aUser.Name);


                SqlTransaction mTrans = null;
                try
                {
                    sqlConnection.Open();

                    mTrans = sqlConnection.BeginTransaction();
                    sqlCommandDeleteRoute.Transaction = mTrans;
                    sqlCommandLog.Transaction = mTrans;

                    sqlCommandDeleteRoute.ExecuteNonQuery();
                    sqlCommandLog.ExecuteNonQuery();
                    mTrans.Commit();

                    sqlConnection.Close();

                }
                catch (Exception e)
                {
                    if (mTrans != null)
                    {
                        mTrans.Rollback();
                    }
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                    throw e;
                }
            }
        }


        public static void SaveIncidentFromTablet(Guid aAssignmentID, string aComments)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "update Visits set RemarksFromTablet = @param1 where AssignmentId = @param2";

            sqlCommand.Parameters.AddWithValue("@param1", aComments);
            sqlCommand.Parameters.AddWithValue("@param2", aAssignmentID);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }

        }

        public static string GetAllCommentsForTask(Guid taskId)
        {
            var dataTable = new DataTable();
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT Remarks FROM Visits WHERE Task_Id = @TaskId ORDER BY DateOfAssignment ASC"
            };

            sqlCommand.Parameters.AddWithValue("@TaskId", taskId);

            try
            {
                sqlConnection.Open();
                dataTable.Load(sqlCommand.ExecuteReader());
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            var sb = new StringBuilder();
            for (int n = 0; n < dataTable.Rows.Count; n++)
            {
                DataRow dataRow = dataTable.Rows[n];
                if (!string.IsNullOrEmpty(dataRow[0].ToString()))
                {
                    sb.Append(dataRow[0]);
                    sb.AppendLine();
                }
            }

            if (sb.Length == 0)
            {
                sb.Append("Δεν βρέθηκαν σχόλια.");
            }

            return sb.ToString();
        }

        public static void InsertRoute(TTRoute route, string userName)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = @"
                    INSERT INTO RoutingHistory
                    VALUES(
                        @IncidentId,
                        @SectorId,
                        @DepartmentId,
                        @RouteDate,
                        @FromDepartmentId
                    )"
            };

            sqlCommand.Parameters.AddWithValue("@IncidentId", route.TTId);
            sqlCommand.Parameters.AddWithValue("@SectorId", route.SectorId);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", route.ToDepartmentId);
            sqlCommand.Parameters.AddWithValue("@RouteDate", route.RouteDate);
            sqlCommand.Parameters.AddWithValue("@FromDepartmentId", route.FromDepartmentId);

            var sqlCommandLog = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = @"
                    INSERT INTO RoutingHistoryLog
                    VALUES(
                        @Id,
                        @IncidentId,
                        @SectorId,
                        @DepartmentId,
                        @Date,
                        @Action,
                        @User
                    )"
            };

            sqlCommandLog.Parameters.AddWithValue("@Id", Guid.NewGuid());
            sqlCommandLog.Parameters.AddWithValue("@IncidentId", route.TTId);
            sqlCommandLog.Parameters.AddWithValue("@SectorId", route.SectorId);
            sqlCommandLog.Parameters.AddWithValue("@DepartmentId", route.ToDepartmentId);
            sqlCommandLog.Parameters.AddWithValue("@Date", route.RouteDate);
            sqlCommandLog.Parameters.AddWithValue("@Action", "Route");
            sqlCommandLog.Parameters.AddWithValue("@User", userName);

            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();

                sqlCommand.Transaction = sqlTransaction;
                sqlCommandLog.Transaction = sqlTransaction;

                sqlCommand.ExecuteNonQuery();
                sqlCommandLog.ExecuteNonQuery();

                sqlTransaction.Commit();
            }
            catch (Exception exception)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
                throw exception;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public static string GetIncidentStatus(Guid aIncidentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = string.Format("select StatusDescription from StatusDefinitions a , Incidents b WHERE a.StatusId = b.Status and b.TT_Id = '{0}'", aIncidentId);
            string ret = null;
            try
            {
                sqlConnection.Open();
                ret = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return ret;
        }

        public static DataTable UpdateIncidentStatus(Guid aIncidentId, int aNewState, UsersModel aUser)
        {

            DataTable mTable = new DataTable("Related");
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlTransaction mTransaction = null;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            string updatecommandtext = null;
            if (aNewState == 3)
            {
                updatecommandtext = string.Format("update Incidents set Status = {1}, ClosingDate = GETDATE() WHERE TT_Id = '{0}'", aIncidentId, aNewState);
            }
            else
            {
                updatecommandtext = string.Format("update Incidents set Status = {1}, ClosingDate = null WHERE TT_Id = '{0}'", aIncidentId, aNewState);
            }
            sqlCommand.CommandText = updatecommandtext;
            try
            {
                sqlConnection.Open();
                mTransaction = sqlConnection.BeginTransaction();
                sqlCommand.Transaction = mTransaction;
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnection;
                sqlCommand1.Transaction = mTransaction;
                sqlCommand1.CommandText = "select ID1022 from Incidents where TT_Id ='" + aIncidentId + "'";
                sqlCommand1.CommandType = CommandType.Text;
                object id1022 = sqlCommand1.ExecuteScalar();

                SqlCommand sqlCommandRelated = new SqlCommand();
                sqlCommandRelated.Connection = sqlConnection;
                sqlCommandRelated.Transaction = mTransaction;
                sqlCommandRelated.CommandText = "select TicketTraceId from Incidents where RelatedID1022='" + id1022 + "'";
                sqlCommandRelated.CommandType = CommandType.Text;
                mTable.Load(sqlCommandRelated.ExecuteReader());

                if (id1022 != null && (string)id1022 != string.Empty)
                {
                    string updatetext = null;
                    if (aNewState == 3)
                    {
                        updatetext = string.Format("update Incidents  set Status = {1}, ClosingDate = GETDATE() WHERE RelatedID1022='{0}'", id1022.ToString(), aNewState);
                    }
                    else
                    {
                        updatetext = string.Format("update Incidents  set Status = {1}, ClosingDate = null WHERE RelatedID1022='{0}'", id1022.ToString(), aNewState);
                    }

                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Connection = sqlConnection;
                    sqlCommand.Transaction = mTransaction;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = updatetext;
                    sqlCommand.ExecuteNonQuery();
                }

                SqlCommand sqlCommandLog = new SqlCommand();
                sqlCommandLog.Connection = sqlConnection;
                sqlCommandLog.CommandText = "insert into RoutingHistoryLog VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";//
                sqlCommandLog.Transaction = mTransaction;

                sqlCommandLog.Parameters.AddWithValue("@param1", Guid.NewGuid());
                sqlCommandLog.Parameters.AddWithValue("@param2", aIncidentId);
                sqlCommandLog.Parameters.AddWithValue("@param3", aUser.SectorId);
                sqlCommandLog.Parameters.AddWithValue("@param4", aUser.DepartmentId);
                sqlCommandLog.Parameters.AddWithValue("@param5", DateTime.Now);
                sqlCommandLog.Parameters.AddWithValue("@param6", "State Change: " + aNewState);
                sqlCommandLog.Parameters.AddWithValue("@param7", aUser.Name);
                sqlCommandLog.ExecuteNonQuery();

                mTransaction.Commit();
                sqlConnection.Close();
                mTransaction.Dispose();
                sqlConnection.Dispose();
            }
            catch (Exception e)
            {
                if (sqlConnection != null)
                {
                    mTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                throw e;
            }
            return mTable;
        }

        //
        // 13.11.2017, Andreas Kasapleris
        // modified to get only proper statuses of an Incident
        // i.e. if open Tasks exist for a given Incident, status
        // 'Κλειστή' should not be an option in the statuses
        //

        public static IEnumerable<StatusDefinition> GetStatusDefinitions(string TT_id)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();

                if (TT_id == null)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from StatusDefinitions";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = sqlConnection;
                    dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand("getProperIncidentStatuses");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@TT_id", SqlDbType.UniqueIdentifier).Value = Guid.Parse(TT_id);
                    sqlCommand.Connection = sqlConnection;
                    dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception /* exception */)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                yield break;
            }

            if (dataReader != null)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        StatusDefinition mStatusDefinition = new StatusDefinition(dataReader.GetInt32(0), dataReader.GetString(1));
                        yield return mStatusDefinition;
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    sqlConnection.Close();
                }
            }
        }


        public static void SaveIncidentComments(Guid aIncidentId, string aNewComment)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand  = new SqlCommand();
            sqlCommand.Connection  = sqlConnection;
            sqlCommand.CommandText = "insert into IncidentComments (IncidentId, Comments) values  (@IncidentId, @Comments)";

            sqlCommand.Parameters.AddWithValue("@IncidentId", aIncidentId);
            if (!string.IsNullOrEmpty(aNewComment))
            {
                sqlCommand.Parameters.AddWithValue("@Comments", aNewComment);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Comments", string.Empty);
            }

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public static List<IncidentComments> GetIncidentComments(Guid incidentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = @"
                        SELECT *
                        FROM IncidentComments
                        WHERE IncidentId = @IncidentId
                        ORDER BY IncidentComentDate DESC",
            };

            sqlCommand.Parameters.AddWithValue("@IncidentId", incidentId);

            var dataTable = new DataTable();
            try
            {
                sqlConnection.Open();
                dataTable.Load(sqlCommand.ExecuteReader(CommandBehavior.CloseConnection));
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            var incidentComments = new List<IncidentComments>();
            var sb = new StringBuilder();

            if (dataTable.Rows.Count != 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                incidentId = Guid.Parse(dataRow[0].ToString());
                for (int n = 0; n < dataTable.Rows.Count; n++)
                {
                    dataRow = dataTable.Rows[n];
                    sb.Append(dataRow[1].ToString());
                    sb.AppendLine();
                }

                incidentComments.Add(new IncidentComments(incidentId, sb.ToString()));
            }

            return incidentComments;
        }

        public static List<Ergolavos> GetErgolavoi(int sectorId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader = null;

            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = @"
                        SELECT
                            ErgolavosID,
                            ErgName
                        FROM
                            Ergolavoi
                        WHERE
                            SectorId = @SectorId",
                };

                sqlCommand.Parameters.AddWithValue("@SectorId", sectorId);

                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
                throw exception;
            }

            var ergolavoi = new List<Ergolavos>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var ergolavos = new Ergolavos
                    {
                        ErgolavosId = dataReader.GetInt32(0),
                        ErgName = dataReader.GetString(1)
                    };

                    ergolavoi.Add(ergolavos);
                }
            }

            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();

            return ergolavoi;
        }

        public static int GetColorForUserDept(string TTId, string userName, int departmentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,

                    // 04.12.2017, Andreas Kasapleris
                    // You can't just call the function name, you need to write an inline SQL statement
                    // which makes use of the User Defined Function.
                    // DO NOT use the 'CommandType'; it isn't a Stored Procedure, it is a (Scalar) User
                    // Defined Function. So, call it like below.
                    CommandText = "SELECT dbo.getColorOfTTIdForUserDepartment(@TTId, @DepartmentId)",
                };

                sqlCommand.Parameters.AddWithValue("@TTId", Guid.Parse(TTId));
                sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

                return (int)sqlCommand.ExecuteScalar();
            }
            //catch (Exception exception)
            //{
            //    throw exception;
            //}
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        // 04.12.2017, Andreas Kasapleris
        // You can't just call the function name, you need to write an inline SQL statement
        // which makes use of the User Defined Function.
        // DO NOT use the 'CommandType'; it isn't a Stored Procedure, it is a (Scalar) User
        // Defined Function. So, call it like below.
        public const string SetColorForOtherDeptsCommandText = "SELECT dbo.getColorOfTTIdForOtherDepts(@TTId, @DepartmentId)";

        public static int SetColorForOtherDepts(string TTId, string userName, int departmentId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(SetColorForOtherDeptsCommandText, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TTId", Guid.Parse(TTId));
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

                    sqlConnection.Open();
                    return (int)sqlCommand.ExecuteScalar();
                }
            }
        }

        public const string IsTicketRelatedCommandText = "SELECT RelatedID1022 FROM Incidents WHERE TT_Id = @incidentId";

        public static bool IsTicketRelated(Guid incidentId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(IsTicketRelatedCommandText, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@incidentId", incidentId);

                    sqlConnection.Open();
                    var relatedId = sqlCommand.ExecuteScalar();

                    return !string.IsNullOrEmpty(relatedId as string);
                }
            }
        }

        // 19.07.2017, Andreas Kasapleris
        // You can't just call the function name, you need to write an inline SQL statement
        // which makes use of the User Defined Function.
        // DO NOT use the 'CommandType'; it isn't a Stored Procedure, it is a (Scalar) User
        // Defined Function. So, call it like below.
        public const string GetNrOfRelatedID1022CommandText = "SELECT dbo.GetNrOfRelatedID1022(@incidentId)";

        /// <summary>
        /// Determine whether an ID1022 has a RelatedID1022
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public static int GetNrOfRelatedID1022(Guid incidentId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(GetNrOfRelatedID1022CommandText, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@incidentId", incidentId);

                    sqlConnection.Open();
                    return (int)sqlCommand.ExecuteScalar();
                }
            }
        }
    }
}