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
    
    public partial class DataSourceTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataSourceTypes()
        {
            this.CategoriesFields = new HashSet<CategoriesFields>();
        }
    
        public int Id { get; set; }
        public string DataSourceTypeName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriesFields> CategoriesFields { get; set; }
    }
}
