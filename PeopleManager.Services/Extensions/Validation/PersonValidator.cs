using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.Model;
using Vives.Services.Model.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
    public static class PersonValidator
    {
        public static void Validate(this ServiceResult<PersonResult> serviceResult, PersonRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                serviceResult.NotEmpty(nameof(request.FirstName));
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                serviceResult.NotEmpty(nameof(request.LastName));
            }

            if (request.OrganizationId == default(int))
            {
                serviceResult.NotDefault(nameof(request.OrganizationId));
            }
        }

    }
}
