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
    
    public partial class vCategoriesHierarchy
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> ParentCategoryId { get; set; }
        public Nullable<bool> AllowNew { get; set; }
        public Nullable<bool> AllowView { get; set; }
        public string JSUrl { get; set; }
        public Nullable<int> HierarchyLevel { get; set; }
        public string Parents { get; set; }
        public string FullPath { get; set; }
    }
}
