using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DM.App.Library.Models
{
    public partial class Tasks
    {
        public Core.Enums.FormStates FormState { get; set; }

        protected IEnumerable<Models.Interfaces.ICategoryField> _fieldsConfiguration = null;

        public int CategoryId { get; set; }
        public Core.GenericUser CurrentUser { get; set; }

        public IEnumerable<Models.Interfaces.ICategoryField> FieldsConfiguration
        {
            get
            {
                if (_fieldsConfiguration == null)
                {
                    // Get fields configuration from DB
                    _fieldsConfiguration = ExternalDB.GetCategoriesFields(this.CategoryId, ExternalDB.EntityTask);

                    if (_fieldsConfiguration.Count() > 0)
                    {
                        IEnumerable<CategoriesFieldsPerTaskType> categoriesFieldsPerTaskType = ExternalDB.GetCategoriesFieldsPerTaskType(_fieldsConfiguration.First().CategoryId, ExternalDB.EntityTask, this.TaskTypeId);
                        if (categoriesFieldsPerTaskType.Count() > 0)
                        {
                            foreach (CategoriesFieldsPerTaskType item in categoriesFieldsPerTaskType)
                            {
                                Models.Interfaces.ICategoryField tempCategoryField = _fieldsConfiguration.Where(e => e.FieldId == item.FieldId).FirstOrDefault();
                                if (tempCategoryField != null)
                                {
                                    tempCategoryField.FieldStateInEditForm = item.FieldStateInEditForm;
                                    tempCategoryField.FieldStateInNewForm = item.FieldStateInNewForm;
                                    tempCategoryField.FieldStateInViewForm = item.FieldStateInViewForm;

                                    tempCategoryField.SortOrder = item.SortOrder;
                                    tempCategoryField.LayoutOrder = item.LayoutOrder;
                                    tempCategoryField.LayoutGroupId = item.LayoutGroupId;
                                    tempCategoryField.LayoutTabId = item.LayoutTabId;

                                    if (!string.IsNullOrEmpty(item.ControlTypeInEditForm))
                                        tempCategoryField.ControlTypeInEditForm = item.ControlTypeInEditForm;
                                    if (!string.IsNullOrEmpty(item.ControlTypeInNewForm))
                                        tempCategoryField.ControlTypeInNewForm = item.ControlTypeInNewForm;
                                    if (!string.IsNullOrEmpty(item.ControlTypeInViewForm))
                                        tempCategoryField.ControlTypeInViewForm = item.ControlTypeInViewForm;

                                    tempCategoryField.IsMandatoryInEditForm = item.IsMandatoryInEditForm;
                                    tempCategoryField.IsMandatoryInNewForm = item.IsMandatoryInNewForm;

                                    if (!string.IsNullOrEmpty(item.NameLocale1))
                                        tempCategoryField.NameLocale1 = item.NameLocale1;
                                    if (!string.IsNullOrEmpty(item.NameLocale2))
                                        tempCategoryField.NameLocale2 = item.NameLocale2;
                                    if (!string.IsNullOrEmpty(item.NameLocale3))
                                        tempCategoryField.NameLocale3 = item.NameLocale3;
                                    if (!string.IsNullOrEmpty(item.NameLocale4))
                                        tempCategoryField.NameLocale4 = item.NameLocale4;
                                    if (!string.IsNullOrEmpty(item.NameLocale5))
                                        tempCategoryField.NameLocale5 = item.NameLocale5;
                                    if (!string.IsNullOrEmpty(item.NameLocale6))
                                        tempCategoryField.NameLocale6 = item.NameLocale6;
                                    if (!string.IsNullOrEmpty(item.NameLocale7))
                                        tempCategoryField.NameLocale7 = item.NameLocale7;
                                    if (!string.IsNullOrEmpty(item.NameLocale8))
                                        tempCategoryField.NameLocale8 = item.NameLocale8;
                                    if (!string.IsNullOrEmpty(item.NameLocale9))
                                        tempCategoryField.NameLocale9 = item.NameLocale9;

                                    if (!string.IsNullOrEmpty(item.AllowedValues))
                                        tempCategoryField.AllowedValues = item.AllowedValues;
                                    if (!string.IsNullOrEmpty(item.DefaultValue))
                                        tempCategoryField.DefaultValue = item.DefaultValue;

                                    if (!string.IsNullOrEmpty(item.ValidationJSScript))
                                        tempCategoryField.ValidationJSScript = item.ValidationJSScript;
                                    if (!string.IsNullOrEmpty(item.ValidationServerSide))
                                        tempCategoryField.ValidationServerSide = item.ValidationServerSide;
                                    if (!string.IsNullOrEmpty(item.ValidationWSUrl))
                                        tempCategoryField.ValidationWSUrl = item.ValidationWSUrl;
                                    if (!string.IsNullOrEmpty(item.DocumentReadyJSScript))
                                        tempCategoryField.DocumentReadyJSScript = item.DocumentReadyJSScript;

                                    if (item.DataSourceTypeId.HasValue)
                                        tempCategoryField.DataSourceTypeId = item.DataSourceTypeId.Value;
                                    if (!string.IsNullOrEmpty(item.DataSource))
                                        tempCategoryField.DataSource = item.DataSource;
                                    if (!string.IsNullOrEmpty(item.FieldExtension1))
                                        tempCategoryField.FieldExtension1 = item.FieldExtension1;
                                    if (!string.IsNullOrEmpty(item.FieldExtension2))
                                        tempCategoryField.FieldExtension2 = item.FieldExtension2;
                                    if (!string.IsNullOrEmpty(item.FieldExtension3))
                                        tempCategoryField.FieldExtension3 = item.FieldExtension3;
                                    if (!string.IsNullOrEmpty(item.FieldExtension4))
                                        tempCategoryField.FieldExtension4 = item.FieldExtension4;
                                    if (!string.IsNullOrEmpty(item.FieldExtension5))
                                        tempCategoryField.FieldExtension5 = item.FieldExtension5;
                                    if (!string.IsNullOrEmpty(item.FieldExtension6))
                                        tempCategoryField.FieldExtension6 = item.FieldExtension6;

                                    if (!string.IsNullOrEmpty(tempCategoryField.DataSource))
                                    {
                                        string token = "[[#USERLOGINNAME#]]";
                                        int pos = tempCategoryField.DataSource.IndexOf(token);
                                        if (pos > -1 && this.CurrentUser != null)
                                        {
                                            tempCategoryField.DataSource = tempCategoryField.DataSource.Replace(token, this.CurrentUser.LoginName);
                                        }
                                    }
                                }
                            }
                        }

                        _fieldsConfiguration = _fieldsConfiguration.OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder).ThenBy(e => e.LayoutGroupId);
                    }
                }

                return _fieldsConfiguration;
            }
            set
            {
                _fieldsConfiguration = value;
            }
        }

        public void PrepareFields(System.Security.Principal.IPrincipal principal)
        {
            this.Task_Id = Guid.NewGuid();
            string loginName = "";
            if (principal != null && principal.Identity != null)
                loginName = principal.Identity.Name;
        }

        public void PrepareFieldsForUpdate(System.Security.Principal.IPrincipal principal)
        {
            //this.UniqueId = Guid.NewGuid();
            string loginName = "";
            if (principal != null && principal.Identity != null)
                loginName = principal.Identity.Name;
            //this.CreatedBy = loginName;
            //this.CreatedByLoginName = loginName;

            //this.RowStatus = 0;
            //this.RowInserted = DateTime.Now;
            //this.RowLastUpdated = DateTime.Now;
            //this.ArchivalStatusMask = 0;

        }

        public void SaveHistoryItem(ExternalDBEntities db, EntityState state)
        {
            if (state == EntityState.Added || state == EntityState.Modified || state == EntityState.Deleted)
            {
                try
                {
                    //TasksHistory entity = new TasksHistory();

                    //entity.HistoryCreated = DateTime.Now;

                    //switch (state)
                    //{
                    //    case EntityState.Added:
                    //        entity.HistoryType = "INSERT";
                    //        break;
                    //    case EntityState.Deleted:
                    //        entity.HistoryType = "DELETED";
                    //        break;
                    //    case EntityState.Modified:
                    //        entity.HistoryType = "UPDATE";
                    //        break;
                    //    default:
                    //        break;
                    //}
                    //App.Library.Core.FieldValidator.AssignValuesCopySimilarTypes(entity, this, true);

                    //db.TasksHistory.Add(entity);
                }
                catch (Exception)
                {
                }
            }
        }

        public void SaveStatusHistoryItem(ExternalDBEntities db, string status, DateTime statusDate)
        {
            if (!string.IsNullOrEmpty(status))
            {
                try
                {
                    //bool addHistoryItem = false;
                    //TasksStatusHistory entityExisting = db.TasksStatusHistory.Where(e => e.RowStatus == 0 && e.UniqueId == this.UniqueId).OrderByDescending(e => e.StatusDate).FirstOrDefault();
                    //if (entityExisting != null)
                    //{
                    //    addHistoryItem = (entityExisting.Status != status);
                    //}
                    //else
                    //    addHistoryItem = true;

                    //if (addHistoryItem)
                    //{
                    //    TasksStatusHistory entity = new TasksStatusHistory();
                    //    entity.RowId = this.RowId;
                    //    entity.UniqueId = this.UniqueId;
                    //    entity.RequestUniqueId = this.RequestUniqueId;
                    //    entity.TaskType = this.TaskType;
                    //    entity.Status = status;
                    //    entity.StatusDate = statusDate;
                    //    entity.RowStatus = 0;
                    //    entity.RowInserted = DateTime.Now;
                    //    entity.RowLastUpdated = DateTime.Now;
                    //    db.TasksStatusHistory.Add(entity);
                    //}
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
