using System;

namespace EydapTickets.Models
{
    public class TTRoute
    {
        public TTRoute()
        {
            // NOOP
        }

        public TTRoute(
            Guid incidentId,
            int sectorId,
            int? fromDepartmentId,
            int toDepartmentId,
            DateTime routeDate)
        {
            TTId = incidentId;
            SectorId = sectorId;
            FromDepartmentId = fromDepartmentId;
            ToDepartmentId = toDepartmentId;
            RouteDate = routeDate;
        }

        public Guid TTId { get; }

        public int SectorId { get; }

        public int? FromDepartmentId { get; }

        public int ToDepartmentId { get; }

        public DateTime RouteDate { get; }
    }
}