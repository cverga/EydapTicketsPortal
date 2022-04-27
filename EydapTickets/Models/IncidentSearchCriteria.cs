using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EydapTickets.Models
{
    public class IncidentSearchCriteria
    {
        // Class Property; the UserDepartmentId in which user belongs
        // this property will be set to this 'SearchModel' Class
        // from C# Controller after the instantiation of this Class
        // see Index() action of Controllers\SearchController.cs
        public int DepartmentId { get; set; }

        public int RoleId { get; set;  }

        [Display(Name = "Κωδικός 1022")]
        public string Code1022 { get; set; }

        [Display(Name = "Από")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Εώς")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Κατάσταση")]
        public int Status { get; set; }

        [Display(Name = "Ονοματεπώνυμο Καλούντος")]
        public string CallerFullName { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Περιοχή")]
        public string Perioxi { get; set; }

        [Display(Name = "Οδός 2")]
        public string Odos2 { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        [Display(Name = "Επίθετο πελάτη")]
        public string CustomerSurName { get; set; }

        [Display(Name = "Κατάσταση Εργασίας")]
        public string TaskState { get; set; }

        [Display(Name = "Περιγραφή Εργασίας")]
        public string TaskType { get; set; }

        [Display(Name = "Εμφάνιση αποτελεσμάτων απο όλους τους Τομείς")]
        public bool? ShowCrossSectorResults { get; set; }
    }
}
