using System;
using System.Collections.Generic;
//using System.Data.Entity; // 30.05.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations; // // 30.05.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 30.05.2016, SQL Server; need to add this
using System.Linq;
using System.Web;

namespace SharedEntities
{
    // 30.05.2016, Andreas Kasapleris
    // Data Model, Class to represent SQL Table : Users
    // also set the model's attributes to the model's properties to
    // ensure required fields, validations etc.
    //

    public class UsersModel
    {
        public int UserId { get; set; }           // SQL type : int

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να καταχωρήσετε τιμή.")]
        [StringLength(50, ErrorMessage = "Η περιγραφή πρέπει να είναι έως 50 χαρακτήρες.")]
        public string UserName { get; set; }     // SQL type : nvarchar(50)

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να εισάγετε τον όνομα του χρήστη.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να εισάγετε τον επώνυμο του χρήστη.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να εισάγετε τον αριθμό μητώου του χρήστη.")]
        public string RegisterNumber { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int SectorId { get; set; }     // SQL type : int

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int DepartmentId { get; set; }     // SQL type : int

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο. Πρέπει να επιλέξετε τιμή από την λίστα.")]
        public int RoleId { get; set; }     // SQL type : int

        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
         ErrorMessage = "Παρακαλώ καταχωρήστε μια αποδεκτή διεύθυνση ηλεκτρονικού ταχυδρομείου.")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }     // SQL type : nvarchar(50)

        public int IsActive { get; set; }     // SQL type : int

        // UsersModel constructor method
        public UsersModel()
        {
            // initializations
        }

        //
        // constructor method to set data
        // to your model's properties
        //
        public UsersModel(int aUserId, string aUserName, string aFirstName, string aLastName, string aRegisterNumber,
                          int aSectorId, int aDepartmentId, int aRoleId,
                          string aUserEmail, int aIsActive)
        {
            UserId = aUserId;
            UserName = aUserName;
            FirstName = aFirstName;
            LastName = aLastName;
            RegisterNumber = aRegisterNumber;
            SectorId = aSectorId;
            DepartmentId = aDepartmentId;
            RoleId = aRoleId;
            UserEmail = aUserEmail;
            IsActive = aIsActive;
        }
    }


}
