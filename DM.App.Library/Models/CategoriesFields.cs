//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DM.App.Library.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoriesFields
    {
        public int CategoryId { get; set; }
        public System.Guid FieldId { get; set; }
        public string Entity { get; set; }
        public int FieldExtensionId { get; set; }
        public string InternalName { get; set; }
        public int FieldStateInNewForm { get; set; }
        public int FieldStateInViewForm { get; set; }
        public int FieldStateInEditForm { get; set; }
        public string ControlTypeInNewForm { get; set; }
        public string ControlTypeInViewForm { get; set; }
        public string ControlTypeInEditForm { get; set; }
        public bool IsMandatoryInNewForm { get; set; }
        public bool IsMandatoryInEditForm { get; set; }
        public int SortOrder { get; set; }
        public int LayoutOrder { get; set; }
        public int LayoutTabId { get; set; }
        public int LayoutGroupId { get; set; }
        public string AllowedValues { get; set; }
        public string DefaultValue { get; set; }
        public string ValidationJSScript { get; set; }
        public string ValidationServerSide { get; set; }
        public string ValidationWSUrl { get; set; }
        public string DocumentReadyJSScript { get; set; }
        public int DataSourceTypeId { get; set; }
        public string DataSource { get; set; }
        public string FieldExtension1 { get; set; }
        public string FieldExtension2 { get; set; }
        public string FieldExtension3 { get; set; }
        public string FieldExtension4 { get; set; }
        public string FieldExtension5 { get; set; }
        public string FieldExtension6 { get; set; }
        public string NameLocale1 { get; set; }
        public string NameLocale2 { get; set; }
        public string NameLocale3 { get; set; }
        public string NameLocale4 { get; set; }
        public string NameLocale5 { get; set; }
        public string NameLocale6 { get; set; }
        public string NameLocale7 { get; set; }
        public string NameLocale8 { get; set; }
        public string NameLocale9 { get; set; }
        public int RowStatus { get; set; }
        public System.DateTime RowInserted { get; set; }
        public System.DateTime RowLastUpdated { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual DataSourceTypes DataSourceTypes { get; set; }
        public virtual Fields Fields { get; set; }
        public virtual FieldStates FieldStates { get; set; }
        public virtual FieldStates FieldStates1 { get; set; }
        public virtual FieldStates FieldStates2 { get; set; }
    }
}
