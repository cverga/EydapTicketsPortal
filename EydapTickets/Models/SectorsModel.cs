using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EydapTickets.Models
{
    [Table("Sectors")]
    public class SectorsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description="Κωδικός")]
        public int SectorId { get; set; }

        [Display(Name = "Αναγνωριστικό")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδιό {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string SectorCode { get; set; }

        [Display(Name = "Περιγραφή")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} πρέπει να είναι έως {1} χαρακτήρες.")]
        public string SectorDescription { get; set; }
    }
}