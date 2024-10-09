using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Model
{
    [Table(nameof(Person))]
    public class Person
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? Email { get; set; }

        //Optional
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
