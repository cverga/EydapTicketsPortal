using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DM.App.Library.Models
{
    public partial class Fields : Interfaces.IField
    {

    }

    public partial class CategoriesFields : Interfaces.ICategoryField
    {
        private IEnumerable<Models.Interfaces.IField> _fieldsDefinitions = null;
        public IEnumerable<Models.Interfaces.IField> FieldsDefinitions
        {
            get
            {
                if (_fieldsDefinitions == null)
                {
                    // Get fields from DB
                    _fieldsDefinitions = ExternalDB.GetFields();
                }

                return _fieldsDefinitions;
            }
            set
            {
                _fieldsDefinitions = value;
            }
        }

        public string GetTitle()
        {
            return (string.IsNullOrEmpty(this.NameLocale1) ? this.InternalName : this.NameLocale1);
        }

        public string GetTitle(int localeId)
        {
            return (string.IsNullOrEmpty(this.NameLocale1) ? this.InternalName : this.NameLocale1);
        }

        public IEnumerable<Models.Interfaces.ILookupItemDTO> GetLookupKVPs()
        {
            IEnumerable<Models.DTO.LookupItem> results = ExternalDB.GetLookupKVPs(this.DataSource);
            return results;
        }
    }
}