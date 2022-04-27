using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // 23.05.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations; // 23.05.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 23.05.2016, SQL Server; need to add this
//using System.Web.Mvc;
//using System.Web.Security;

namespace EydapTickets.Models
{
    [Table("Departments")]
    public class DepartmentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Κωδικός")]
        public int DepartmentId { get; set; } // SQL type : int

        // 10.07.2016, field added
        [Display(Name = "Αναγνωριστικό")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string DepartmentCode { get; set; } // SQL type : nvarchar(50)

        [Display(Name = "Ονομασία")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string DepartmentName { get; set; } // SQL type : nvarchar(128)

        [Display(Name = "Φιλική Ονομασία")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string FriendlyName { get; set; } // SQL type : nvarchar(128)

        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int SectorId { get; set; } // SQL type : int
    }
}