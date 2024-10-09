using Microsoft.EntityFrameworkCore;
using PeopleManager.Core;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using PeopleManager.Model;
using PeopleManager.Services.Extensions.Projection;
using PeopleManager.Services.Extensions.Validation;
using Vives.Services.Model;
using Vives.Services.Model.Extensions;

namespace PeopleManager.Services
{
    public class OrganizationService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public OrganizationService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public async Task<IList<OrganizationResult>> Find()
        {
            return await _dbContext.Organizations
                .Project()
                .ToListAsync();
        }

        //Get (by id)
        public async Task<ServiceResult<OrganizationResult>> Get(int id)
        {
            var serviceResult = new ServiceResult<OrganizationResult>();
            
            var organization = await _dbContext.Organizations
                .Project()
                .FirstOrDefaultAsync(p => p.Id == id);

            serviceResult.Data = organization;
            if (organization is null)
            {
                serviceResult.NotFound(nameof(Organization), id);
            }

            return serviceResult;
        }

        //Create
        public async Task<ServiceResult<OrganizationResult>> Create(OrganizationRequest request)
        {
            var serviceResult = new ServiceResult<OrganizationResult>();

            //Validate request
            serviceResult.Validate(request);

            if (!serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var organization = new Organization
            {
                Name = request.Name,
                Description = request.Description
            };

            _dbContext.Organizations.Add(organization);
            await _dbContext.SaveChangesAsync();

            return await Get(organization.Id);
        }

        //Update
        public async Task<ServiceResult<OrganizationResult>> Update(int id, OrganizationRequest request)
        {

            var serviceResult = new ServiceResult<OrganizationResult>();

            //Validate request
            serviceResult.Validate(request);

            if (!serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var organization = _dbContext.Organizations
                .FirstOrDefault(p => p.Id == id);

            if (organization is null)
            {
                serviceResult.NotFound(nameof(Organization), id);
                return serviceResult;
            }

            organization.Name = request.Name;
            organization.Description = request.Description;

            await _dbContext.SaveChangesAsync();

            return await Get(organization.Id);
        }

        //Delete
        public async Task<ServiceResult> Delete(int id)
        {
            var serviceResult = new ServiceResult();
            
            var organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(p => p.Id == id);

            if (organization is null)
            {
                serviceResult.NotFound(nameof(Organization), id);
                return serviceResult;
            }

            _dbContext.Organizations.Remove(organization);
            await _dbContext.SaveChangesAsync();

            serviceResult.Deleted(nameof(Organization));
            return serviceResult;
        }

    }
}
