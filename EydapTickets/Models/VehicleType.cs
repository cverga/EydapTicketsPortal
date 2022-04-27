namespace EydapTickets.Models
{
    public class VehicleType
    {
        public VehicleType()
        {
            // NOOP
        }

        public VehicleType(
            int id,
            string description)
        {
            VehicleTypeID = id;
            VehicleTypeDescription = description;
        }

        public int VehicleTypeID { get; set; }

        public string VehicleTypeDescription { get; set; }
    }
}