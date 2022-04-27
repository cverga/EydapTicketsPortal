using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleRegNumber { get; set; }
        public string VehicleType { get; set; }
        public bool IsEydap { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurName { get; set; }
    }
}



