using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections; // 30.05.2016, added manually
using System.Data; // 30.05.2016, added manually
using System.Data.Common; // 30.05.2016, added manually
using System.Data.SqlClient; // 30.05.2016, added manually
using System.Data.SqlTypes; // 30.05.2016, added manually
using System.Configuration; // 30.05.2016, added manually
using EydapTickets.Helpers;

namespace EydapTickets.Models
{
    public static class UsersDAL
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        //
        // Creation Date : 30.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table Sectors
        // Related Tables: Sectors
        // Update History:
        //

        public static IEnumerable<SectorsModel> GetSectors()
        {
            var dataTable = new DataTable();

            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = "SELECT SectorId, SectorCode, SectorDescription FROM SECTORS",
                        Connection = sqlConnection
                    };

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }

            }
            catch (Exception /* exception */)
            {
                // TODO: Handle exception
            }

            // create the list which will hold results from data table
            var sectors = new List<SectorsModel>();

            // now start processing the data table row by row
            foreach (DataRow row in dataTable.Rows)
            {
                var sector = new SectorsModel()
                {
                    SectorId = Convert.ToInt32(row[0]),
                    SectorCode = Convert.ToString(row[1]),
                    SectorDescription = Convert.ToString(row[2])
                };
                sectors.Add(sector);
            }

            return sectors;
        }

        //
        // Creation Date : 30.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all Departments for a specific SectorId
        // Related Tables: Departments
        // Update History: 10.07.2016, column DepartmentCode added
        //

        public static IEnumerable<DepartmentsModel> GetDepartmentsForSector(int sectorId, bool isAdminRequest = true)
        {
            var dataTable = new DataTable();

            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        Connection = sqlConnection,
                    };

                    if (isAdminRequest)
                    {
                        sqlCommand.CommandText = @"
                            SELECT
                                DepartmentId,
                                DepartmentCode,
                                DepartmentName,
                                SectorId,
                                FriendlyName
                            FROM
                                Departments
                            WHERE
                                SectorId = @SectorId";
                        sqlCommand.Parameters.AddWithValue("@SectorId", sectorId);
                    }
                    else
                    {
                        if (sectorId == 4 || sectorId == 5 || sectorId == 6 || sectorId == 7)
                        {
                            sqlCommand.CommandText = @"
                                SELECT
                                    DepartmentId,
                                    DepartmentCode,
                                    DepartmentName,
                                    SectorId,
                                    FriendlyName
                                FROM
                                    Departments
                                ORDER BY
                                    SectorId";
                        }
                        else
                        {
                            sqlCommand.CommandText = @"
                                SELECT
                                    DepartmentId,
                                    DepartmentCode,
                                    DepartmentName,
                                    SectorId,
                                    FriendlyName
                                FROM
                                    Departments
                                WHERE
                                    SectorId = @SectorId
                                    OR SectorId in (4,5,6,7,8)";
                            sqlCommand.Parameters.AddWithValue("@SectorId", sectorId);
                        }
                    }

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }
            }
            catch (Exception /* exception */)
            {
                // TODO: Handle exception
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
                    FriendlyName = Convert.ToString(dataRow[4])
                };
                departments.Add(department);
            }

            return departments;
        }

        //
        // Creation Date : 30.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : fetches all records from SQL Table Users
        // Related Tables: Users
        // Update History: 12.05.2017, Andreas Kasapleris, SQL Table field AccessToInvestigations added
        //

        public static IEnumerable<UsersModel> GetUsers()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM USERS",
                    Connection = sqlConnection
                };
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                yield break;
            }

            if (sqlDataReader != null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                    yield return UserFactory(sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlConnection.Close();
                }
                else
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlConnection.Close();
                }
            }
            yield break;
        }

        //
        // Creation Date : 30.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table Users
        // Related Tables: Users
        // Update History: 12.05.2017, Andreas Kasapleris, SQL Table field AccessToInvestigations added
        // Known bugs    : if user enters spaces in user name value is accepted
        //

        public static void InsertUser(UsersModel user)
        {
            // 30.05.2016, code to check if role description field is empty
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            const string cmdText = @"
                    INSERT INTO Users (
                        UserName,
                        SectorId,
                        DepartmentId,
                        RoleId,
                        UserEmail,
                        IsActive,
                        AM,
                        Name,
                        SurName ,
                        UserNameBCC,
                        AccessToInvestigations,
                        Layout
                    ) VALUES (
                        @UserName,
                        @SectorId,
                        @DepartmentId,
                        @RoleId,
                        @UserEmail,
                        @IsActive,
                        @AM,
                        @Name,
                        @SurName,
                        @UserNameBCC,
                        @AccessToInvestigations,
                        null
                    )";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@SectorId", user.SectorId);
                    command.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    command.Parameters.AddWithValue("@AM", user.AM);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@SurName", user.SurName);
                    command.Parameters.AddWithValue("@UserNameBCC", user.UserNameBCC);
                    command.Parameters.AddWithValue("@AccessToInvestigations", user.AccessToInvestigations);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException("Η καταχώρηση νέου χρήστη ήταν ανεπιτυχής.", exception);
                    }
                }
            }
        }

        //
        // Creation Date : 30.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : update record in SQL Table Users
        // Related Tables: Users
        // Update History: 12.05.2017, Andreas Kasapleris, SQL Table field AccessToInvestigations added
        // Known bugs    : if user enters spaces in user name value is accepted

        public static void UpdateUser(UsersModel user)
        {
            // 30.05.2016, code to check if role description field is empty
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            const string cmdText = @"
                    UPDATE Users
                    SET
                        UserName     = @UserName,
                        SectorId     = @SectorId,
                        DepartmentId = @DepartmentId,
                        RoleId       = @RoleId,
                        UserEmail    = @UserEmail,
                        IsActive     = @IsActive,
                        AM           = @AM,
                        Name         = @Name,
                        SurName      = @SurName,
                        UserNameBCC  = @UserNameBCC,
                        AccessToInvestigations = @AccessToInvestigations
                    WHERE
                        UserId = @UserId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@SectorId", user.SectorId);
                    command.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    command.Parameters.AddWithValue("@AM", user.AM);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@SurName", user.SurName);
                    command.Parameters.AddWithValue("@UserNameBCC", user.UserNameBCC);
                    command.Parameters.AddWithValue("@AccessToInvestigations", user.AccessToInvestigations);
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException("Η μεταβολή του χρήστη ήταν ανεπιτυχής.", exception);
                    }
                }
            }
        }

        //
        // Update History: 12.05.2017, Andreas Kasapleris, SQL Table field AccessToInvestigations added
        //

        public static UsersModel GetUserByUserName(string userName)
        {
            var dataTable = new DataTable("user");

            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    var sqlCommand = new SqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "SELECT * FROM Users WHERE UserName = @UserName"
                    };

                    sqlCommand.Parameters.AddWithValue("@UserName", userName);

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }
            }
            catch (Exception /* exception */)
            {
                // TODO: Handle exception
            }

            UsersModel user = null;

            if (dataTable.Rows.Count != 0)
            {
                user = UserFactory(new DataRowAdapter(dataTable.Rows[0]));
            }

            return user;
        }

        private static UsersModel UserFactory(IDataRecord dataRecord)
        {
            return new UsersModel()
            {
                UserId = dataRecord.GetInt32(0),
                UserName =  dataRecord.IsDBNull(1) ? null : dataRecord.GetString(1),
                SectorId = dataRecord.GetInt32(2),
                DepartmentId = dataRecord.GetInt32(3),
                RoleId = dataRecord.GetInt32(4),
                UserEmail = dataRecord.IsDBNull(5) ? null : dataRecord.GetString(5),
                IsActive = dataRecord.GetInt32(6),
                AM = dataRecord.GetInt32(7),
                Name =dataRecord.IsDBNull(8) ? null : dataRecord.GetString(8),
                SurName = dataRecord.IsDBNull(9) ? null : dataRecord.GetString(9),
                UserNameBCC = dataRecord.IsDBNull(10) ? null : dataRecord.GetString(10),
                AccessToInvestigations = dataRecord.GetBoolean(11)
            };
        }
    }
}