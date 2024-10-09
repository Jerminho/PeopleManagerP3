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
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public async Task<IList<PersonResult>> Find()
        {
            return await _dbContext.People
                .Project()
                .ToListAsync();
        }

        //Get (by id)
        public async Task<ServiceResult<PersonResult>> Get(int id)
        {
            var serviceResult = new ServiceResult<PersonResult>();
            
            var person = await _dbContext.People
                .Project()
                .FirstOrDefaultAsync(p => p.Id == id);

            serviceResult.Data = person;
            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
            }
            
            return serviceResult;
        }

        //Create
        public async Task<ServiceResult<PersonResult>> Create(PersonRequest request)
        {
            var serviceResult = new ServiceResult<PersonResult>();
            
            serviceResult.Validate(request);

            if (!serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                OrganizationId = request.OrganizationId
            };

            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            return await Get(person.Id);
        }

        //Update
        public async Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
        {
            var serviceResult = new ServiceResult<PersonResult>();
            
            var person = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
                return serviceResult;
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.OrganizationId = request.OrganizationId;

            await _dbContext.SaveChangesAsync();

            return await Get(id);
        }

        //Delete
        public async Task<ServiceResult> Delete(int id)
        {
            var serviceResult = new ServiceResult();
            
            var person = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
                return serviceResult;
            }

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();

            serviceResult.Deleted(nameof(Person));
            return serviceResult;
        }

    }
}
