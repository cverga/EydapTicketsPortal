using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections; // 17.05.2016, added manually
using System.Data; // 17.05.2016, added manually
using System.Data.Common; // 17.05.2016, added manually
using System.Data.SqlClient; // 17.05.2016, added manually
using System.Data.SqlTypes; // 17.05.2016, added manually
using System.Configuration; // 17.05.2016, added manually

namespace EydapTickets.Models // 17.05.2016, added manually
{
    public static class RolesDAL
    {
        public static IEnumerable<RolesModel> GetRoles()
        {
            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlDataReader mReader = null;
            try
            {
                mConnection.Open();
                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.Text;
                mCommand.CommandText = "SELECT * FROM ROLES";
                mCommand.Connection = mConnection;
                mReader = mCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                yield break;
            }
            if (mReader != null)
            {
                if (mReader.HasRows)
                {
                    while (mReader.Read())
                    {
                        RolesModel role = new RolesModel()
                        {
                            RoleId = mReader.GetInt32(0),
                            RoleDescription = mReader.IsDBNull(1) ? string.Empty : mReader.GetString(1)
                        };
                        yield return role;
                    }
                    mReader.Close();
                    mReader.Dispose();
                    mConnection.Close();
                }
                else
                {
                    mReader.Close();
                    mReader.Dispose();
                    mConnection.Close();
                }
            }
            yield break;
        }

        //
        // Creation Date : 13.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : Create/Insert a new record in SQL Table Roles
        // Related Tables: Roles
        // Update History:
        // 23.05.2016, code to check if role description field is empty
        // Known bugs    : if user enters spaces in role description value is accepted
        //

        public static void InsertRole(RolesModel aRole)
        {
            // 23.05.2016, code to check if role description field is empty
            if (String.IsNullOrEmpty(aRole.RoleDescription))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = String.Format("INSERT INTO ROLES VALUES( '{0}' )",
                                      aRole.RoleDescription);
            try
            {
                mConnection.Open();
                mSqlCommand.ExecuteNonQuery();
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                // 20.05.2016; throw only original exception message
                // throw e;

                // 20.05.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η καταχώρηση νέου Ρόλου ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }

        }

        //
        // Creation Date : 19.05.2016
        // Created By    : Andreas Kasapleris
        // Purpose       : update record in SQL Table Roles
        // Related Tables: Roles
        // Update History:
        // 23.05.2016, code to check if role description field is empty
        // Known bugs    : if user enters spaces in role description value is accepted

        public static void UpdateRole(RolesModel aRole)
        {
            // 23.05.2016, code to check if role description field is empty
            if (String.IsNullOrEmpty(aRole.RoleDescription))
            {
                throw new System.ApplicationException("Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.");
            }

            SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ToString());
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = String.Format("UPDATE ROLES SET RoleDescription = '{1}' WHERE RoleId = {0}",
                                      aRole.RoleId, aRole.RoleDescription);
            try
            {
                mConnection.Open();
                mSqlCommand.ExecuteNonQuery();
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                // 20.05.2016; throw only original exception message
                // throw e;

                // 20.05.2016; otherwise throw your exception message
                throw new System.ApplicationException("Η μεταβολή του Ρόλου ήταν ανεπιτυχής." + "\n" +
                      "Μήνυμα SQL:" + e.Message);
            }
        }

    }
}