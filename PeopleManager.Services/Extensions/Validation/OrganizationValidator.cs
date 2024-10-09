using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.Model;
using Vives.Services.Model.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
    public static class OrganizationValidator
    {
        public static void Validate(this ServiceResult<OrganizationResult> serviceResult, OrganizationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                serviceResult.NotEmpty(nameof(request.Name));
            }
        }

    }
}
