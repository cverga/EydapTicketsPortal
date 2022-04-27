namespace EydapTickets.Models
{
    public class Municipality
    {
        public Municipality()
        {
            // NOOP
        }

        public Municipality(
            int id,
            string name)
        {
            MunicipalityID = id;
            MunicipalityName = name;
        }

        public int MunicipalityID { get; set; }

        public string MunicipalityName { get; set; }
    }
}