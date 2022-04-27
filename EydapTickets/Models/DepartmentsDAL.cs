using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EydapTickets.Helpers;

namespace EydapTickets.Models
{
    public class DepartmentsDAL
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>
        ///     The connection string that includes the source database name, and other parameters needed to establish the
        ///     initial connection.
        /// </returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        //
        // Creation Date : 25.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : C# method to select records from SQL table Departments
        // Related Tables: Departments (Sectors)
        // Update History: 10.07.2016, column DepertmentCode added
        //

        public static IEnumerable<DepartmentsModel> GetDepartments(int sectorId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                // TODO: Refactor into Stored Procedure
                const string cmdText = @"
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

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@SectorId", sectorId);

                    try
                    {
                        connection.Open();
                        dataTable.Load(command.ExecuteReader());
                    }
                    catch (Exception /* exception */)
                    {
                        // TODO: Maybe handle exception
                    }
                }
            }

            var departments = new List<DepartmentsModel>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                departments.Add(DepartmentFactory(new DataRowAdapter(dataRow)));
            }

            return departments;
        }

        //
        // Creation Date : 09.08.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : C# method to get all records from SQL table Departments
        // Related Tables: Departments
        //
        public static IEnumerable<DepartmentsModel> GetAllDepartments()
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                // TODO: Refactor into Stored Procedure
                const string cmdText = @"
                    SELECT
                        DepartmentId,
                        DepartmentCode,
                        DepartmentName,
                        SectorId,
                        FriendlyName
                    FROM
                        Departments";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;

                    try
                    {
                        connection.Open();
                        dataTable.Load(command.ExecuteReader());
                    }
                    catch (Exception /* exception */)
                    {
                        // TODO: Handle exception
                    }
                }
            }

            var departments = new List<DepartmentsModel>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                departments.Add(DepartmentFactory(new DataRowAdapter(dataRow)));
            }

            return departments;
        }

        //
        // Creation Date : 29.03.2017
        // Created By    : Andreas Kasapleris
        // Purpose       : C# method to get all records from SQL table Departments for a specific user
        // Related Tables: Departments
        //

        public static IEnumerable<DepartmentsModel> GetUserDepartments(UsersModel user)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetUserDepartments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@User_id", user.UserId);
                    command.Parameters.AddWithValue("@User_sector", user.SectorId);

                    try
                    {
                        connection.Open();
                        dataTable.Load(command.ExecuteReader());
                    }
                    catch (Exception /* exception */)
                    {
                        // TODO: Maybe handle exception
                    }
                }
            }

            // create the list which will hold results from data table
            var departments = new List<DepartmentsModel>();

            // now start processing the data table row by row
            foreach (DataRow dataRow in dataTable.Rows)
            {
                departments.Add(DepartmentFactory(new DataRowAdapter(dataRow)));
            }

            return departments;
        }

        //
        // Creation Date : 25.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table Departments
        // Related Tables: Departments
        // Update History: 10.07.2016, field DepertmentCode added
        // Known bugs    : if user enters spaces in department description value is accepted
        //

        public static void InsertDepartment(DepartmentsModel department)
        {
            // 10.07.2016, code to check if department code field is empty
            if (string.IsNullOrEmpty(department.DepartmentCode))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 25.05.2016, code to check if department description field is empty
            if (string.IsNullOrEmpty(department.DepartmentName))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                // TODO: Refactor into Stored Procedure
                const string cmdText = @"
                    INSERT INTO Departments(
                        SectorId,
                        DepartmentCode,
                        DepartmentName,
                        FriendlyName
                    ) VALUES (
                        @SectorId,
                        @DepartmentCode,
                        @DepartmentName,
                        @FriendlyName
                    )";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@SectorId", department.SectorId);
                    command.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                    command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    command.Parameters.AddWithValue("@FriendlyName", department.FriendlyName);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException("Η καταχώρηση νέου Τμήματος ήταν ανεπιτυχής.", exception);
                    }
                }
            }
        }

        //
        // Creation Date : 27.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : update record in SQL Table Departments
        // Related Tables: Departments
        // Update History: 10.07.2016, column DepertmentCode added
        // Known bugs    : if user enters spaces in department description value is accepted
        //

        public static void UpdateDepartment(DepartmentsModel department)
        {
            // 10.07.2016, code to check if department code field is empty
            if (string.IsNullOrEmpty(department.DepartmentCode))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            // 27.05.2016, code to check if department description field is empty
            if (string.IsNullOrEmpty(department.DepartmentName))
            {
                throw new ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                // TODO: Refactor into Stored Procedure
                const string cmdText = @"
                    UPDATE Departments
                    SET
                        SectorId = @SectorId,
                        DepartmentCode = @DepartmentCode,
                        DepartmentName = @DepartmentName,
                        FriendlyName = @FriendlyName
                    WHERE
                        DepartmentID = @DepartmentId";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                    command.Parameters.AddWithValue("@SectorId", department.SectorId);
                    command.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                    command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

                    if (!string.IsNullOrWhiteSpace(department.FriendlyName))
                    {
                        command.Parameters.AddWithValue("@FriendlyName", department.FriendlyName);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FriendlyName", DBNull.Value);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException("Η μεταβολή του Τμήματος ήταν ανεπιτυχής.", exception);
                    }
                }
            }
        }

        private static DepartmentsModel DepartmentFactory(IDataRecord dataRecord)
        {
            return new DepartmentsModel
            {
                DepartmentId = Convert.ToInt32(dataRecord[0]),
                DepartmentCode = Convert.ToString(dataRecord[1]),
                DepartmentName = Convert.ToString(dataRecord[2]),
                SectorId = Convert.ToInt32(dataRecord[3]),
                FriendlyName = Convert.ToString(dataRecord[4])
            };
        }
    }
}