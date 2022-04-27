namespace EydapTickets.Models
{
    public class PersonnelType
    {
        public PersonnelType()
        {
            // NOOP
        }

        public PersonnelType(
            int id,
            string description)
        {
            PersonnelTypeId = id;
            PersonnelTypeDescription = description;
        }

        public int PersonnelTypeId { get; set; }

        public string PersonnelTypeDescription { get; set; }
    }
}