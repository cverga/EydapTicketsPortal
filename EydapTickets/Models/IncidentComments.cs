using System;

namespace EydapTickets.Models
{
    public class IncidentComments
    {
        public Guid IncidentId { get; set; }
        public string Comment { get; set; }

        public IncidentComments(Guid aIncidentId, string aComment)
        {
            IncidentId = aIncidentId;
            Comment = aComment;
        }
    }
}