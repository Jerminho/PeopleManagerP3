using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Requests;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationsController(OrganizationService organizationService) : ControllerBase
    {
        private readonly OrganizationService _organizationService = organizationService;

        //Find (more) GET
        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var organizations = await _organizationService.Find();
            return Ok(organizations);
        }

        //Get (one) GET
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _organizationService.Get(id);
            return Ok(result);
        }

        //Create POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.Create(request);
            return Ok(result);
        }

        //Update PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.Update(id, request);
            return Ok(result);
        }

        //Delete DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _organizationService.Delete(id);
            return Ok(result);
        }

    }
}
