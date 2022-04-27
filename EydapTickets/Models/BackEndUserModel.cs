using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EydapTickets.Models
{
	//
    // 20/04/2017, Andreas Kasapleris
    // has to be same Class definition as in ΕΥΔΑΠ BackEnd Application
    // If you make changes there, you MUST also make changes in this class (model)
    // The Class here is called BackEndUser just for avoiding conflicts
	// between classes defined in Portal DDY application
	//
    public class BackEndUser
    {
        public int UserId { get; set; }          // SQL type : int
        public string UserName { get; set; }     // SQL type : nvarchar(50)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegisterNumber { get; set; }
        public int SectorId { get; set; }     // SQL type : int
        public int DepartmentId { get; set; }     // SQL type : int
        public int RoleId { get; set; }     // SQL type : int
        public string UserEmail { get; set; }     // SQL type : nvarchar(50)
        public int IsActive { get; set; }     // SQL type : int

        // UsersModel constructor method
        public BackEndUser()
        {
            // initializations
        }

        //
        // constructor method to set data
        // to your model's properties
        //
        public BackEndUser(int aUserId, string aUserName, string aFirstName, string aLastName, string aRegisterNumber,
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