using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EydapTickets.Models
{
    // TODO: Consolidate with Ergolavos class
    [Table("Ergolavoi")]
    public class Ergolavoi
    {
        [Key]
        [Display(Name = "Κωδικός")]
        public int ErgolavosID { get; set; } // SQL type : int

        [Display(Name = "Τομέας")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα των Τομέων.")]
        public int SectorId { get; set; } // SQL type : int

        [Display(Name = "Αναγνωριστικό")]
        [MaxLength(25, ErrorMessage = "Μέγιστος πλήθος χαρακτήρων: 25")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public string ErgCode { get; set; } // SQL type : nvarchar(25)

        [Display(Name = "Ονομασία")]
        [MaxLength(50, ErrorMessage = "Μέγιστος πλήθος χαρακτήρων: 50")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public string ErgName { get; set; } // SQL type : nvarchar(50)

        [Display(Name = "Ενεργός")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public bool ErgolavosIsActive { get; set; } // SQL type : bit
    }
}