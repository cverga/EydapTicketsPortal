namespace EydapTickets.Models
{
    public class ReportType
    {
        public ReportType()
        {
            // NOOP
        }

        public ReportType(
            int id,
            string description,
            string storedProcedure)
        {
            ReportID = id;
            ReportDescription = description;
            StoredProcedure = storedProcedure;
        }

        public int ReportID { get; set; }

        public string ReportDescription { get; set; }

        public string StoredProcedure { get; set; }
    }
}