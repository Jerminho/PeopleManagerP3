using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleManager.Sdk;
using PeopleManager.Sdk.Extensions;
using PeopleManager.Ui.ConsoleApp.Settings;

var configurationBuilder = new ConfigurationBuilder();
var services = new ServiceCollection();

configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = configurationBuilder.Build();

var apiSettings = new ApiSettings();
configuration.GetSection(nameof(ApiSettings)).Bind(apiSettings);
services.AddApi(apiSettings.BaseUrl);

var serviceProvider = services.BuildServiceProvider();

//Show Organizations
var organizationService = serviceProvider.GetRequiredService<OrganizationSdk>();

var organizations = await organizationService.Find();

foreach (var organization in organizations)
{
    Console.WriteLine($"[{organization.Id}] {organization.Name} ({organization.NumberOfMembers} members)");
}

//Show People
var personService = serviceProvider.GetRequiredService<PersonSdk>();

var people = await personService.Find();

foreach (var person in people)
{
    Console.WriteLine($"[{person.Id}] {person.FirstName} {person.LastName} ({person.OrganizationName})");
}

Console.ReadLine();
