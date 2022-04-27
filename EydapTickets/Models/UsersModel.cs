using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EydapTickets.Models
{
    [Table("Users")]
    public class UsersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Κωδικός")]
        public int UserId { get; set; }           // SQL type : int

        [Display(Name = "Όνομα Χρήστη")]
        [Required(ErrorMessage="Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string UserName { get; set; }     // SQL type : nvarchar(50)

        [Display(Name = "Όνομα")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string Name { get; set; }     // SQL type : nvarchar(50)

        [Display(Name = "Επώνυμο")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string SurName { get; set; } // SQL type : nvarchar(50)

        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int SectorId { get; set; } // SQL type : int

        [Display(Name = "ΑΜ")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Παρακαλώ καταχωρήστε αποδεκτή τιμή.")]
        public int AM { get; set; }     // SQL type : int

        [Display(Name = "Τμήμα")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int DepartmentId   { get; set; }     // SQL type : int

        [Display(Name = "Ρόλος")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int RoleId { get; set; }     // SQL type : int

        [Display(Name = "Email")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
         ErrorMessage = "Παρακαλώ καταχωρήστε μια αποδεκτή διεύθυνση ηλεκτρονικού ταχυδρομείου.")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }     // SQL type : nvarchar(50)

        [Display(Name = "Ενεργός")]
        public int IsActive { get; set; }     // SQL type : int

        [Display(Name = "BCC")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string UserNameBCC { get; set; }

        // 12.05.2017, Andreas Kasapleris
        // will be used to control user access to Investigations
        // in db is defined as 'bit' type
        [Display(Name = "Πραγματογνωμοσύνες")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public bool AccessToInvestigations { get; set; }

        // UsersModel constructor method
        public UsersModel()
        {
            // initializations
        }

        public string GetUsersDepartmentName()
        {
            return IncidentProvider.GetDepartmentName(DepartmentId);
        }

        public string GetUsersSectorName()
        {
            return IncidentProvider.GetSectorName(SectorId);
        }

        public enum UserRole
        {
            Administrator = 1,
            Router = 2,
            Dataentry = 3,
            Sectorviewer  = 4,
            Superviewer = 5,
            Viewer = 6

            /*
                1	Διαχειριστής Συστήματος
                2	Δρομολογητής
                3	Χειριστής Δεδομένων
                4	SectorViewer
                5	SuperViewer
                6	Viewer
             */
        }

        public UserRole Role
        {
            private set { }

            get
            {
                //TODO: Incase integers are not ok, make a comparison using strings
                UserRole lRole = (UserRole)RoleId;

                return lRole;
            }
        }
    }
}