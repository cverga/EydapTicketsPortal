using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Globalization;

//
// added manually
//
using System.Collections;    // 16.06.2016, added manually
using System.Data;           // 16.06.2016, added manually
using System.Data.Common;    // 16.06.2016, added manually
using System.Data.SqlClient; // 16.06.2016, added manually
using System.Data.SqlTypes;  // 16.06.2016, added manually
using System.Configuration;  // 16.06.2016, added manually

namespace EydapTickets.Models
{
    public class IncidentsRoutingDAL
    {

        //
        // Creation Date : 16.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table IncidentsRouting
        // Related Tables: IncidentsRouting
        // Update History: 22.07.2016, changed due to modifications in data model (class)
        //

        public static IEnumerable GetIncidentsRoutings()
        {
            List<IncidentsRoutingModel> ListOfIncidentsRoutings = null;
            DataTable IncidentsRoutingsDT = null;
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

            try
            {
                mConnection.Open();
                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.Text;
                mCommand.CommandText = String.Format(@"SELECT RecId, ComesFromTTSectorName,
                                                              ComesFromTTDeptName, ProblemD04Description,
                                                              FromWorkingDate, ToWorkingDate, FromWeekendDate,
                                                              ToWeekendDate, RouteToDepartmentId,
                                                              RoutingIsActive, Departments.DepartmentName
                                                              FROM INCIDENTSROUTING, Sectors, Departments
                                                              WHERE IncidentsRouting.ComesFromTTSectorName = Sectors.SectorDescription
                                                              AND Departments.DepartmentId = IncidentsRouting.RouteToDepartmentId
                                                              AND Departments.SectorId     = Sectors.SectorId");
                mCommand.Connection = mConnection;

                IncidentsRoutingsDT = new DataTable();
                IncidentsRoutingsDT.Load(mCommand.ExecuteReader());
            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
            }
            finally
            {
                mConnection.Close();
                mConnection.Dispose();
            }

            // create the list which will hold results from data table
            ListOfIncidentsRoutings = new List<IncidentsRoutingModel>();

            // now start processing the data table row by row
            if (IncidentsRoutingsDT != null)
            {
                foreach (DataRow IncidentsRoutingRow in IncidentsRoutingsDT.Rows)
                {
                    //IncidentsRoutingModel mIncidentsRoutingModel =
                    //    new IncidentsRoutingModel(Convert.ToInt32(IncidentsRoutingRow[0]), // RecId
                    //                              Convert.ToInt32(IncidentsRoutingRow[1]), // SectorId
                    //                              Convert.ToString(IncidentsRoutingRow[2]),// SectorName
                    //                              Convert.ToInt32(IncidentsRoutingRow[3]), // EidosProblemsId
                    //                              Convert.ToString(IncidentsRoutingRow[4]),// EidosProblemsDescription
                    //                              Convert.ToInt32(IncidentsRoutingRow[5]), // ProblemsId
                    //                              Convert.ToString(IncidentsRoutingRow[6]),// ProblemsDescription
                    //                              Convert.ToInt32(IncidentsRoutingRow[7]), // EgkatastasiId
                    //                              Convert.ToString(IncidentsRoutingRow[8]),// EgkatastasiDescription
                    //                              Convert.ToInt32(IncidentsRoutingRow[9]), // DepartmentId
                    //                              Convert.ToString(IncidentsRoutingRow[10]), // DepartmentName
                    //                              Convert.ToByte(IncidentsRoutingRow[11]) // RoutingIsActive
                    //                              );

                    IncidentsRoutingModel mIncidentsRoutingModel =
                          new IncidentsRoutingModel(Convert.ToInt32(IncidentsRoutingRow[0]), // RecId
                              Convert.ToString(IncidentsRoutingRow[1]),   // ComesFromTTSectorName
                              Convert.ToString(IncidentsRoutingRow[2]),   // ComesFromTTDeptName
                              Convert.ToString(IncidentsRoutingRow[3]),   // ProblemD04Description
                              Convert.ToDateTime(IncidentsRoutingRow[4]), // FromWorkingDate
                              Convert.ToDateTime(IncidentsRoutingRow[5]), // ToWorkingDate
                              Convert.ToDateTime(IncidentsRoutingRow[6]), // FromWeekendDate
                              Convert.ToDateTime(IncidentsRoutingRow[7]), // ToWeekendDate
                              Convert.ToInt32(IncidentsRoutingRow[8]),    // RouteToDepartmentId
                              Convert.ToByte(IncidentsRoutingRow[9]),     // RoutingIsActive
                              Convert.ToString(IncidentsRoutingRow[10])   // RouteToDepartmentName
                              );

                    ListOfIncidentsRoutings.Add(mIncidentsRoutingModel);
                }
            }

            return ListOfIncidentsRoutings;
        }

        //
        // Creation Date : 23.07.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all Departments for a specific SectorName
        // Related Tables: Departments
        // Update History: 23.07.2016, fetches departments using a sector name, and not a sector id
        //

        public static IEnumerable GetDepartmentsForSector(string sectorDescription)
        {
            var dataTable = new DataTable();
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = @"
                        SELECT
                            d.DepartmentId,
                            d.DepartmentCode,
                            d.DepartmentName,
                            d.SectorId
                            d.FriendlyName
                        FROM
                            Departments d
                            JOIN Sectors s ON d.SectorId = s.SectorId
                        WHERE
                            s.SectorDescription = @SectorDescription",
            };

            sqlCommand.Parameters.AddWithValue("@SectorDescription", sectorDescription);

            try
            {
                sqlConnection.Open();
                dataTable.Load(sqlCommand.ExecuteReader());
            }
            catch (Exception /* exception */)
            {
                // TODO: Maybe handle exception
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            // create the list which will hold results from data table
            var departments = new List<DepartmentsModel>();

            // now start processing the data table row by row
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var department = new DepartmentsModel()
                {
                    DepartmentId = Convert.ToInt32(dataRow[0]),
                    DepartmentCode = Convert.ToString(dataRow[1]),
                    DepartmentName = Convert.ToString(dataRow[2]),
                    SectorId = Convert.ToInt32(dataRow[3]),
                    FriendlyName = Convert.ToString(dataRow[4]),
                };
                departments.Add(department);
            }

            return departments;
        }

