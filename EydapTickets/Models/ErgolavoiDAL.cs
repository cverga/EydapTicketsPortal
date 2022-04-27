using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EydapTickets.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EydapTickets.Models
{
    public class ErgolavoiDAL
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        //
        // 02.11.2018, Andreas Kasapleris
        // gets records from table Ergolavoi
        //
        public static IEnumerable<Ergolavoi> GetErgolavoi()
        {
            var dtErgolavoi = new DataTable();
            var mConnection = new SqlConnection(ConnectionString);

            try
            {
                var mCommand = new SqlCommand()
                {
                    CommandType = CommandType.Text,
                    Connection  = mConnection,
                    CommandText = @"
                        SELECT
                            ErgolavosID,
                            SectorId,
                            ErgCode,
                            ErgName,
                            ErgolavosIsActive
                        FROM
                            Ergolavoi
                        ORDER BY
                            Ergolavoi.SectorId"
                };

                mConnection.Open();

                dtErgolavoi.Load(mCommand.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (Exception /* exception */)
            {
                // TODO: Maybe log exception
            }
            finally
            {
                mConnection.Close();
                mConnection.Dispose();
            }

            // create the list which will hold results from data table
            List<Ergolavoi> ergolavoi = new List<Ergolavoi>();

            // now start processing the data table row by row
            foreach (DataRow dataRow in dtErgolavoi.Rows)
            {
                var ergolavos = new Ergolavoi()
                {
                     ErgolavosID = Convert.ToInt32(dataRow[0]),
                     SectorId = Convert.ToInt32(dataRow[1]),
                     ErgCode = DBNull.Value.Equals(dataRow[2]) ? string.Empty : Convert.ToString(dataRow[2]),
                     ErgName =  DBNull.Value.Equals(dataRow[3]) ? string.Empty : Convert.ToString(dataRow[3]),
                     ErgolavosIsActive = Convert.ToBoolean(dataRow[4])
                };
                ergolavoi.Add(ergolavos);
            }

            return ergolavoi;
        }

        //
        // 09.11.2018, Andreas Kasapleris
        // inserts a record in table Ergolavoi
        //
        public static int AddNewErgolavos(Ergolavoi ergolavos)
        {
            if (ergolavos == null)
            {
                throw new ArgumentNullException(nameof(ergolavos));
            }

            var mConnection = new SqlConnection(ConnectionString);

            var mSqlCommand1 = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection  = mConnection,
                CommandText = @"(SELECT MAX(ErgolavosID) FROM Ergolavoi)"
            };

            var mSqlCommand2 = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = mConnection,
                CommandText = @"
                    INSERT INTO Ergolavoi (
                        ErgolavosID,
                        SectorId,
                        ErgCode,
                        ErgName,
                        ErgolavosIsActive)
                    VALUES (
                        @ErgolavosID,
                        @SectorId,
                        @ErgCode,
                        @ErgName,
                        @ErgolavosIsActive )"
            };

            mSqlCommand2.Parameters.AddWithValue("@SectorId",          ergolavos.SectorId);
            mSqlCommand2.Parameters.AddWithValue("@ErgCode",           ergolavos.ErgCode);
            mSqlCommand2.Parameters.AddWithValue("@ErgName",           ergolavos.ErgName);
            mSqlCommand2.Parameters.AddWithValue("@ErgolavosIsActive", ergolavos.ErgolavosIsActive);

            try
            {
                mConnection.Open();

                int newErgolavosID = (int)mSqlCommand1.ExecuteScalar();

                mSqlCommand2.Parameters.AddWithValue("@ErgolavosID", newErgolavosID + 1);
                return mSqlCommand2.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Η καταχώρηση ήταν ανεπιτυχής.", exception);
            }
            finally
            {
                mConnection.Close();
                mConnection.Dispose();
            }
        }

        //
        // 09.11.2018, Andreas Kasapleris
        // updates a record of table Ergolavoi
        //
        public static int UpdateErgolavos(Ergolavoi ergolavos)
        {
            if (ergolavos == null)
            {
                throw new ArgumentNullException(nameof(ergolavos));
            }

            var mConnection = new SqlConnection(ConnectionString);
            var mSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection  = mConnection,
                CommandText = @"
                    UPDATE Ergolavoi
                    SET
                        ErgCode           = @ErgCode,
                        ErgName           = @ErgName,
                        ErgolavosIsActive = @ErgolavosIsActive
                    WHERE
                        ErgolavosID       = @ErgolavosID"
            };

            mSqlCommand.Parameters.AddWithValue("@ErgolavosID", ergolavos.ErgolavosID);
            mSqlCommand.Parameters.AddWithValue("@SectorId", ergolavos.SectorId);
            mSqlCommand.Parameters.AddWithValue("@ErgCode", ergolavos.ErgCode);
            mSqlCommand.Parameters.AddWithValue("@ErgName", ergolavos.ErgName);
            mSqlCommand.Parameters.AddWithValue("@ErgolavosIsActive", ergolavos.ErgolavosIsActive);

            try
            {
                mConnection.Open();
                return mSqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Η μεταβολή ήταν ανεπιτυχής.", exception);
            }
            finally
            {
                mConnection.Close();
                mConnection.Dispose();
            }
        }
    } // end of Class ErgolavoiDAL
}