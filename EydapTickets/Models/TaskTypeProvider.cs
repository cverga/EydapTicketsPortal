using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;    // 08.06.2016, added manually
using System.Data;           // 08.06.2016, added manually
using System.Data.Common;    // 08.06.2016, added manually
using System.Data.SqlClient; // 08.06.2016, added manually
using System.Data.SqlTypes;  // 08.06.2016, added manually
using System.Configuration;  // 08.06.2016, added manually

namespace EydapTickets.Models
{
    public class TaskTypeProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        //
        // Creation Date : 08.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table TaskTypes
        // Related Tables: TaskTypes
        // Update History:
        //

        public static IEnumerable<TaskType> GetAllTaskTypes()
        {
            SqlDataReader dataReader;
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                // TODO: Call a stored procedure that gets all task types
                var sqlCommand = new SqlCommand()
                {
                    CommandText = @"
                        SELECT
                            tt.TaskTypeId,
                            tt.TaskCode,
                            tt.TaskDescription,
                            tt.IsActive
                        FROM
                            TaskTypes tt",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection,
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
                    var task = new TaskType()
                    {
                       Id = dataReader.GetInt32(0),
                       Code = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                       Description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                       IsActive = dataReader.GetBoolean(3)
                    };
                    yield return task;
                }
            }

            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        public static IList<TaskType> GetAllTaskTypesForDepartment(int departmentId)
        {
            var dataTable = new DataTable();

            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = @"
                            SELECT
                                tt.TaskTypeId,
                                tt.TaskCode,
                                tt.TaskDescription,
                                tt.IsActive
                            FROM
                                TaskTypes tt
                                JOIN DepartmentsToTasks dt ON dt.TaskId = tt.TaskTypeId
                                JOIN Departments d ON d.DepartmentId = dt.DepartmentId
                            WHERE
                                d.DepartmentId = @DepartmentId
                            ORDER BY
                                tt.TaskDescription",
                        Connection = sqlConnection
                    };

