using System.Collections.Generic;

namespace EydapTickets.Models
{
    public class VisitDetailsModel
    {
        public VisitDetailsModel()
        {
            SelectedPersonnel = new List<string>();
            Items = new List<object>();
        }

        public List<string> SelectedPersonnel { get; set; }
        //public IEnumerable<VisitCrewLight> VisitCrew;
        //public IEnumerable<VisitEquipment> VisitEquipment;
        public VehicleLight VisitEquipment;

        public string AssignmentGuid { get; set; }

        //public List<string> Tokens { get; set; }
        public List<object> Items { get; set; }
    }
}