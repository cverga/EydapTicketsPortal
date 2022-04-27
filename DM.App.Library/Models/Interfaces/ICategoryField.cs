using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.Interfaces
{
    public interface ICategoryField
    {
        int CategoryId { get; set; }
        System.Guid FieldId { get; set; }
        string Entity { get; set; }
        int FieldExtensionId { get; set; }
        string InternalName { get; set; }
        int FieldStateInNewForm { get; set; }
        int FieldStateInViewForm { get; set; }
        int FieldStateInEditForm { get; set; }
        string ControlTypeInNewForm { get; set; }
        string ControlTypeInViewForm { get; set; }
        string ControlTypeInEditForm { get; set; }
        bool IsMandatoryInNewForm { get; set; }
        bool IsMandatoryInEditForm { get; set; }
        int SortOrder { get; set; }
        int LayoutOrder { get; set; }
        int LayoutTabId { get; set; }
        int LayoutGroupId { get; set; }
        string AllowedValues { get; set; }
        string DefaultValue { get; set; }
        string ValidationJSScript { get; set; }
        string ValidationWSUrl { get; set; }
        string DocumentReadyJSScript { get; set; }
        int DataSourceTypeId { get; set; }
        string DataSource { get; set; }
        string FieldExtension1 { get; set; }
        string FieldExtension2 { get; set; }
        string FieldExtension3 { get; set; }
        string FieldExtension4 { get; set; }
        string FieldExtension5 { get; set; }
        string FieldExtension6 { get; set; }
        string NameLocale1 { get; set; }
        string NameLocale2 { get; set; }
        string NameLocale3 { get; set; }
        string NameLocale4 { get; set; }
        string NameLocale5 { get; set; }
        string NameLocale6 { get; set; }
        string NameLocale7 { get; set; }
        string NameLocale8 { get; set; }
        string NameLocale9 { get; set; }
        int RowStatus { get; set; }
        System.DateTime RowInserted { get; set; }
        System.DateTime RowLastUpdated { get; set; }
        string ValidationServerSide { get; set; }

        IEnumerable<Models.Interfaces.IField> FieldsDefinitions { get; set; }

        string GetTitle();
        string GetTitle(int localeId);
        IEnumerable<ILookupItemDTO> GetLookupKVPs();
    }
}
