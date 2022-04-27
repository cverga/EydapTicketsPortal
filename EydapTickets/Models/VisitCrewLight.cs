namespace EydapTickets.Models
{
    public class VisitCrewLight
    {
        public VisitCrewLight()
        {
            // NOOP
        }

        public VisitCrewLight(
            int id,
            string name)
        {
            ID = id;
            VisitCrewName = name;
        }

        public int ID { get; set; }

        public string VisitCrewName { get; set; }
    }
}