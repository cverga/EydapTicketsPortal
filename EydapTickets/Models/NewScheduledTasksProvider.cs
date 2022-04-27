using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EydapTickets.Models
{
    public static class NewScheduledTasksProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        public static IEnumerable<NewScheduledTask> GetNewScheduledTasks(UsersModel user)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "GetNewScheduledTasks",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@User_id", user.UserId);
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

                    DateTime? mClosingDate = null;

                    if (!dataReader.IsDBNull(10))
                    {
                        mClosingDate = dataReader.GetDateTime(10);
                    }

                    var scheduledTask = new NewScheduledTask(
                        dataReader.GetGuid(0),
                        dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                        dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                        dataReader.IsDBNull(3) ? null : dataReader.GetString(3),
                        dataReader.GetInt32(4),
                        dataReader.IsDBNull(5) ? Guid.Empty : dataReader.GetGuid(5),
                        dataReader.GetInt32(6),
                        dataReader.GetInt32(7),
                        dataReader.GetString(8),
                        dataReader.GetDateTime(9),
                        mClosingDate,
                        dataReader.IsDBNull(11) ? 0 : dataReader.GetInt32(11),
                        dataReader.IsDBNull(12) ? null : dataReader.GetString(12),
                        dataReader.IsDBNull(13) ? null : dataReader.GetString(13),
                        dataReader.IsDBNull(14) ? null : dataReader.GetString(14),
                        dataReader.IsDBNull(15) ? null : dataReader.GetString(15),
                        dataReader.IsDBNull(16) ? null : dataReader.GetString(16),
                        dataReader.IsDBNull(17) ? null : dataReader.GetString(17),
                        dataReader.GetDateTime(18)
                    );

                    yield return scheduledTask;
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        public static void AddNewScheduledTask(NewScheduledTask aNewScheduledTask, string state, UsersModel user)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            var mSqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddNewScheduledTask",
            };

            if (aNewScheduledTask.Perioxi == null)
            {
                mSqlCommand.Parameters.AddWithValue("@Perioxi", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@Perioxi", aNewScheduledTask.Perioxi);
            }

            if (aNewScheduledTask.Municipality == null)
            {
                mSqlCommand.Parameters.AddWithValue("@Municipality", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@Municipality", aNewScheduledTask.Municipality);
            }

            if (aNewScheduledTask.StreetName == null)
            {
                mSqlCommand.Parameters.AddWithValue("@StreetName", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@StreetName", aNewScheduledTask.StreetName);
            }

            if (aNewScheduledTask.StreetNumber == null)
            {
                mSqlCommand.Parameters.AddWithValue("@StreetNumber", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@StreetNumber", aNewScheduledTask.StreetNumber);
            }

            if (aNewScheduledTask.TaxKodikas == null)
            {
                mSqlCommand.Parameters.AddWithValue("@TaxKodikas", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@TaxKodikas", aNewScheduledTask.TaxKodikas);
            }

            if (aNewScheduledTask.Odos2 == null)
            {
                mSqlCommand.Parameters.AddWithValue("@Odos2", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@Odos2", aNewScheduledTask.Odos2);
            }

            // 17.07.2018, a NEWID() is set from Stored Procedure called
            // mSqlCommand.Parameters.AddWithValue("@TaskId", new Guid());

            if (aNewScheduledTask.Comments == null)
            {
                mSqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@Comments", aNewScheduledTask.Comments);
            }

            mSqlCommand.Parameters.AddWithValue("@State", state);

            mSqlCommand.Parameters.AddWithValue("@TaskTypeId", aNewScheduledTask.TaskTypeId);

            // mSqlCommand.Parameters.AddWithValue("@Incident_Id", aNewScheduledTask.IncidentId != null ? aNewScheduledTask.IncidentId : new Guid());

            mSqlCommand.Parameters.AddWithValue("@SectorId",     user.SectorId);

            mSqlCommand.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);

            mSqlCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);

            if (aNewScheduledTask.ClosingDate == null)
            {
                mSqlCommand.Parameters.AddWithValue("@ClosingDate", DBNull.Value);
            }
            else
            {
                mSqlCommand.Parameters.AddWithValue("@ClosingDate", aNewScheduledTask.ClosingDate);
            }

            mSqlCommand.Parameters.AddWithValue("@LastUserName", user.UserName);

            mSqlCommand.Parameters.AddWithValue("@ScheduleDate", aNewScheduledTask.ScheduleDate);

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

        public static void UpdateNewScheduledTask(NewScheduledTask aNewScheduledTask, string userName)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateNewScheduledTask",
            };

            sqlCommand.Parameters.AddWithValue("@TaskId", aNewScheduledTask.TaskId);

            if (aNewScheduledTask.Comments == null)
            {
                sqlCommand.Parameters.AddWithValue("@Comments", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Comments", aNewScheduledTask.Comments);
            }

            sqlCommand.Parameters.AddWithValue("@State", aNewScheduledTask.State);
            sqlCommand.Parameters.AddWithValue("@TaskTypeId", aNewScheduledTask.TaskTypeId);
            // mSqlCommand.Parameters.AddWithValue("@Incident_Id", aNewScheduledTask.IncidentId != null ? aNewScheduledTask.IncidentId : new Guid());

            if (aNewScheduledTask.ClosingDate == null)
            {
                sqlCommand.Parameters.AddWithValue("@ClosingDate", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ClosingDate", aNewScheduledTask.ClosingDate);
            }

            // mSqlCommand.Parameters.AddWithValue("@CreationDate", aNewScheduledTask.CreationDate);

            if (aNewScheduledTask.Perioxi == null)
            {
                sqlCommand.Parameters.AddWithValue("@Perioxi", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Perioxi", aNewScheduledTask.Perioxi);
            }

            if (aNewScheduledTask.Municipality == null)
            {
                sqlCommand.Parameters.AddWithValue("@Municipality", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Municipality", aNewScheduledTask.Municipality);
            }

            if (aNewScheduledTask.StreetName == null)
            {
                sqlCommand.Parameters.AddWithValue("@StreetName", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@StreetName", aNewScheduledTask.StreetName);
            }

            if (aNewScheduledTask.StreetNumber == null)
            {
                sqlCommand.Parameters.AddWithValue("@StreetNumber", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@StreetNumber", aNewScheduledTask.StreetNumber);
            }

            if (aNewScheduledTask.TaxKodikas == null)
            {
                sqlCommand.Parameters.AddWithValue("@TaxKodikas", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@TaxKodikas", aNewScheduledTask.TaxKodikas);
            }

            if (aNewScheduledTask.Odos2 == null)
            {
                sqlCommand.Parameters.AddWithValue("@Odos2", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Odos2", aNewScheduledTask.Odos2);
            }

            sqlCommand.Parameters.AddWithValue("@LastUserName", userName);

            sqlCommand.Parameters.AddWithValue("@ScheduleDate", aNewScheduledTask.ScheduleDate);

            try
            {

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
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