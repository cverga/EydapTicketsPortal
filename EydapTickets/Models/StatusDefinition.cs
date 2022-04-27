namespace EydapTickets.Models
{
    public class StatusDefinition
    {
        public StatusDefinition()
        {
            // NOOP
        }

        public StatusDefinition(
            int id,
            string description)
        {
            StatusId = id;
            StatusDescription = description;
        }

        public int StatusId { get; set; }

        public string StatusDescription { get; set; }
    }
}