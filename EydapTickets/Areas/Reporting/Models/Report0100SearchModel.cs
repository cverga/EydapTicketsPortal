using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Areas.Reporting.Models
{
    /// <summary>
    /// This class (model) holds the search criteria for
    /// Report100 - Κατάσταση Αναθέσεων σε Εργολάβους
    /// </summary>
    public class Report0100SearchModel
    {
        [Display(Name = "Από Ανάθεση")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Έως Ανάθεση")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Κατάσταση")]
        public int Status { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        [Display(Name = "Τύπος Εργασίας")]
        public string TaskType { get; set; }

        [Display(Name = "Κατάσταση Εργασίας")]
        public string TaskState { get; set; }

        public int DepartmentId { get; set; }

        public int SectorId { get; set; }

        [Display(Name = "Εργολάβος")]
        public string Contractor { get; set; }

        public IList<Report0100Result> Results { get; set; } = new List<Report0100Result>();
    }
}