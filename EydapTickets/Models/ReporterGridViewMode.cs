using System.ComponentModel;

namespace EydapTickets.Models
{
    [DefaultValue(User)]
    public enum ReporterGridViewMode
    {
        User = 1,
        Supervisor
    }
}
