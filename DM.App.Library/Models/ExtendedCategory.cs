using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DM.App.Library.Models
{
    public partial class Categories : Interfaces.ICategory
    {
        public const string ENTITY_NAME = "Categories";
        public Core.Enums.FormStates FormState { get; set; }
        public bool ShowActionButtons { get; set; }
        public bool LockCategories { get; set; }

        protected IEnumerable<Models.Interfaces.ICategoryField> _fieldsConfiguration = null;
        public IEnumerable<Models.Interfaces.ICategoryField> FieldsConfiguration
        {
            get
            {
                if (_fieldsConfiguration == null)
                {
                    // Get fields configuration from DB
                    if (!this.ParentCategoryId.HasValue)
                        this.ParentCategoryId = 0;
                    _fieldsConfiguration = ExternalDB.GetCategoriesFields(this.ParentCategoryId.Value, ENTITY_NAME);
                }
                if (LockCategories)
                {
                    int level = int.MaxValue;
                    IEnumerable<vCategoriesHierarchy> categories = ExternalDB.GetCategories(this.ParentCategoryId);
                    vCategoriesHierarchy category = categories.FirstOrDefault();
                    if (category != null && category.HierarchyLevel.HasValue)
                        level = category.HierarchyLevel.Value;

                    IEnumerable<Models.Interfaces.ICategoryField> fields = _fieldsConfiguration.Where(e => (FormState == Core.Enums.FormStates.New && e.ControlTypeInNewForm == Core.HtmlLibHelper.CONTROL_DROPDOWNLIST) || (FormState == Core.Enums.FormStates.Edit && e.ControlTypeInEditForm == Core.HtmlLibHelper.CONTROL_DROPDOWNLIST));
                    foreach (Models.Interfaces.ICategoryField field in fields)
                    {
                        //if (field.FieldExtensionId < level)
                        {
                            field.FieldStateInEditForm = (int)Core.Enums.FieldStates.Readonly;
                            field.FieldStateInNewForm = (int)Core.Enums.FieldStates.Readonly;
                        }
                    }
                }

                if (this.FormState == Core.Enums.FormStates.New)
                {
                    Core.FieldValidator.SetDefaultValues(this, _fieldsConfiguration);
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
            this.RowStatus = 0;
            this.RowInserted = DateTime.Now;
            this.RowLastUpdated = DateTime.Now;
        }

        public void PrepareFieldsForUpdate(System.Security.Principal.IPrincipal principal)
        {
            //this.UniqueId = Guid.NewGuid();
            string loginName = "";
            if (principal != null && principal.Identity != null)
                loginName = principal.Identity.Name;
            //this.CreatedBy = loginName;
            //this.CreatedByMOSS = loginName;
            //this.CreatedByLoginName = loginName;

            //this.RowStatus = 0;
            //this.RowInserted = DateTime.Now;
            this.RowLastUpdated = DateTime.Now;
            //this.ArchivalStatusMask = 0;

        }

        public static string GetCustomizedCategories(string entity, bool jsonFormat)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<int> ids = ExternalDB.GetCustomizedCategories(entity);

            foreach (int id in ids)
            {
                if (jsonFormat)
                    //sb.AppendFormat("{{\"CategoryId\":{0}}},", id);
                    sb.AppendFormat("{0},", id);
                else
                    sb.AppendFormat("{0},", id);
            }
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            if (jsonFormat)
                sb.Insert(0, "{ \"Entity\":\"CategoryId\", \"Values\":[ ");
            //sb.Insert(0, "\"" + entity + "CategoriesFields\":[");

            if (jsonFormat)
                sb.Append("] }");

            return sb.ToString();
        }

        public static int GetCategoryIdForName(string name)
        {
            int id = -1;

            if (!int.TryParse(name, out id))
            {
                Models.Categories category = Models.ExternalDB.GetCategoryByAlias(name);
                if (category != null)
                    id = category.Id;
            }
            return id;
        }
    }
}