        //
        // Creation Date : 26.07.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table D04
        // Related Tables: D04
        // Update History:
        //

        public static IEnumerable GetProblemD04Descriptions()
        {
            List<_1022D04Model> ListOf1022D04Descriptions = null;
            DataTable _1022D04DescriptionsDT = null;
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

            try
            {
                mConnection.Open();

                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.Text;
                mCommand.CommandText = String.Format(@"SELECT D04Id, D04Description FROM D04");
                mCommand.Connection = mConnection;

                _1022D04DescriptionsDT = new DataTable();
                _1022D04DescriptionsDT.Load(mCommand.ExecuteReader());

            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
            }
            finally
            {
                mConnection.Close();
                mConnection.Dispose();
            }

            // create the list which will hold results from data table
            ListOf1022D04Descriptions = new List<_1022D04Model>();

            // now start processing the data table row by row

            if (_1022D04DescriptionsDT != null)
            {
                foreach (DataRow _1022D04Row in _1022D04DescriptionsDT.Rows)
                {
                    _1022D04Model m1022D04Model =
                        new _1022D04Model(Convert.ToInt32(_1022D04Row[0]),  // D04Id
                                          Convert.ToString(_1022D04Row[1])  // D04Description
                                         );

                    ListOf1022D04Descriptions.Add(m1022D04Model);
                }
            }

            return ListOf1022D04Descriptions;

        }

        //
        // Creation Date : 21.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table 1022Problems
        // Related Tables: 1022Problems
        // Update History:
        //

        //public static IEnumerable Get1022Problems()
        //{
        //    List<_1022ProblemsModel> ListOf1022Problems = null;
        //    DataTable _1022ProblemsDT = null;
        //    SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

        //    try
        //    {
        //        mConnection.Open();

        //        SqlCommand mCommand = new SqlCommand();
        //        mCommand.CommandType = CommandType.Text;
        //        mCommand.CommandText = String.Format("SELECT * FROM _1022Problems");
        //        mCommand.Connection = mConnection;

        //        _1022ProblemsDT = new DataTable();
        //        _1022ProblemsDT.Load(mCommand.ExecuteReader());

        //    }
        //    catch (Exception e)
        //    {
        //        if (mConnection != null)
        //        {
        //            mConnection.Close();
        //            mConnection.Dispose();
        //        }
        //    }
        //    finally
        //    {
        //        mConnection.Close();
        //        mConnection.Dispose();
        //    }

        //    // create the list which will hold results from data table
        //    ListOf1022Problems = new List<_1022ProblemsModel>();

        //    // now start processing the data table row by row

