using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities
{
    public class Incident
    {
        public Guid TTId { get; set; }
        public string ID1022 { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurName { get; set; }
        public string SectorName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Municipality { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName1 { get; set; }
        public string StreetNumber1 { get; set; }
        public string Comments { get; set; }
        public int Sector { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Shift { get; set; }

        public string Perioxi { get; set; }

        public string TaxKodikas { get; set; }
        public string ArithmosMetriti { get; set; }
        public string MitrooMetriti { get; set; }

        public DateTime? CreationDate { get; set; }

        public UsersModel User { get; set; }
        public List<UsersModel> Users { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
