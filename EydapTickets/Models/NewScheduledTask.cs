using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class NewScheduledTask
    {
        public NewScheduledTask()
        {
            TaskId = Guid.NewGuid();
        }

        public NewScheduledTask(
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
            string perioxi,
            string municipality,
            string streetName,
            string streetNumber,
            string taxKodikas,
            string odos2,
            DateTime scheduleDate)
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
            Perioxi = perioxi;
            Municipality = municipality;
            StreetName = streetName;
            StreetNumber = streetNumber;
            TaxKodikas = taxKodikas;
            Odos2 = odos2;
            ScheduleDate = scheduleDate;
        }

        public Guid TaskId { get; set; }

        public string Perioxi { get; set; }

        public string Municipality { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string TaxKodikas { get; set; }

        public string Odos2 { get; set; }

        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int TaskTypeId { get; set; }

        public string Comments { get; set; }

        public string State { get; set; }

        public Guid IncidentId { get; set; }

        public int SectorId { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public DateTime ScheduleDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        // 04.04.2017, Andreas Kasapleris, update of this model
        // holds the number of existing Visits found
        // in SQL database for a Task
        public int NrOfVisitsForTask { get; set; }
    }
}