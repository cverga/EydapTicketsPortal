using System;

namespace EydapTickets.Models
{
    public class Investigation
    {
        public Investigation()
        {
            // NOOP
        }

        public Investigation(
            Guid aInvestigationsId,
            string aFakelosId,
            string aFakelos_Municipality,
            string aFakelos_Odos,
            string aFakelos_Perioxi,
            string aFakelos_Arithmos,
            DateTime aCreationDate,
            string aID1022,
            int aSectorId,
            int aDepartmentId)
        {
            InvestigationsId = aInvestigationsId;
            FakelosId = aFakelosId;
            Fakelos_Municipality = aFakelos_Municipality;
            Fakelos_Odos = aFakelos_Odos;
            Fakelos_Perioxi = aFakelos_Perioxi;
            Fakelos_Arithmos = aFakelos_Arithmos;
            CreationDate = aCreationDate.ToShortDateString();
            Link = "Jerry";
            ID1022 = aID1022;
            SectorId = aSectorId;
            DepartmentId = aDepartmentId;
        }

        public Guid InvestigationsId { get; set; }

        public string FakelosId { get; set; }

        public string Fakelos_Municipality { get; set; }

        public string Fakelos_Odos { get; set; }

        public string Fakelos_Perioxi { get; set; }

        public string Fakelos_Arithmos { get; set; }

        public string ID1022 { get; set; }

        public int SectorId { get; set; }

        public int DepartmentId { get; set; }

        public string CreationDate { get; set; }

        public string Link { get; set; }
    }
}