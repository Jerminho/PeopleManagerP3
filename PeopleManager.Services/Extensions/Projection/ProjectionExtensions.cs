using PeopleManager.Dto.Results;
using PeopleManager.Model;

namespace PeopleManager.Services.Extensions.Projection
{
    public static class ProjectionExtensions
    {
        public static IQueryable<OrganizationResult> Project(this IQueryable<Organization> query)
        {
            return query.Select(o => new OrganizationResult
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                NumberOfMembers = o.Members.Count
            });
        }

        public static IQueryable<PersonResult> Project(this IQueryable<Person> query)
        {
            return query.Select(p => new PersonResult
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                OrganizationId = p.OrganizationId,
                OrganizationName = p.Organization != null ? p.Organization.Name : null
            });
        }
    }
}
