using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class DepartmentsToTasksModel
    {
        public DepartmentsToTasksModel()
        {
            // NOOP
        }

        public DepartmentsToTasksModel(
            Guid id,
            int sectorId,
            int departmentId,
            int taskId,
            int isActive)
        {
            ID = id;
            DDTSectorID = sectorId;
            DDTDepartmentID = departmentId;
            DDTTaskId = taskId;
            DDTIsActive = isActive;
        }

        [Key]
        [Display(Name = "Κωδικός")]
        public Guid ID { get; set; }

        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int DDTSectorID { get; set; }

        [Display(Name = "Τμήμα")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int DDTDepartmentID { get; set; }

        [Display(Name = "Εργασία")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int DDTTaskId { get; set; }

        [Display(Name = "Ενεργή" )]
        public int DDTIsActive { get; set; }
    }
}