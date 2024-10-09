using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PeopleManager.Dto.Requests
{
    public class PersonRequest
    {
        [DisplayName("First name")]
        [Required]
        public required string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public required string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        //Optional
        public int? OrganizationId { get; set; }
    }
}
