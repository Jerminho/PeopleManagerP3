using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Dto.Requests
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public required string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
