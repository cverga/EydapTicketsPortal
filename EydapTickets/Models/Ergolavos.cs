namespace EydapTickets.Models
{
    public class Ergolavos
    {
        public Ergolavos()
        {
            // NOOP
        }

        public Ergolavos(
            int id,
            string name)
        {
            ErgolavosId = id;
            ErgName = name;
        }

        public int ErgolavosId { get; set; }

        public string ErgName { get; set; }
    }
}