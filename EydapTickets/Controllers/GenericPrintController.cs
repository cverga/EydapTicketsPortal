using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Controllers
{
    public class GenericPrintController : Controller
    {
        // GET: GenericPrint
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPrint(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DataTable mTableAssignments = GenericPrintProvider.GetAssignmentdetails(id);
            DataTable mTableFields = GenericPrintProvider.GetFieldsDetails((int)mTableAssignments.Rows[0]["TaskTypeId"]);

            Dictionary<string, string> mdictionary = GenericPrintProvider.GetFieldsDefinitions();

            List<NameValue> mList = new List<NameValue>();
            DataRow mRow = null;
            for (int n=0; n < mTableFields.Rows.Count;n++)
            {
                mRow = mTableFields.Rows[n];
                NameValue mNameValue = new NameValue(mdictionary[mRow["InternalName"].ToString()], mTableAssignments.Rows[0][mRow["InternalName"].ToString()]);
                mList.Add(mNameValue);
            }

            return PartialView("GetPrintView", mList);
        }

        public ActionResult GetPrintNew(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<NameValue> mList = new List<NameValue>();
            DataTable mTableAssignments = GenericPrintProvider.GetAssignmentdetails(id);   // here are the columns an their values..... 1 row from Visits

            DataTable mTableFields = null;
            DataTable mTableFormConfig = null;
            Dictionary<Guid, FieldConfig> mGenericPrintConfig = null;


            if (mTableAssignments.Rows.Count == 1)
            {
                mTableFields = GenericPrintProvider.GetFieldsDetails((int)mTableAssignments.Rows[0]["TaskTypeId"]); // Mainly DATASOURCES get the details of the fileds related to visits.....
                mTableFormConfig = GenericPrintProvider.GetFormConfig((int)mTableAssignments.Rows[0]["TaskTypeId"]);
                mGenericPrintConfig = GenericPrintProvider.GetConfigForTaskType((int)mTableAssignments.Rows[0]["TaskTypeId"]);

                DataRow mRow = null;

                for (int n = 0; n < mTableFields.Rows.Count; n++)
                {
                    bool datasource = false;
                    Dictionary<string, string> mDictionary = null;
                    mRow = mTableFields.Rows[n];
                    if (mRow["DataSourceTypeName"].ToString() == "DBQuery")
                    {
                        mDictionary = GenericPrintProvider.ExecuteDBQuery(mRow["DS2"].ToString().Substring(0, mRow["DS2"].ToString().IndexOf("WHERE")));
                        datasource = true;
                    }

                    string mFiledValue = null;
                    if (datasource)
                    {
                        string fieldname = mRow["InternalName"].ToString();
                        string fieldvalue = mTableAssignments.Rows[0][fieldname].ToString();
                        if (!String.IsNullOrEmpty(fieldvalue) && fieldvalue != "-1")
                        {
                            if (fieldvalue.Contains(","))
                            {
                                string[] mvalues = fieldvalue.Split(new char[1] { ',' });
                                for (int t = 0; t < mvalues.Length; t++)
                                {
                                    mFiledValue = mFiledValue + mDictionary[mvalues[t]] + ",";
                                }
                                mFiledValue = mFiledValue.Remove(mFiledValue.LastIndexOf(","), 1);
                            }
                            else
                            {
                                mFiledValue = mDictionary[fieldvalue];
                            }
                        }
                        else
                        {
                            mFiledValue = "";
                        }
                    }
                    else
                    {
                        try
                        {
                            var fieldKey = mRow["InternalName"].ToString();
                            mFiledValue = mTableAssignments.Rows[0][fieldKey].ToString();
                        }
                        catch (Exception /** exception **/)
                        {
                            mFiledValue = "";
                        }
                    }

                    NameValue mNameValue = new NameValue((Guid)mRow["FieldId"], mRow["NameLocale1"].ToString(), mFiledValue, mRow["DS2"].ToString());

                    if (mNameValue.Value != null)
                    {
                        if (mNameValue.Value.ToString().Trim() == "-1")
                        {
                            mNameValue.Value = "";
                        }
                    }

                    mList.Add(mNameValue);
                }
            }
            GenericFormModuleNameValue mGenericFormModuleNameValue;

            if (mGenericPrintConfig == null)
            {
                mGenericPrintConfig = new Dictionary<Guid, FieldConfig>();
            }

            if (mTableFormConfig.Rows.Count != 0)
            {
                mGenericFormModuleNameValue = new GenericFormModuleNameValue(mList, mGenericPrintConfig, (int)mTableFormConfig.Rows[0][1]);
            }
            else
            {
                mGenericFormModuleNameValue = new GenericFormModuleNameValue(mList, mGenericPrintConfig);
            }

            return PartialView("GetPrintNewView", mGenericFormModuleNameValue);
        }
    }
}