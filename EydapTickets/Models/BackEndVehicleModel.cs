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
    // The Class here is called BackEndVehicle just for avoiding conflicts
	// between classes defined in Portal DDY application
	//
    public class BackEndVehicle
    {
        public int VehicleID { get; set; }
        public string VehicleRegNumber { get; set; }
        public string VehicleType { get; set; }
        public bool IsEydap { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurName { get; set; }
    }
}