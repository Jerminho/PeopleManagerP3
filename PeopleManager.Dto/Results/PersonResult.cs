namespace PeopleManager.Dto.Results
{
    public class PersonResult
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? Email { get; set; }

        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
    }
}
