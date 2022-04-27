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
    
    public partial class Fields
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fields()
        {
            this.CategoriesFields = new HashSet<CategoriesFields>();
            this.CategoriesFieldsPerApplicationRole = new HashSet<CategoriesFieldsPerApplicationRole>();
            this.CategoriesFieldsPerTaskType = new HashSet<CategoriesFieldsPerTaskType>();
        }
    
        public System.Guid Id { get; set; }
        public string Entity { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int Size { get; set; }
        public bool Nullable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriesFields> CategoriesFields { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriesFieldsPerApplicationRole> CategoriesFieldsPerApplicationRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriesFieldsPerTaskType> CategoriesFieldsPerTaskType { get; set; }
    }
}
