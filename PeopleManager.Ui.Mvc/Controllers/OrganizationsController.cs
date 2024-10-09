using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using PeopleManager.Sdk;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrganizationSdk _organizationSdk;

        public OrganizationsController(OrganizationSdk organizationSdk)
        {
            _organizationSdk = organizationSdk;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationSdk.Find();
            return View(organizations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                var organization = new OrganizationResult
                {
                    Name = request.Name,
                    Description = request.Description
                };
                return View(organization);
            }

            await _organizationSdk.Create(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var result = await _organizationSdk.Get(id);

            if (!result.IsSuccess || result.Data is null)
            {
                return RedirectToAction("Index");
            }

            return View(result.Data);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] OrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                var result = await _organizationSdk.Get(id);
                if (!result.IsSuccess || result.Data is null)
                {
                    return RedirectToAction("Index");
                }
                var organization = result.Data;
                organization.Name = request.Name;
                organization.Description = request.Description;

                return View(organization);
            }

            await _organizationSdk.Update(id, request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _organizationSdk.Get(id);
            if (!result.IsSuccess || result.Data is null)
            {
                return RedirectToAction("Index");
            }
            return View(result.Data);
        }

        [HttpPost("/[controller]/Delete/{id:int?}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _organizationSdk.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
