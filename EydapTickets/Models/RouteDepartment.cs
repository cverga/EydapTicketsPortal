namespace EydapTickets.Models
{
    public class RouteDepartment
    {
        public RouteDepartment()
        {
            // NOOP
        }

        public RouteDepartment(
            int departmentId,
            string departmentDescription,
            bool isRouted)
        {
            DepartmentId = departmentId;
            DepartmentDescription = departmentDescription;
            IsRouted = isRouted;
        }

        public int DepartmentId { get; set; }

        public string DepartmentDescription { get; set; }

        public bool IsRouted { get; set; }
    }
}