using System;

namespace EydapTickets.Models
{
    public class VisitCrew
    {
        public VisitCrew()
        {
            // NOOP
        }

        public VisitCrew(
            Guid id,
            Guid visitId,
            string name,
            string surname,
            int registryNumber)
        {
            ID = id;
            VisitID = visitId;
            VisitCrewName = name;
            VisitCrewSurname = surname;
            VisitCrewAM = registryNumber;
        }

        public Guid ID { get; set; }

        public Guid VisitID { get; set; }

        public string VisitCrewName { get; set; }

        public string VisitCrewSurname { get; set; }

        public int VisitCrewAM { get; set; }
    }
}