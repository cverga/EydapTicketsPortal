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
    
    public partial class Personnel
    {
        public int PersonnelID { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelSurName { get; set; }
        public int PersonnelType { get; set; }
        public int PersonnelAM { get; set; }
        public int PersonnelSectorId { get; set; }
        public int PersonnelDepartmentID { get; set; }
        public bool IsActive { get; set; }
    }
}