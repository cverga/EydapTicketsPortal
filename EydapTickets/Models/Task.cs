using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Web.Mvc;
using EydapTickets.Helpers;

namespace EydapTickets.Models
{
    public class Task
    {
        public Task()
        {
            TaskId = Guid.NewGuid();
        }

        public Task(
            Guid id,
            string description,
            string comments,
            string state,
            int taskTypeId,
            Guid incidentId,
            int sectorId,
            int departmentId,
            string departmentName,
            DateTime creationDate,
            DateTime? closingDate,
            int assignmentCount,
            int propagated,
            string backEndTabletId)
        {
            TaskId = id;
            TaskDescription = description;
            Comments = comments;
            State = state;
            TaskTypeId = taskTypeId;
            IncidentId = incidentId;
            SectorId = sectorId;
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            CreationDate = creationDate;
            ClosingDate = closingDate;
            NrOfVisitsForTask = assignmentCount;
            Propagated = propagated;
            BackEndTabletId = backEndTabletId;
        }

        public Guid TaskId { get; set; }

        public string Municipality { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        public int TaskTypeId { get; set; }

        public string Comments { get; set; }

        public string State { get; set; }

        public Guid IncidentId { get; set; }

        public int SectorId { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        public DateTime CreationDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        // 04.04.2017, Andreas Kasapleris, update of this model
        // holds the number of existing Visits found
        // in SQL database for a Task
        public int NrOfVisitsForTask { get; set; }

        // 24.04.2017, Andreas Kasapleris
        // κατά την αυτόματη δημιουργία του Task μέσα
        // από την δρομολόγηση του Ticket στο Συντήρησης/Βλαβών
        public int? Propagated { get; set; }

        // 24.04.2017, Andreas Kasapleris
        // κατά την αυτόματη δημιουργία του Task μέσα
        // από την δρομολόγηση του Ticket στο Συντήρησης/Βλαβών
        // κρατά το Incident ID που δημιουργήθηκε στην
        // εφαρμογή BackEnd έπειτα από δρομολόγηση της Βλάβης
        public string BackEndTabletId { get; set; }
    }
}