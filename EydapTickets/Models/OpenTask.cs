using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    // 10.07.2018, Andreas Kasapleris
    // OpenTask Class, an extended version of 'Task' Class
    public class OpenTask
    {
        [Display(Name = "Κλειδί")]
        public Guid TaskId { get; set; }

        [Display(Name = "Κωδικός 1022")]
        public string ID1022 { get; set; }

        [Display(Name = "Ημερομηνία Αναγγελίας")]
        public DateTime HmerominiaAnagelias { get; set; }

        [Display(Name = "Περιοχή")]
        public string Perioxi { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        [Display(Name = "Περιγραφή Εργασίας")]
        public string TaskDescription { get; set; }

        [Display(Name = "Εργασία")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int TaskTypeId { get; set; }

        [Display(Name = "Σχόλια")]
        public string Comments { get; set; }

        [Display(Name = "Κατάσταση")]
        public string State { get; set; }

        [Display(Name = "Περιστατικό")]
        public Guid IncidentId { get; set; }

        [Display(Name = "Τομέας")]
        public int SectorId { get; set; }

        [Display(Name = "Τμήμα")]
        public int DepartmentId { get; set; }

        [Display(Name = "Όνομα Τμήματος")]
        public string DepartmentName { get; set; }

        [Display(Name = "Ημερομηνία Δημιουργιας")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Ημερομηνία Ολοκλήρωσης")]
        public DateTime? ClosingDate { get; set; }

        // 04.04.2017, Andreas Kasapleris, update of this model
        // holds the number of existing Visits found
        // in SQL database for a Task
        [Display(Name = "Αριθμός Αναθέσεων")]
        public int NrOfVisitsForTask { get; set; }

        // 24.04.2017, Andreas Kasapleris
        // κατά την αυτόματη δημιουργία του Task μέσα
        // από την δρομολόγηση του Ticket στο Συντήρησης/Βλαβών
        [Display(Name = "Propagated")]
        public int? Propagated { get; set; }

        // 24.04.2017, Andreas Kasapleris
        // κατά την αυτόματη δημιουργία του Task μέσα
        // από την δρομολόγηση του Ticket στο Συντήρησης/Βλαβών
        // κρατά το Incident ID που δημιουργήθηκε στην
        // εφαρμογή BackEnd έπειτα από δρομολόγηση της Βλάβης
        [Display(Name = "Κλειδί Ταμπλέτας")]
        public string BackEndTabletId { get; set; }

        public OpenTask()
        {
            TaskId = Guid.NewGuid();
        }

        public OpenTask(
            Guid id,
            string aTaskDescription,
            string aComments,
            string aState,
            int aTaskTypeId,
            Guid aIncidentID,
            int aSectorId,
            int aDepartmentId,
            string aDepartmentDescription,
            DateTime aCreationDate,
            DateTime? aClosingDate,
            int aNrOfVisitsForTask,
            int aPropagated,
            string aBackEndTabletId,
            string aID1022,
            DateTime aHmerominiaAnagelias,
            string aPerioxi,
            string aMunicipality,
            string aStreetName,
            string aStreetNumber)
        {
            TaskId = id;
            TaskDescription = aTaskDescription;
            Comments = aComments;
            State = aState;
            TaskTypeId = aTaskTypeId;
            IncidentId = aIncidentID;
            SectorId = aSectorId;
            DepartmentId = aDepartmentId;
            DepartmentName = aDepartmentDescription;
            CreationDate = aCreationDate;
            ClosingDate = aClosingDate;
            NrOfVisitsForTask = aNrOfVisitsForTask;
            Propagated = aPropagated;
            BackEndTabletId = aBackEndTabletId;
            ID1022 = aID1022;
            HmerominiaAnagelias = aHmerominiaAnagelias;
            Perioxi = aPerioxi;
            Municipality = aMunicipality;
            StreetName = aStreetName;
            StreetNumber = aStreetNumber;
        }
    }
}