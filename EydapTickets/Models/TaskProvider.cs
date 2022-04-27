using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EydapTickets.Models
{
    public class TaskProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        public static Task GetTaskById(Guid taskId)
        {
            if (taskId == null)
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            var cmdText = @"
                SELECT
                    t.Task_Id,
                    t.Task_Description,
                    t.Comments,
                    t.State,
                    t.TaskTypeId,
                    t.Incident_Id,
                    t.SectorId,
                    t.DepartmentId,
                    d.DepartmentName,
                    t.CreationDate,
                    t.ClosingDate,
                    dbo.fn_countVisitsForTaskId(t.Task_Id),
                    t.Propagated,
                    t.BackEndTabletId
                FROM
                    dbo.Tasks t
                    INNER JOIN dbo.Departments d ON d.DepartmentId = t.DepartmentId
                WHERE
                    t.Task_Id = @TaskId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@TaskId", taskId);
                    try
                    {
                        connection.Open();
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    return CreateTask(dataReader);
                                }
                            }
                        }
                    }
                    catch (Exception /* exception */)
                    {
                        // TODO: Handle exception
                        return null;
                    }
                };
            }
            return null;
        }

        public static IEnumerable<Task> GetTasks(Guid incidentId, UsersModel user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetTasks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Incident_Id", incidentId);
                    command.Parameters.AddWithValue("@User_id", user.UserId);

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return CreateTask(dataReader);
                        }
                    }
                }
            }
        }

        public static IEnumerable<Task> GetTasksForCustomerServiceId(string customerServiceId)
        {
            if (customerServiceId == null)
            {
                throw new ArgumentNullException(nameof(customerServiceId));
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetTasksForCustomerServiceId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerServiceId", customerServiceId);

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return CreateTask(dataReader);
                        }
                    }
                }
            }
        }

        private static Task CreateTask(IDataRecord dataRecord)
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
    }
}
