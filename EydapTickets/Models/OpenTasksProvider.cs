using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EydapTickets.Models
{
    public static class OpenTasksProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        public static IEnumerable<OpenTask> GetOpenTasks(UsersModel aUser)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlDataReader mReader;
            try
            {
                mConnection.Open();
                var mSqlCommand = new SqlCommand
                {
                    Connection  = mConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetOpenTasks",
                };

                mSqlCommand.Parameters.AddWithValue("@User_id", aUser.UserId);

                mSqlCommand.Connection = mConnection;
                mReader = mSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception /* exception */)
            {
                mConnection.Close();
                mConnection.Dispose();
                yield break;
            }

            if (mReader.HasRows)
            {
                while (mReader.Read())
                {
                    DateTime? mClosingDate = null;

                    if (!mReader.IsDBNull(10))
                    {
                        mClosingDate = mReader.GetDateTime(10);
                    }

                    var mTask = new OpenTask(
                        mReader.GetGuid(0),
                        mReader.IsDBNull(1) ? null : mReader.GetString(1),
                        mReader.IsDBNull(2) ? null : mReader.GetString(2),
                        mReader.IsDBNull(3) ? null : mReader.GetString(3),
                        mReader.GetInt32(4),
                        mReader.IsDBNull(5) ? Guid.Empty : mReader.GetGuid(5),
                        mReader.GetInt32(6),
                        mReader.GetInt32(7),
                        mReader.GetString(8),
                        mReader.GetDateTime(9),
                        mClosingDate,
                        mReader.IsDBNull(11) ? 0  : mReader.GetInt32(11),
                        mReader.IsDBNull(12) ? 0  : mReader.GetInt32(12),
                        mReader.IsDBNull(13) ? "" : mReader.GetString(13),
                        mReader.GetString(14),
                        mReader.GetDateTime(15),
                        mReader.IsDBNull(16) ? null : mReader.GetString(16),
                        mReader.IsDBNull(17) ? null : mReader.GetString(17),
                        mReader.IsDBNull(18) ? null : mReader.GetString(18),
                        mReader.IsDBNull(19) ? null : mReader.GetString(19)
                    );

                    yield return mTask;
                }
            }
            mReader.Close();
            mReader.Dispose();
            mConnection.Close();
        }

        public static void UpdateOpenTask(
            Guid aIncidentId,
            Guid aTaskGuid,
            int aTaskTypeId,
            string aComments,
            string aState,
            DateTime? aClosingDate,
            string aUserName)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            var mSqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateTask"
            };

            mSqlCommand.Parameters.AddWithValue("@TaskId", aTaskGuid);
            mSqlCommand.Parameters.AddWithValue("@LastUserName", aUserName);

            if (aComments == null)
            {
                mSqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@Comments", aComments);
            }

            mSqlCommand.Parameters.AddWithValue("@State", aState);
            mSqlCommand.Parameters.AddWithValue("@TaskTypeId", aTaskTypeId);
            mSqlCommand.Parameters.AddWithValue("@Incident_Id", aIncidentId);

            if (aClosingDate == null)
            {
                mSqlCommand.Parameters.AddWithValue("@ClosingDate", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@ClosingDate", aClosingDate);
            }

            try
            {
                sqlConnection.Open();
                mSqlCommand.ExecuteNonQuery();
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
        }
    }
}