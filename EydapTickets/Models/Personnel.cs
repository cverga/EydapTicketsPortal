using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class Personnel
    {
        public Personnel()
        {
            // NOOP
        }

        public Personnel(
            int id,
            string name,
            string surname,
            int personnelTypeId,
            int personnelAM,
            int sectorId,
            int departmentId,
            bool isActive)
        {
            PersonnelID = id;
            PersonnelName = name;
            PersonnelSurName = surname;
            PersonnelType = personnelTypeId;
            PersonnelAM = personnelAM;
            PersonnelSectorId = sectorId;
            PersonnelDepartmentID = departmentId;
            IsActive = isActive;
        }

        [Key]
        [Display(Name = "Κωδικός")]
        public int PersonnelID { get; set; }

        [Display(Name = "Όνομα")]
        public string PersonnelName { get; set; }

        [Display(Name = "Επώνυμο")]
        public string PersonnelSurName { get; set; }

        [Display(Name = "Ειδικότητα")]
        public int PersonnelType { get; set; }

        [Display(Name = "Αρ.Μητρώου")]
        public int PersonnelAM { get; set; }

        [Display(Name = "Τομέας")]
        public int PersonnelSectorId { get; set; }

        [Display(Name = "Τμήμα")]
        public int PersonnelDepartmentID { get; set; }

        [Display(Name = "Ενεργός")]
        public bool IsActive { get; set; }
    }
}