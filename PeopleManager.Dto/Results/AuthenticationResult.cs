using Vives.Services.Model;

namespace PeopleManager.Dto.Results
{
    public class AuthenticationResult: ServiceResult
    {
        public string? Token { get; set; }
    }
}
