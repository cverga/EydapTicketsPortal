using System;

namespace EydapTickets.Models
{
    public class VisitEquipment
    {
        public VisitEquipment()
        {
            // NOOP
        }

        public VisitEquipment(
            Guid id,
            Guid visitId,
            string vehicleType,
            string vehicleNumber)
        {
            ID = id;
            VisitID = visitId;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
        }

        public Guid ID { get; set; }

        public Guid VisitID { get; set; }

        public string VehicleType { get; set; }

        public string VehicleNumber { get; set; }
    }
}