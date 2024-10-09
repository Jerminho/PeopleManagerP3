using System.Net.Http.Json;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.Model;
using Vives.Services.Model.Extensions;

namespace PeopleManager.Sdk
{
    public class OrganizationSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        //Find
        public async Task<IList<OrganizationResult>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = "Organizations";
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IList<OrganizationResult>>();
            if (result is null)
            {
                return new List<OrganizationResult>();
            }

            return result;
        }

        //Get
        public async Task<ServiceResult<OrganizationResult>> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = $"Organizations/{id}";
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>();
            }

            return result;
        }

        //Create
        public async Task<ServiceResult<OrganizationResult>> Create(OrganizationRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = "Organizations";
            var response = await httpClient.PostAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>();
            }

            return result;
        }

        //Update
        public async Task<ServiceResult<OrganizationResult>> Update(int id, OrganizationRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = $"Organizations/{id}";
            var response = await httpClient.PutAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                result = new ServiceResult<OrganizationResult>();
                result.NotFound(nameof(OrganizationResult), id);
            }

            return result;
        }

        //Delete
        public async Task<ServiceResult<OrganizationResult>> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = $"Organizations/{id}";
            var response = await httpClient.DeleteAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>();
            }

            return result;
        }
    }
}
