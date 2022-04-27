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
using System.Diagnostics;

namespace EydapTickets.Models
{
    public static class GenericPrintProvider
    {
        /// <summary>Gets the string used to open a SQL Server database.</summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["sql"].ToString();

        static public DataTable GetAssignmentdetails(Guid? aAssignmentId)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            Guid mGuid = Guid.NewGuid();

            mSqlCommand.CommandText = String.Format("select b.Task_Description, a.* from Visits a, Tasks b where AssignmentId = @AssignmentId and a.Task_Id = b.Task_Id");
            mSqlCommand.CommandType = CommandType.Text;
            mSqlCommand.Parameters.AddWithValue("@AssignmentId", aAssignmentId);
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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
            return mDataTable;
        }


        static public DataTable GetFormConfig(int aTaskTypeId)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            Guid mGuid = Guid.NewGuid();

            mSqlCommand.CommandText = String.Format("select * from GenericPrintForms where FormId = @TaskTypeId");
            mSqlCommand.CommandType = CommandType.Text;
            mSqlCommand.Parameters.AddWithValue("@TaskTypeId", aTaskTypeId);
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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
            return mDataTable;
        }

        static public DataTable GetFieldsDetails(int aTaskTypeId)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = "GetFieldDetails";
            mSqlCommand.CommandType = CommandType.StoredProcedure;
            mSqlCommand.Parameters.AddWithValue("@TaskTypeId", aTaskTypeId);
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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
            return mDataTable;
        }

        static public Dictionary<Guid, FieldConfig> GetConfigForTaskType(int aTaskTypeId)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = "select * from GenericPrintConfigFields where FormId = @TaskTypeId";
            mSqlCommand.CommandType = CommandType.Text;
            mSqlCommand.Parameters.AddWithValue("@TaskTypeId", aTaskTypeId);
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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
            Dictionary<Guid, FieldConfig> mConfigDictionary = new Dictionary<Guid, FieldConfig>();
            DataRow mRow = null;
            for (int n=0; n<mDataTable.Rows.Count;n++)
            {
                mRow = mDataTable.Rows[n];
                mConfigDictionary.Add((Guid)mRow[1], new FieldConfig((int)mRow[0], (Guid)mRow[1], (bool)mRow[2], (bool)mRow[3]));
            }

            return mConfigDictionary;
        }


        public static Dictionary<string, string> GetFieldsDefinitions()
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = String.Format("select FieldId, InternalName, NameLocale1, NameLocale9  from CategoriesFields where Entity = 'Visits'");
            mSqlCommand.CommandType = CommandType.Text;
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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

            Dictionary<string, string> mDic = new Dictionary<string, string>();
            DataRow mRow = null;
            for (int n=0;n< mDataTable.Rows.Count;n++)
            {
                mRow = mDataTable.Rows[n];
                mDic[mRow["InternalName"].ToString()] = mRow["NameLocale1"].ToString();
            }

            return mDic;
        }

        public static Dictionary<string, string> ExecuteDBQuery(string aQuery)
        {
            var mConnection = new SqlConnection(ConnectionString);
            SqlCommand mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mConnection;
            mSqlCommand.CommandText = aQuery;
            mSqlCommand.CommandType = CommandType.Text;
            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mSqlCommand.ExecuteReader());
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

            Dictionary<string, string> mDictionary = new Dictionary<string, string>();
            DataRow mRow = null;
            for (int n = 0; n < mDataTable.Rows.Count; n++)
            {
                mRow = mDataTable.Rows[n];
                mDictionary[mRow[0].ToString()] = mRow[1].ToString();
            }
            return mDictionary;
        }
    }

    public class FieldConfig
    {
        public int FormId { get; set; }
        public Guid FieldId { get; set; }
        public bool CoversAllRow { get; set; }
        public bool IsGroup { get; set; }

        public FieldConfig()
        {}
        public FieldConfig(int aFormId, Guid aFiledId, bool aCoversRow, bool aIsGroup)
        {
            FormId = aFormId;
            FieldId = aFiledId;
            CoversAllRow = aCoversRow;
            IsGroup = aIsGroup;
        }
    }

    public class NameValue
    {
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public string DataSource { get; set; }

        public NameValue(Guid aFieldId, string aName, object aValue, string aDataSource)
        {
            FieldId = aFieldId;
            Name = aName;
            Value = aValue;
            DataSource = aDataSource;
            if (!String.IsNullOrEmpty(aDataSource))
            {
                Debug.WriteLine(aDataSource);
            }
        }
        public NameValue(string aName, object aValue)
        {
            Name = aName;
            Value = aValue;
        }
    }

    public class GenericFormModuleNameValue
    {
        public List<NameValue> mList { get; set; }
        public Dictionary<Guid, FieldConfig> mListFieldConfig { get; set; }
        public int ColumnCount { get; set; }
        public GenericFormModuleNameValue()
        { }

        public GenericFormModuleNameValue(List<NameValue> aList, Dictionary<Guid, FieldConfig> aFieldConfig, int Columns = 1)
        {
            mList = aList;
            mListFieldConfig = aFieldConfig;
            ColumnCount = Columns;
        }
    }
}