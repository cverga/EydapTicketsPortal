using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Helpers
{
    public static class Constants
    {
        public static int[] AutomatedTaskTypes{ get; } = ConfigurationManager.AppSettings
            .Get("AutomatedTaskTypes")
            .Split(',')
            .Select(id => Convert.ToInt32(id))
            .ToArray();

        public static int[] MaintenanceDepartments{ get; } = ConfigurationManager.AppSettings
            .Get("MaintenanceDepartments")
            .Split(',')
            .Select(id => Convert.ToInt32(id))
            .ToArray();

        public static int[] MeteringDepartments { get; } = ConfigurationManager.AppSettings
            .Get("MeteringDepartments")
            .Split(',')
            .Select(id => Convert.ToInt32(id))
            .ToArray();

        public static int[] ResearchAndConstructionDepartments { get; } = ConfigurationManager.AppSettings
            .Get("ResearchAndConstructionDepartments")
            .Split(',')
            .Select(id => Convert.ToInt32(id))
            .ToArray();

        public static string[] TaskStates { get; } = { "Ανοιχτή", "Ολοκληρωμένη", "Ακυρωμένη" };

        public static string[] AssignmentStates { get; } = { "Ανοιχτή", "Ολοκληρωμένη", "Ακυρωμένη" };
    }
}
