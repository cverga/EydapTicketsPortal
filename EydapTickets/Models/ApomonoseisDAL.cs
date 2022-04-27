using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;              // C#, ADO.NET class definitions, added, Andreas Kasapleris, 05.12.2017
using System.Data.SqlClient;    // added, Andreas Kasapleris, 05.12.2017
using System.Configuration;     // added, Andreas Kasapleris, 19.09.2017

namespace EydapTickets.Models
{
    public class ApomonoseisDAL
    {
        public ApomonoseisDAL()
        {
            // constructor commands
        }

        public static IEnumerable<object> getApomonoseis(string filterParameters)
        {
            // if 'filterParameters' is empty
            // return an empty object
            if (String.IsNullOrEmpty(filterParameters))
            {
                return new List<object>();
            }

            string IncidentId = filterParameters;

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

            string sqlSelect = " SELECT AssignmentId As AssignmentId, " +
                               " (CONVERT(NVARCHAR(24), Visits.DateOfAssignment, 103) + ' - ' + Visits.Task_Description + ' - ' + Visits.Comments) AS DisplayText " +
                               " FROM Visits WHERE TaskTypeId = 1046 AND Incident_Id = @IncidentId ";

            SqlCommand mCommand = new SqlCommand();
            mCommand.Connection = mConnection;
            mCommand.CommandType = CommandType.Text;
            mCommand.CommandText = sqlSelect;
            // SQL Query parameters
            mCommand.Parameters.AddWithValue("@IncidentId", IncidentId);

            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mCommand.ExecuteReader());
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                throw e;
            }

            var d = from c in mDataTable.AsEnumerable()
                    select new
                    {
                        Id          = c.Field<System.Guid>("AssignmentId").ToString(),
                        DisplayText = c.Field<System.String>("DisplayText")
                    };

            return d;
        }

        public static int CopyApomonosiToEpanafora(string ApomonosiAssignmentId, string EpanaforaAssignmentId)
        {
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());

            int success = -1;

            try
            {
                mConnection.Open();
                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.CommandText = "CopyApomonosiToEpanafora";
                mCommand.Connection = mConnection;

                //mCommand.Parameters.AddWithValue("@ApomonosiAssignmentId", Guid.Parse(ApomonosiAssignmentId));
                //mCommand.Parameters.AddWithValue("@EpanaforaAssignmentId", Guid.Parse(EpanaforaAssignmentId));

                mCommand.Parameters.AddWithValue("@ApomonosiAssignmentId", ApomonosiAssignmentId);
                mCommand.Parameters.AddWithValue("@EpanaforaAssignmentId", EpanaforaAssignmentId);

                mCommand.ExecuteScalar();
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                throw e;
            }
            return success;
        }

    }
}