using System;

namespace EydapTickets.Models
{
    public class IncidentRoutingElement
    {
        public IncidentRoutingElement()
        {
            // NOOP
        }

        public IncidentRoutingElement(
            Guid aId,
            Guid aTTId,
            string aID1022,
            DateTime aDateTime,
            string aSector,
            string aDepartment,
            string aAction,
            string aUser)
        {
            Id = aId;
            TTID = aTTId;
            ID1022 = aID1022;
            DateTime = aDateTime;
            Sector = aSector;
            Department = aDepartment;

            var change = aAction[aAction.Length - 1].ToString();
            switch (change)
            {
                case "1":
                {
                    Action = aAction.Replace("1", "Ανοιχτή");
                }
                    break;
                case "2":
                {
                    Action = aAction.Replace("2", "Επαναδρομολόγηση");
                }
                    break;
                case "3":
                {
                    Action = aAction.Replace("3", "Κλειστή");
                }
                    break;
                case "4":
                {
                    Action = aAction.Replace("4", "Αρχειοθετημένη");
                }
                    break;
                case "5":
                {
                    Action = aAction.Replace("5", "Ακυρωμένη");
                }
                    break;
                case "6":
                {
                    Action = aAction.Replace("6", "Κλειστή/Εκκρεμότητες");
                }
                    break;
                default:
                    Action = aAction;
                    break;
            }

            User = aUser;
        }

        public Guid Id { get; set; }

        public Guid TTID { get; set; }

        public string ID1022 { get; set; }

        public DateTime DateTime { get; set; }

        public string Sector { get; set; }

        public string Department { get; set; }

        public string Action { get; set; }

        public string User { get; set; }
    }
}