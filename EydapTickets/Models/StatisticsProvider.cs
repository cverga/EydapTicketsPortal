using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Web.Mvc;
using System.Text;
using EydapTickets.Utils;
using EydapTickets.Models;
using System.Globalization;


namespace EydapTickets
{
    public static class StatisticsProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        public static BasicStatisticsModel Report(string aMunicipality, string aStreetName, string aStreetNumber, string aFromDate, string aToDate, string aReport, string aSector)
        {
            DataTable mData = null;
            var mConnection = new SqlConnection(ConnectionString);
            try
            {
                mConnection.Open();
                CultureInfo aFormat = new CultureInfo("el-GR");
                SqlCommand mCommand = new SqlCommand();
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.CommandText = aReport;
                mCommand.Parameters.AddWithValue("@FromDate", DateTime.Parse(aFromDate, aFormat));
                mCommand.Parameters.AddWithValue("@ToDate", DateTime.Parse(aToDate, aFormat));

                if (String.IsNullOrEmpty(aMunicipality))
                {
                    mCommand.Parameters.AddWithValue("@Municipality",System.DBNull.Value);
                }
                else
                {
                    mCommand.Parameters.AddWithValue("@Municipality", aMunicipality);
                }
                if (String.IsNullOrEmpty(aStreetName))
                {
                    mCommand.Parameters.AddWithValue("@StreetName", System.DBNull.Value);
                }
                else
                {
                    mCommand.Parameters.AddWithValue("@StreetName", aStreetName);
                }
                if (String.IsNullOrEmpty(aStreetNumber))
                {
                    mCommand.Parameters.AddWithValue("@StreetNumber", System.DBNull.Value);
                }
                else
                {
                    mCommand.Parameters.AddWithValue("@StreetNumber", aStreetNumber);
                }
                mCommand.Parameters.AddWithValue("@SectorId", aSector);


                mCommand.Connection = mConnection;
                mData = new DataTable();
                mData.Load(mCommand.ExecuteReader());
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

            DataColumnCollection mCollection = mData.Columns;
            List<string> mDescriptions = new List<string>();
            for (int n=0; n<mCollection.Count;n++)
            {
                string caption = mCollection[n].Caption;
                string columnname = mCollection[n].ColumnName;
                mDescriptions.Add(mCollection[n].Caption);
            }

            int columnCount = mDescriptions.Count;
            DataRow mRow = null;
            List<BasciValuesModel> mBasciValuesModelList = new List<BasciValuesModel>();
            for (int n=0; n<mData.Rows.Count;n++)
            {
                mRow = mData.Rows[n];
                BasciValuesModel mBasciValuesModel = null;
                switch (columnCount)
                {
                    case 1:
                        mBasciValuesModel = new BasciValuesModel(mRow[0].ToString(), null, null, null, null);
                        break;
                    case 2:
                        mBasciValuesModel = new BasciValuesModel(mRow[0].ToString(), mRow[1].ToString(), null, null, null);
                        break;
                    case 3:
                        mBasciValuesModel = new BasciValuesModel(mRow[0].ToString(), mRow[1].ToString(), mRow[2].ToString(), null, null);
                        break;
                    case 4:
                        mBasciValuesModel = new BasciValuesModel(mRow[0].ToString(), mRow[1].ToString(), mRow[2].ToString(), mRow[3].ToString(), null);
                        break;
                    case 5:
                        mBasciValuesModel = new BasciValuesModel(mRow[0].ToString(), mRow[1].ToString(), mRow[2].ToString(), mRow[3].ToString(), mRow[4].ToString());
                        break;
                }
                mBasciValuesModelList.Add(mBasciValuesModel);
            }

            BasicStatisticsModel mBasicStatisticsModel = new BasicStatisticsModel(mDescriptions, mBasciValuesModelList);
            return mBasicStatisticsModel;
        }
    }
}