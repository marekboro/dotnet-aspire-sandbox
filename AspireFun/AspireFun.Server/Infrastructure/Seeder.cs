using AspireFun.Server.Models;
using Company = AspireFun.Server.Infrastructure.Entities.Company;
using Employee = AspireFun.Server.Infrastructure.Entities.Employee;

namespace AspireFun.Server.Infrastructure;

public interface ISeeder
{
    Task Seed();
}

public class Seeder : ISeeder
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly List<string> _employeeNames = ["Blaze", "Laser", "Blazer"];
    private readonly List<string> _companyNames = ["GlobalGym", "La Biblioteka", "Some Hole"];

    private readonly List<CompanyType> _companyTypes =
        [CompanyType.BigFish, CompanyType.SmallFish, CompanyType.SmallFish];

    public Seeder(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Seed()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IMyRepository>();
        if (await CheckIfSeeded(repository))
        {
            Console.WriteLine("DB has data, SKIPPING SEEDING.");
            return;
        }

        Console.WriteLine("DB in initial state, SEEDING DATA");
        var companyCounter = 0;
        var companies = new List<Company>();
        foreach (var companyName in _companyNames)
        {
            var company = new Company(_companyTypes[companyCounter], companyName);
            companies.Add(company);
            await repository.AddCompany(company);
            companyCounter++;
        }

        var employeeCounter = 0;
        foreach (var employeeName in _employeeNames)
        {
            await repository.AddEmployee(new Employee(employeeName), companies[employeeCounter].Id);
            employeeCounter++;
        }
    }

    private static async Task<bool> CheckIfSeeded(IMyRepository repository)
    {
        var companyCout = await repository.GetCompanyCout();
        var employeeCout = await repository.GetEmployeeCout();
        Console.WriteLine($"Found {companyCout} companies and {employeeCout} employees Seeded.");
        return companyCout != 0 || employeeCout != 0;
    }
}