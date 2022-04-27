using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Models
{
    [DefaultValue(Open)]
    public enum IncidentGridViewMode
    {
        Open = 1,
        ClosedSeventyTwoHours,
        ClosedWithPendingTasks,
        Search
    }
}
