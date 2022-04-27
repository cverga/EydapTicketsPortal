using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DM.App.Library.Models
{
    public partial class Incidents
    {
        public Core.Enums.FormStates FormState { get; set; }

        public bool ShowActionButtons { get; set; }
        protected IEnumerable<Models.Interfaces.ICategoryField> _fieldsConfiguration = null;

        public int CategoryId { get; set; }
        public IEnumerable<Models.Interfaces.ICategoryField> FieldsConfiguration
        {
            get
            {
                if (_fieldsConfiguration == null)
                {
                    // Get fields configuration from DB
                    _fieldsConfiguration = ExternalDB.GetCategoriesFields(this.CategoryId, ExternalDB.EntityIncident);

                    if (_fieldsConfiguration.Count() > 0)
                    { }
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
            this.TT_Id = Guid.NewGuid();
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
