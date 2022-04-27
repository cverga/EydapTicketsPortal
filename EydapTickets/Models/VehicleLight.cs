namespace EydapTickets.Models
{
    public class VehicleLight
    {
        public VehicleLight()
        {
            // NOOP
        }

        public VehicleLight(
            int id,
            string registrationNumber)
        {
            VehicleID = id;
            VehicleRegNumber = registrationNumber;
        }

        public int VehicleID { get; set; }

        public string VehicleRegNumber { get; set; }
    }
}