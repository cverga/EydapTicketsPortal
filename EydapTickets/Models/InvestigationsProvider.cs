using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EydapTickets.Models
{
    public static class InvestigationsProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        public static IEnumerable<Investigation> GetInvestigations(int sectorId, int departmentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = @"
                        SELECT
                            InvestigationsId,
                            FakelosId,
                            Fakelos_Municipality,
                            Fakelos_Odos,
                            Fakelos_Perioxi,
                            Fakelos_Arithmos,
                            CreationDate,
                            ID1022,
                            SectorId,
                            DepartmentId
                        FROM
                            Investigations
                        WHERE
                            SectorId = @SectorId
                            AND DepartmentId = @DepartmentId
                        ORDER BY CreationDate DESC"

                };

                sqlCommand.Parameters.AddWithValue("@SectorId", sectorId);
                sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

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
                    var investigation = new Investigation(
                        dataReader.GetGuid(0),
                        dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                        dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                        dataReader.IsDBNull(3) ? null : dataReader.GetString(3),
                        dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                        dataReader.IsDBNull(5) ? null : dataReader.GetString(5),
                        dataReader.GetDateTime(6),
                        dataReader.IsDBNull(7) ? null : dataReader.GetString(7),
                        dataReader.GetInt32(8), dataReader.GetInt32(9)
                    );
                    yield return investigation;
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        // Change, 18.05.2017, Andreas Kasapleris
        // updating SectorId and DepartmentId for each Investigation
        public static void UpdateInvestigation(Investigation investigation, int sectorId, int departmentId)
        {
            // SectorId and DepartmentId are passed ...
            // in case of future use ... for the moment do not
            // update table Investigations

            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = @"
                    UPDATE Investigations
                    SET
                        Fakelos_Municipality = @Fakelos_Municipality,
                        Fakelos_Odos = @Fakelos_Odos,
                        Fakelos_Arithmos = @Fakelos_Arithmos,
                        ID1022 = @ID1022
                    WHERE
                        InvestigationsId = @InvestigationsId"
            };

            sqlCommand.Parameters.AddWithValue("@Fakelos_Municipality", investigation.Fakelos_Municipality);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Odos", investigation.Fakelos_Odos);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Arithmos", investigation.Fakelos_Arithmos);
            sqlCommand.Parameters.AddWithValue("@ID1022", investigation.ID1022);
            sqlCommand.Parameters.AddWithValue("@InvestigationsId", investigation.InvestigationsId);

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

        // Change, 18.05.2017, Andreas Kasapleris
        // adding SectorId and DepartmentId for each Investigation
        public static void AddInvestigationNew(Investigation investigation, int sectorId, int departmentId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = @"
                    INSERT INTO Investigations (
                        InvestigationsId,
                        FakelosId,
                        Fakelos_Municipality,
                        Fakelos_Odos,
                        Fakelos_Perioxi,
                        Fakelos_Arithmos,
                        CreationDate,
                        ID1022,
                        SectorId,
                        DepartmentId
                    ) VALUES(
                        @InvestigationsId,
                        @FakelosId,
                        @Fakelos_Municipality,
                        @Fakelos_Odos,
                        @Fakelos_Perioxi,
                        @Fakelos_Arithmos,
                        GETDATE(),
                        @ID1022,
                        @SectorId,
                        @DepartmentId
                    )"
            };

            sqlCommand.Parameters.AddWithValue("@InvestigationsId", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@FakelosId", investigation.FakelosId);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Municipality", investigation.Fakelos_Municipality);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Odos", investigation.Fakelos_Odos);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Perioxi", investigation.Fakelos_Perioxi);
            sqlCommand.Parameters.AddWithValue("@Fakelos_Arithmos", investigation.Fakelos_Arithmos);
            sqlCommand.Parameters.AddWithValue("@ID1022", investigation.ID1022);
            sqlCommand.Parameters.AddWithValue("@SectorId", sectorId);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);

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

        public static DataTable GetFileDetails(string uniqueId)
        {
            var dataTable = new DataTable();
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = "SELECT * FROM Files WHERE UniqueId = @UniqueId"
            };

            sqlCommand.Parameters.AddWithValue("@UniqueId", Guid.Parse(uniqueId));

            try
            {
                sqlConnection.Open();
                dataTable.Load(sqlCommand.ExecuteReader());
                sqlConnection.Close();
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

            return dataTable;
        }

        public static IEnumerable<FileAttachment> GetAttachements(string investigationId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM Files WHERE AppFileID = @AppFileID",
            };

            sqlCommand.Parameters.AddWithValue("@AppFileID", investigationId);

            SqlDataReader dataReader;
            try
            {
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
                    //[AppTag],[AppFileID],[FileName],[FileDirectory],[FileSize],[CreationDate]
                    var mFileAttachment = new FileAttachment(
                        dataReader.GetGuid(0).ToString(),
                        dataReader.GetString(1),
                        dataReader.GetGuid(2).ToString(),
                        dataReader.GetString(3),
                        dataReader.GetString(4),
                        dataReader.GetInt32(5).ToString(),
                        dataReader.GetDateTime(6).ToString()
                    );
                    yield return mFileAttachment;
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            sqlConnection.Close();
        }

        public static void InsertNewFile(
            string uniqueId,
            string appFileId,
            string appTag,
            string fileName,
            string fileDirectory,
            int fileSize)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText =
                    "INSERT INTO Files VALUES(@UniqueId, @AppTag, @AppFileID, @FileName, @FileDirectory, @FileSize, @CreationDate)"
            };

            sqlCommand.Parameters.AddWithValue("@UniqueId", Guid.Parse(uniqueId));
            sqlCommand.Parameters.AddWithValue("@AppTag", appTag);
            sqlCommand.Parameters.AddWithValue("@AppFileID", Guid.Parse(appFileId));

            sqlCommand.Parameters.AddWithValue("@FileName", fileName);
            sqlCommand.Parameters.AddWithValue("@FileDirectory", fileDirectory.Substring(fileDirectory.IndexOf("\\")));
            sqlCommand.Parameters.AddWithValue("@FileSize", fileSize);
            sqlCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);

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

        public static void DeleteFile(string uniqueId)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = "DELETE Files WHERE UniqueId = @UniqueId"
            };

            sqlCommand.Parameters.AddWithValue("@UniqueId", uniqueId);
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
    }
}