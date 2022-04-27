using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections; // 20.05.2016, added manually
using System.Data; // 20.05.2016, added manually
using System.Data.Common; // 20.05.2016, added manually
using System.Data.SqlClient; // 20.05.2016, added manually
using System.Data.SqlTypes; // 20.05.2016, added manually
using System.Configuration; // 20.05.2016, added manually

namespace EydapTickets.Models
{
    public class SectorsDAL
    {

        public static IEnumerable<SectorsModel> GetSectors()
        {
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlDataReader mReader = null;
            try
            {
                mConnection.Open();
                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.Text;
                mCommand.CommandText = "SELECT * FROM Sectors";
                mCommand.Connection = mConnection;
                mReader = mCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                yield break;
            }
            if (mReader != null)
            {
                if (mReader.HasRows)
                {
                    while (mReader.Read())
                    {
                        var sector = new SectorsModel()
                        {
                            SectorId = mReader.GetInt32(0),
                            SectorCode = mReader.GetString(1),
                            SectorDescription = mReader.GetString(2)
                        };
                        yield return sector;
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
            yield break;
        }

        //
        // 06.07.2018, Andreas Kasapleris
        // method used for Re.Routing; allow users to re.route
        // only to other Sectors
        //
        public static IEnumerable<SectorsModel> GetSectorsForRerouting(int sourceSectorId)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString()))
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM Sectors WHERE 1=1"
                };

                if (sourceSectorId > 0)
                {
                    sqlCommand.CommandText += " AND SectorId != @SectorId";
                    sqlCommand.Parameters.AddWithValue("@SectorId", sourceSectorId);
                }

                SqlDataReader sqlDataReader;

                try
                {
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception /* exception */)
                {
                    yield break;
                }

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        var sector = new SectorsModel()
                        {
                            SectorId = sqlDataReader.GetInt32(0),
                            SectorCode = sqlDataReader.GetString(1),
                            SectorDescription = sqlDataReader.GetString(2)
                        };
                        yield return sector;
                    }
                }

                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
        }

        //
        // Creation Date : 20.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table Sectors
        // Related Tables: Sectors
        // Update History:
        // 23.05.2016, code to check if sector description field is empty
        // Known bugs    : if user enters spaces in sector description value is accepted

        public static void InsertSector(SectorsModel aSector)
        {
            // 29.06.2016, code to check if sector code field is empty
            if (String.IsNullOrEmpty(aSector.SectorCode))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 23.05.2016, code to check if sector description field is empty
            if (String.IsNullOrEmpty(aSector.SectorDescription))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = String.Format("INSERT INTO Sectors VALUES( '{0}', '{1}' )",
                                      aSector.SectorCode, aSector.SectorDescription);
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
                // 20.05.2016; throw only original exception message
                // throw e;

                // 20.05.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η καταχώρηση νέου Τομέα ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }

        }

        //
        // Creation Date : 20.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : update record in SQL Table Sectors
        // Related Tables: Sectors
        // Update History:
        // 23.05.2016, code to check if sector description field is empty
        // Known bugs    : if user enters spaces in sector description value is accepted

        public static void UpdateSector(SectorsModel aSector)
        {
            // 29.06.2016, code to check if sector code field is empty
            if (String.IsNullOrEmpty(aSector.SectorCode))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 23.05.2016, code to check if sector description field is empty
            if (String.IsNullOrEmpty(aSector.SectorDescription))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = String.Format("UPDATE Sectors SET SectorCode = '{1}', SectorDescription = '{2}' WHERE SectorId = {0}",
                                      aSector.SectorId, aSector.SectorCode, aSector.SectorDescription);
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
                // 20.05.2016; throw only original exception message
                // throw e;

                // 20.05.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η μεταβολή του Τομέα ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }
        }

    }
}