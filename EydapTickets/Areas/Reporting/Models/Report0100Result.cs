using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Areas.Reporting.Models
{
    /// <summary>
    /// This class (model) holds the result rows of Report100.
    /// The result set is returned based on the search criteria
    /// </summary>
    public class Report0100Result
    {
        public int SectorId { get; set; }

        public int DepartmentId { get; set; }

        public string BackEndTabletId { get; set; }

        public int TaskTypeId { get; set; }

        public Guid AssignmentId { get; set; }

        public string BCC_ErgolaviaNeasParoxis { get; set; }

        [Display(Name = "Κωδ.1022")]
        public string ID1022 { get; set; }

        [Display(Name = "Περιοχή")]
        public string Perioxi { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string Street_Name { get; set; }

        [Display(Name = "Οδός 2")]
        public string Odos2 { get; set; }

        [Display(Name = "Αριθμός")]
        public string Street_Number { get; set; }

        [Display(Name = "Περιγραφή Εργασίας")]
        public string Task_Description { get; set; }

        [Display(Name = "Κατάσταση")]
        public string State { get; set; }

        [Display(Name = "Ημ.Ανάθεσης")]
        public DateTime? DateOfAssignment { get; set; }

        [Display(Name = "Εργολάβος")]
        public string ErgName { get; set; }

        [Display(Name = "Ημ.Ολοκλήρωσης")]
        public DateTime? DateOfCompletion { get; set; }

        [Display(Name = "Παρατηρήσεις")]
        public string Remarks { get; set; }
    }
}