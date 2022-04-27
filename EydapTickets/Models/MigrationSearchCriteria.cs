using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class MigrationSearchCriteria
    {
        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public string Sector { get; set; }

        [Display(Name = "Από")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Εώς")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }
    }
}