using System;
using System.Collections.Generic;
using System.Data.Entity; // 17.05.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations; // 17.05.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 17.05.2016, SQL Server; need to add this
using System.Linq;
using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

namespace EydapTickets.Models
{
    public class RolesContext : DbContext
    {
        public RolesContext()
            : base("DefaultConnection")
        {
        }

        // public System.Data.Entity.DbSet<DX151Admin.Models.RolesModel> RolesModels { get; set; }

    }

    //
    // 17.05.2016, Andreas Kasapleris
    // Data Model, Class to represent SQL Table : Roles
    //

    [Table("Roles")]
    public class RolesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Κωδικός")]
        public int RoleId { get; set; } // SQL type : int

        [Display(Name = "Περιγραφή")]
        [Required(ErrorMessage="Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage="Η περιγραφή πρέπει να είναι έως 50 χαρακτήρες.")]
        public string RoleDescription { get; set; } // SQL type : nvarchar(50)
    }
}