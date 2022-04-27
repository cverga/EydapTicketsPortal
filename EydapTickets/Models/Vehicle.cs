using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            // NOOP
        }

        public Vehicle(
            int id,
            int sectorId,
            int departmentId,
            string registrationNumber,
            int vehicleTypeId,
            bool isEydap,
            string ownerName,
            string ownerSurName)
        {
            VehicleID = id;
            VehicleSector = sectorId;
            VehicleDepartment = departmentId;
            VehicleRegNumber = registrationNumber;
            VehicleType = vehicleTypeId;
            IsEydap = isEydap;
            OwnerName = ownerName;
            OwnerSurName = ownerSurName;
        }

        [Key]
        [Display(Name = "Κωδικός")]
        public int VehicleID { get; set; }

        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int VehicleSector { get; set; }

        [Display(Name = "Τμήμα")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int VehicleDepartment { get; set; }

        [Display(Name = "Αριθμός Κυκλοφορίας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public string VehicleRegNumber { get; set; }

        [Display(Name = "Τύπος")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public int VehicleType { get; set; }

        [Display(Name = "Ιδιοκτησία ΕΥΔΑΠ")]
        public bool IsEydap { get; set; }

        [Display(Name = "Όνομα Ιδιοκτήτη")]
        public string OwnerName { get; set; }

        [Display(Name = "Επώνυμο Ιδιοκτήτη")]
        public string OwnerSurName { get; set; }
    }
}