        //    if (_1022ProblemsDT != null)
        //    {
        //        foreach (DataRow _1022ProblemsRow in _1022ProblemsDT.Rows)
        //        {
        //            _1022ProblemsModel m1022ProblemsModel =
        //                new _1022ProblemsModel(Convert.ToInt32(_1022ProblemsRow[0]),  // Id
        //                                       Convert.ToString(_1022ProblemsRow[1]), // ProblemsCode
        //                                       Convert.ToString(_1022ProblemsRow[2])  // ProblemsDescription
        //                                          );

        //            ListOf1022Problems.Add(m1022ProblemsModel);
        //        }
        //    }

        //    return ListOf1022Problems;

        //}

        //
        // Creation Date : 21.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table 1022Egkatastasi
        // Related Tables: 1022Egkatastasi
        // Update History:
        //

        //public static IEnumerable Get1022Egkatastasi()
        //{
        //    List<_1022EgkatastasiModel> ListOf1022Egkatastasi = null;
        //    DataTable _1022EgkatastasiDT = null;
        //    SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

        //    try
        //    {
        //        mConnection.Open();

        //        SqlCommand mCommand = new SqlCommand();
        //        mCommand.CommandType = CommandType.Text;
        //        mCommand.CommandText = String.Format("SELECT * FROM _1022Egkatastasi");
        //        mCommand.Connection = mConnection;

        //        _1022EgkatastasiDT = new DataTable();
        //        _1022EgkatastasiDT.Load(mCommand.ExecuteReader());

        //    }
        //    catch (Exception e)
        //    {
        //        if (mConnection != null)
        //        {
        //            mConnection.Close();
        //            mConnection.Dispose();
        //        }
        //    }
        //    finally
        //    {
        //        mConnection.Close();
        //        mConnection.Dispose();
        //    }

        //    // create the list which will hold results from data table
        //    ListOf1022Egkatastasi = new List<_1022EgkatastasiModel>();

        //    // now start processing the data table row by row

        //    if (_1022EgkatastasiDT != null)
        //    {
        //        foreach (DataRow _1022EgkatastasiRow in _1022EgkatastasiDT.Rows)
        //        {
        //            _1022EgkatastasiModel m1022EgkatastasiModel =
        //                new _1022EgkatastasiModel(Convert.ToInt32(_1022EgkatastasiRow[0]),  // Id
        //                                          Convert.ToString(_1022EgkatastasiRow[1]), // ProblemsCode
        //                                          Convert.ToString(_1022EgkatastasiRow[2])  // ProblemsDescription
        //                                          );

        //            ListOf1022Egkatastasi.Add(m1022EgkatastasiModel);
        //        }
        //    }

        //    return ListOf1022Egkatastasi;

        //}

        //
        // Creation Date : 23.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table IncidentsRouting
        // Related Tables: IncidentsRouting
        // Update History: 09/08/2016
        //

