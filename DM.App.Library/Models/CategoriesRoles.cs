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
    
    public partial class CategoriesRoles
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ApplicationRoleId { get; set; }
        public int RoleId { get; set; }
        public int StageLevel { get; set; }
        public int SortOrder { get; set; }
        public Nullable<int> CategoryConfigId { get; set; }
        public int RowStatus { get; set; }
        public System.DateTime RowInserted { get; set; }
        public System.DateTime RowLastUpdated { get; set; }
    
        public virtual Categories Categories { get; set; }
    }
}