                    sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }
            }
            catch (Exception /* exception */)
            {
                // TODO: Handle exception
            }

            // create the list which will hold results from data table
            var taskTypes = new List<TaskType>();

            // now start processing the data table row by row
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var taskType = new TaskType()
                {
                    Id = Convert.ToInt32(dataRow[0]),
                    Code = Convert.ToString(dataRow[1]),
                    Description = Convert.ToString(dataRow[2]),
                    IsActive = Convert.ToBoolean(dataRow[3])
                };
                taskTypes.Add(taskType);
            }

            return taskTypes;
        }

                //
        // Creation Date : 29.03.2017
        // Created By    : Andreas Kasapleris
        // Modified By   : Andreas Kasapleris
        // Purpose       : C# method to get all records from SQL table TaskTypes a specific department can execute
        // Related Tables: TaskTypes, DepartmentsToTasks, Departments
        //

        public static IList<TaskType> GetActiveTaskTypesForDepartment(int departmentId)
        {
            var dataTable = new DataTable();

            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = @"
                            SELECT
                                tt.TaskTypeId,
                                tt.TaskCode,
                                tt.TaskDescription
                            FROM
                                TaskTypes tt
                                JOIN DepartmentsToTasks dt ON tt.TaskTypeId = dt.TaskId
                                JOIN Departments d ON dt.DepartmentId = d.DepartmentId
                            WHERE
                                tt.IsActive = 1
                                AND dt.IsActive = 1
                                AND d.DepartmentId = @DepartmentId
                            ORDER BY
                                tt.TaskDescription",
                        Connection = sqlConnection
                    };

                    sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }
            }
            catch (Exception /* exception */)
            {
               // TODO: Handle exception
            }

            // create the list which will hold results from data table
            var taskTypes = new List<TaskType>();

            // now start processing the data table row by row
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var taskType = new TaskType()
                {
                    Id = Convert.ToInt32(dataRow[0]),
                    Code = Convert.ToString(dataRow[1]),
                    Description = Convert.ToString(dataRow[2]),
                    IsActive = true
                };
                taskTypes.Add(taskType);
            }

            return taskTypes;
        }

        public static IEnumerable<TaskType> GetAllTaskTypesForUser(UsersModel user)
        {
            SqlDataReader dataReader;
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                // TODO: Call a stored procedure that gets the task types according to the users department and role
                sqlConnection.Open();

                var sqlCommand = new SqlCommand
                {
                    CommandText = "SELECT tt.TaskTypeId, tt.TaskCode, tt.TaskCode + '-' + tt.TaskDescription, tt.IsActive FROM TaskTypes tt WHERE 1=1",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection
                };

                if (user.RoleId == 1)
                {
                    sqlCommand.CommandText = " AND tt.TaskTypeId IN (SELECT dt.TaskId FROM DepartmentsToTasks dt)";
                }
                else
                {
                    sqlCommand.CommandText = " AND tt.TaskTypeId IN (SELECT dt.TaskId FROM DepartmentsToTasks dt WHERE dt.DepartmentId = @DepartmentId)";
                    sqlCommand.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                }

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
                    var mTask = new TaskType()
                    {
                        Id = dataReader.GetInt32(0),
                        Code = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                        Description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                        IsActive = dataReader.GetBoolean(3)
                    };
                    yield return mTask;
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        //
        // Creation Date : 08.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table TaskTypes
        // Related Tables: TaskTypes
        // Update History:
        // Known bugs    : if user enters spaces in Task Code or Task Description value
        //                 is accepted
        //

        public static void InsertTaskType(TaskType taskType)
        {
            // 08.06.2016, code to check if Task Code field is empty
            if (string.IsNullOrEmpty(taskType.Code))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 08.06.2016, code to check if Task Description field is empty
            if (string.IsNullOrEmpty(taskType.Description))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                // TODO: Call a stored procedure that creates the task type
                var sqlCommand = new SqlCommand
                {
                    CommandText = "INSERT INTO TaskTypes VALUES (@Code, @Description, @IsActive)",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection,
                };

                sqlCommand.Parameters.AddWithValue("@Code", taskType.Code);
                sqlCommand.Parameters.AddWithValue("@Description", taskType.Description);
                sqlCommand.Parameters.AddWithValue("@IsActive", taskType.IsActive);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new ApplicationException("Η προσθήκη του Τύπου Εργασίας ήταν ανεπιτυχής.", exception);
                }
            }
        }

        //
        // Creation Date : 08.06.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : update record in SQL Table AvailableTasks
        // Related Tables: AvailableTasks
        // Update History:
        // Known bugs    : if user enters spaces in Task Code or Task Description value
        //                 is accepted
        //

        public static void UpdateTaskType(TaskType taskType)
        {
            // 08.06.2016, code to check if Task Code field is empty
            if (string.IsNullOrEmpty(taskType.Code))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 08.06.2016, code to check if Task Description field is empty
            if (string.IsNullOrEmpty(taskType.Description))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                // TODO: Call a stored procedure that updates the task type
                var sqlCommand = new SqlCommand
                {
                    CommandText = @"
                        UPDATE TaskTypes
                        SET
                            TaskCode        = @Code,
                            TaskDescription = @Description,
                            IsActive        = @IsActive
                        WHERE
                            TaskTypeId =  @Id",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection,
                };

                sqlCommand.Parameters.AddWithValue("@Id", taskType.Id);
                sqlCommand.Parameters.AddWithValue("@Code", taskType.Code);
                sqlCommand.Parameters.AddWithValue("@Description", taskType.Description);
                sqlCommand.Parameters.AddWithValue("@IsActive", taskType.IsActive);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new ApplicationException("Η ενημέρωση του Τύπου Εργασίας ήταν ανεπιτυχής.", exception);
                }
            }
        }
    }
}