        public static void InsertIncidentRouting(IncidentsRoutingModel aUserEnteredIncidentRouting)
        {
            // string lDateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            // string lDateTimeFormat = "dd/MM/yyyy";

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = @"INSERT INTO INCIDENTSROUTING
                                        (
                                         ComesFromTTSectorName,
                                         ComesFromTTDeptName,
                                         ProblemD04Description,
                                         FromWorkingDate,
                                         ToWorkingDate,
                                         FromWeekendDate,
                                         ToWeekendDate,
                                         RouteToDepartmentId,
                                         RoutingIsActive
                                        )
                                        VALUES
                                        (
                                         @vComesFromTTSectorName,
                                         @vComesFromTTDeptName,
                                         @vProblemD04Description,
                                         @vFromWorkingDate,
                                         @vToWorkingDate,
                                         @vFromWeekendDate,
                                         @vToWeekendDate,
                                         @vRouteToDepartmentId,
                                         @vRoutingIsActive
                                        )";


                    mSqlCommand.Parameters.AddWithValue("@vComesFromTTSectorName", aUserEnteredIncidentRouting.ComesFromTTSectorName);
                    mSqlCommand.Parameters.AddWithValue("@vComesFromTTDeptName",   aUserEnteredIncidentRouting.ComesFromTTDeptName);
                    mSqlCommand.Parameters.AddWithValue("@vProblemD04Description", aUserEnteredIncidentRouting.ProblemD04Description);

                    // DateTime vFromWorkingDate = DateTime.ParseExact(aUserEnteredIncidentRouting.FromWorkingDate.ToString(), lDateTimeFormat, CultureInfo.InvariantCulture);
                    mSqlCommand.Parameters.AddWithValue("@vFromWorkingDate", aUserEnteredIncidentRouting.FromWorkingDate);

                    // DateTime vToWorkingDate = DateTime.ParseExact(aUserEnteredIncidentRouting.ToWorkingDate.ToShortDateString(), lDateTimeFormat, CultureInfo.InvariantCulture);
                    mSqlCommand.Parameters.AddWithValue("@vToWorkingDate", aUserEnteredIncidentRouting.ToWorkingDate);

                    // DateTime vFromWeekendDate = DateTime.ParseExact(aUserEnteredIncidentRouting.FromWeekendDate.ToShortDateString(), lDateTimeFormat, CultureInfo.InvariantCulture);
                    mSqlCommand.Parameters.AddWithValue("@vFromWeekendDate", aUserEnteredIncidentRouting.FromWeekendDate);

                    // DateTime vToWeekendDate = DateTime.ParseExact(aUserEnteredIncidentRouting.ToWeekendDate.ToShortDateString(), lDateTimeFormat, CultureInfo.InvariantCulture);
                    mSqlCommand.Parameters.AddWithValue("@vToWeekendDate", aUserEnteredIncidentRouting.ToWeekendDate);

                    mSqlCommand.Parameters.AddWithValue("@vRouteToDepartmentId", aUserEnteredIncidentRouting.RouteToDepartmentId);
                    mSqlCommand.Parameters.AddWithValue("@vRoutingIsActive",     aUserEnteredIncidentRouting.RoutingIsActive);

            try
            {
                mConnection.Open();
                mSqlCommand.ExecuteNonQuery();
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }

                // 08.06.2016; throw only original exception message
                // throw e;

                // 08.06.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η καταχώρηση νέας δρομολόγησης ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }

        }

        //
        // Creation Date : 23.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Update record of SQL Table IncidentsRouting
        // Related Tables: IncidentsRouting
        // Update History: 11/08/2016
        //

        public static void UpdateIncidentRouting(IncidentsRoutingModel aUserModifiedIncidentRouting)
        {
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;

            mSqlCommand.CommandText = @"UPDATE INCIDENTSROUTING
                                           SET
                                               ComesFromTTSectorName = @vComesFromTTSectorName,
                                               ComesFromTTDeptName   = @vComesFromTTDeptName,
                                               ProblemD04Description = @vProblemD04Description,
                                               FromWorkingDate       = @vFromWorkingDate,
                                               ToWorkingDate         = @vToWorkingDate,
                                               FromWeekendDate       = @vFromWeekendDate,
                                               ToWeekendDate         = @vToWeekendDate,
                                               RouteToDepartmentId   = @vRouteToDepartmentId,
                                               RoutingIsActive       = @vRoutingIsActive
                                         WHERE RecId                 = @vRecId";

            mSqlCommand.Parameters.AddWithValue("@vComesFromTTSectorName", aUserModifiedIncidentRouting.ComesFromTTSectorName);
            mSqlCommand.Parameters.AddWithValue("@vComesFromTTDeptName",   aUserModifiedIncidentRouting.ComesFromTTDeptName);
            mSqlCommand.Parameters.AddWithValue("@vProblemD04Description", aUserModifiedIncidentRouting.ProblemD04Description);
            mSqlCommand.Parameters.AddWithValue("@vFromWorkingDate",       aUserModifiedIncidentRouting.FromWorkingDate);
            mSqlCommand.Parameters.AddWithValue("@vToWorkingDate",         aUserModifiedIncidentRouting.ToWorkingDate);
            mSqlCommand.Parameters.AddWithValue("@vFromWeekendDate",       aUserModifiedIncidentRouting.FromWeekendDate);
            mSqlCommand.Parameters.AddWithValue("@vToWeekendDate",         aUserModifiedIncidentRouting.ToWeekendDate);
            mSqlCommand.Parameters.AddWithValue("@vRouteToDepartmentId",   aUserModifiedIncidentRouting.RouteToDepartmentId);
            mSqlCommand.Parameters.AddWithValue("@vRoutingIsActive",       aUserModifiedIncidentRouting.RoutingIsActive);
            mSqlCommand.Parameters.AddWithValue("@vRecId",                 aUserModifiedIncidentRouting.RecId);

            try
            {
                mConnection.Open();
                mSqlCommand.ExecuteNonQuery();
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }

                // 08.06.2016; throw only original exception message
                // throw e;

                // 08.06.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η μεταβολή της δρομολόγησης ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }
        }

    }
}