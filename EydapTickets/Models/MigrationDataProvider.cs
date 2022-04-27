using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;
using DataRecordExtensions;
using EydapTickets.Helpers;

namespace EydapTickets.Models
{
    public class MigrationDataProvider
    {
        public static IEnumerable<SelectListItem> GetSectors()
        {
            yield return new SelectListItem() { Text = "TΟΜΕΑΣ ΑΘΗΝΩΝ", Value = "1" };
            yield return new SelectListItem() { Text = "ΤΟΜΕΑΣ ΠΕΙΡΑΙΑ", Value = "2" };
            yield return new SelectListItem() { Text = "ΤΟΜΕΑΣ ΗΡΑΚΛΕΙΟΥ", Value = "3" };
            yield return new SelectListItem() { Text = "ΥΠΟΤΟΜΕΑΣ ΑΣΠΡΟΠΥΡΓΟΥ", Value = "4" };
        }

        public static IEnumerable<SelectListItem> GetSectorMunicipalities(string sector)
        {
            if (string.IsNullOrEmpty(sector))
            {
                yield break;
            }

            const string commandText = @"
                SELECT DISTINCT(area) FROM BLAB
                UNION
                SELECT ''
                ORDER BY area";

            var connectionString = GetMigrationDbConnectionString(sector);
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    using (var dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader.IsDBNull(0))
                            {
                                continue;
                            }

                            yield return new SelectListItem
                            {
                                Text = dataReader.GetString(0),
                                Value = dataReader.GetString(0)
                            };
                        }
                    }
                }
            }
        }

        public static IEnumerable<SelectListItem> GetSectorMunicipalityStreetNames(string sector, string municipality)
        {
            if (string.IsNullOrEmpty(sector) || string.IsNullOrEmpty(municipality))
            {
                yield break;
            }

            const string commandText = @"
                SELECT DISTINCT(street) FROM BLAB WHERE area = @municipality
                UNION
                SELECT ''
                ORDER BY street";

            var connectionString = GetMigrationDbConnectionString(sector);
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@municipality", municipality);

                    connection.Open();
                    using (var dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader.IsDBNull(0))
                            {
                                continue;
                            }

                            yield return new SelectListItem
                            {
                                Text = dataReader.GetString(0),
                                Value = dataReader.GetString(0)
                            };
                        }
                    }
                }
            }
        }

        public static IEnumerable<MigrationResultsModel> GetMigrationData(
            string sector,
            string municipality,
            string streetName,
            string streetNumber,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(sector))
            {
                yield break;
            }

            const string commandText = @"
                SELECT *
                FROM (
                    SELECT
                        codikos,
                        code_1202,
                        yphr,
                        tmhma,
                        dhmos,
                        area,
                        street,
                        street2,
                        arith,
                        kod_sysx,
                        (CASE
                            WHEN timec IS NULL THEN xdate
                            ELSE xdate + CAST(timec AS time)
                        END) AS date_reported
                    FROM
                        BLAB
                ) i
                WHERE
                    1 = 1
                    AND i.date_reported >= @dateFrom
                    AND i.date_reported <= @dateTo";

            var connectionString = GetMigrationDbConnectionString(sector);
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@dateFrom", dateFrom?.StartOfDay() ?? DateTime.MinValue);
                    command.Parameters.AddWithValue("@dateTo", dateTo?.EndOfDay() ?? DateTime.MaxValue);

                    if (!string.IsNullOrWhiteSpace(municipality)) {
                        command.CommandText += " AND i.area = @municipality";
                        command.Parameters.AddWithValue("@municipality", municipality);
                    }

                    if (!string.IsNullOrWhiteSpace(streetName)) {
                        command.CommandText += " AND i.street = @streetName";
                        command.Parameters.AddWithValue("@streetName", streetName);
                    }

                    if (!string.IsNullOrWhiteSpace(streetNumber)) {
                        command.CommandText += " AND i.arith = @streetNumber";
                        command.Parameters.AddWithValue("@streetNumber", streetNumber);
                    }

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return MigrationResultsModelFactory(dataReader);
                        }
                    }
                }
            }
        }

        public static MigrationPopupDetailsModel GetMigrationRowDetails(string sector, string code)
        {
            if (string.IsNullOrEmpty(sector) || string.IsNullOrEmpty(code))
            {
                return null;
            }

            MigrationPopupDetailsModel model = null;

            const string commandText = @"
                SELECT
                    codikos,
                    case
                        when timec is null then xdate
                        else xdate + CAST(timec as time)
                    end as date_notification,
                    case
                        when timea is null then xdateapo
                        else xdateapo + CAST(timea as time)
                    end as date_disconnect,
                    case
                        when timee is null then xdatepan
                        else xdatepan + CAST(timee as time)
                    end as date_reconnect,
                    blab,
                    way,
                    pointbl,
                    note1,
                    note2,
                    eidos_blabhs,
                    zone,
                    idiotiko,
                    idcod1,
                    idcod2,
                    f1202
                FROM
                    BLAB
                WHERE
                    1 = 1
                    AND codikos = @codikos";

            var connectionString = GetMigrationDbConnectionString(sector);
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@codikos", code);

                    connection.Open();
                    using (var dataReader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                    {
                        while (dataReader.Read())
                        {
                            model = MigrationPopupDetailsModelFactory(dataReader);
                            break;
                        }
                    }
                }
            }

            return model;
        }

        private static MigrationResultsModel MigrationResultsModelFactory(IDataRecord dataRecord)
        {
            if (dataRecord == null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var model = new MigrationResultsModel(
                dataRecord.GetString(0),
                dataRecord.GetNullableString(1, string.Empty),
                dataRecord.GetNullableString(2, string.Empty),
                dataRecord.GetNullableString(3, string.Empty),
                dataRecord.GetNullableString(4, string.Empty),
                dataRecord.GetNullableString(5, string.Empty),
                dataRecord.GetNullableString(6, string.Empty),
                dataRecord.GetNullableString(7, string.Empty),
                dataRecord.GetNullableString(8, string.Empty),
                dataRecord.GetNullableString(9, string.Empty),
                dataRecord.GetDateTime(10)
            );

            return model;
        }

        private static MigrationPopupDetailsModel MigrationPopupDetailsModelFactory(IDataRecord dataRecord)
        {
            if (dataRecord == null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var model = new MigrationPopupDetailsModel()
            {
                Code = dataRecord.GetNullableString(0, string.Empty),
                NotificationDate = dataRecord.GetNullableDateTime(1),
                DisconnectionDate = dataRecord.GetNullableDateTime(2),
                ReconnectionDate = dataRecord.GetNullableDateTime(3),
                mBlab = dataRecord.GetNullableString(4, string.Empty),
                mWay = dataRecord.GetNullableString(5, string.Empty),
                mPointbl = dataRecord.GetNullableString(6, string.Empty),
                mNote1 = dataRecord.GetNullableString(7, string.Empty),
                mNote2 = dataRecord.GetNullableString(8, string.Empty),
                mEidos_Blabhs = dataRecord.GetNullableString(9, string.Empty),
                mZone = dataRecord.GetNullableString(10, string.Empty),
                mIdiotiko = Convert.ToBoolean(dataRecord.GetNullableInt16(11, 0)),
                mIdCod1 = dataRecord.GetNullableString(12, string.Empty),
                mIdCod2 = dataRecord.GetNullableString(13, string.Empty),
                mF1202 = dataRecord.GetNullableString(14, string.Empty),
            };

            return model;
        }

        private static string GetMigrationDbConnectionString(string sector)
        {
            string connectionStringName;

            switch (Convert.ToInt32(sector))
            {
                case 1:
                    connectionStringName = "BLABES_ATH";
                    break;

                case 2:
                    connectionStringName = "BLABES_PEIR";
                    break;

                case 3:
                    connectionStringName = "BLABES_HRA";
                    break;

                case 4:
                    connectionStringName = "BLABES_ASP";
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(sector));
            }

            return ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
        }
    }
}