namespace EydapTickets.Models
{
    public class Street
    {
        public Street()
        {
            // NOOP
        }

        public Street(int id, string name)
        {
            StreetID = id;
            StreetName = name;
        }

        public int StreetID { get; set; }

        public string StreetName { get; set; }
    }
}