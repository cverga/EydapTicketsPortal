using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EydapTickets.Models
{
    [Table("TaskTypes")]
    public class TaskType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tαυτότητα")]
        public int Id { get; set; } // SQL type : int

        [Display(Name = "Αναγνωριστικό")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Το πεδίο {0} δεν μπορεί να ξεπερνά τους {1} χαρακτήρες.")]
        public string Code { get; set; } // SQL type : nchar(50)

        [Display(Name = "Περιγραφή")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(250, ErrorMessage = "Το πεδίο {0} δεν μπορεί να ξεπερνά τους {1} χαρακτήρες.")]
        public string Description { get; set; } // SQL type : nvarchar(250)

        [Display(Name = "Ενεργός")]
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        public bool IsActive { get; set; } // SQL type : int
    }
}