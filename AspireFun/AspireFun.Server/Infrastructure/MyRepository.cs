using AspireFun.Server.Models;
using Microsoft.EntityFrameworkCore;
using Company = AspireFun.Server.Infrastructure.Entities.Company;
using CompanyEmployee = AspireFun.Server.Infrastructure.Entities.CompanyEmployee;
using CompanyModel = AspireFun.Server.Models.Company;
using Employee = AspireFun.Server.Infrastructure.Entities.Employee;
using EmployeeModel = AspireFun.Server.Models.Employee;

namespace AspireFun.Server.Infrastructure;

public interface IMyRepository
{
    public Task<List<CompanyModel>> GetCompanies();
    public Task<int> GetCompanyCout();
    public Task<int> GetEmployeeCout();
    public Task<CompanyModel>? GetCompany(Guid companyId);
    public Task<List<Employee>> GetEmployees();
    public Task AddCompany(Company company);
    public Task AddEmployee(Employee employee, Guid companyId);
}

public class MyRepository : IMyRepository
{
    private readonly MyLocalDbContext _myLocalDbContext;

    public MyRepository(MyLocalDbContext myLocalDbContext)
    {
        _myLocalDbContext = myLocalDbContext;
    }
    
    private IEnumerable<Employee> Employees => _myLocalDbContext.Employees.Include(e => e.CompanyEmployees);

    public Task<CompanyModel>? GetCompany(Guid companyId)
    {
        var companyEntity = _myLocalDbContext.Companies.SingleOrDefault(c => c.Id == companyId);
        if (companyEntity == null)
        {
            return null;
        }

        var employeeIds = _myLocalDbContext.CompanyEmployees.Where(ce => ce.CompanyId == companyEntity.Id)
            .Select(ce => ce.EmployeeId).ToList();
        var employees = _myLocalDbContext.Employees.Where(e => employeeIds.Contains(e.Id)).Select(e => e.ToBasicModel())
            .ToList();
        var company = companyEntity.ToModel(employees);
        return Task.FromResult(company);
    }

    public Task<List<CompanyModel>> GetCompanies()
    {
        var employeeDictionary = Employees.ToDictionary(e => e.Id, e => e.ToBasicModel());

        var companyEmployeeDictionary = _myLocalDbContext.CompanyEmployees
            .Select(ce => new { ce.EmployeeId, ce.CompanyId })
            .GroupBy(e => e.CompanyId)
            .AsNoTracking()
            .ToDictionary(k => k.Key, v => v.Select(c => employeeDictionary[c.EmployeeId]));
        
        var companies = _myLocalDbContext.Companies
            .AsNoTracking()
            .Select(c => c.ToModel(companyEmployeeDictionary[c.Id].ToList()));
        
        return Task.FromResult(companies.ToList());
    }

    public Task<int> GetCompanyCout()
    {
        var count = _myLocalDbContext.Companies.Count();
        return  Task.FromResult(count);
    }
    
    public Task<int> GetEmployeeCout()
    {
        var count = _myLocalDbContext.Employees.Count();
        return  Task.FromResult(count);
    }

    public Task<List<Employee>> GetEmployees()
    {
        var employees = _myLocalDbContext.Employees
            .Include(e => e.CompanyEmployees)
            .ToList();
        return Task.FromResult(employees);
    }

    public Task AddCompany(Company company)
    {
        _myLocalDbContext.Add(company);
        return _myLocalDbContext.SaveChangesAsync();
    }

    public Task AddEmployee(Employee employee, Guid companyId)
    {
        var companyEmployee = new CompanyEmployee
        {
            CompanyId = companyId,
            EmployeeId = employee.Id
        };

        _myLocalDbContext.Add(employee);
        _myLocalDbContext.Add(companyEmployee);
        return _myLocalDbContext.SaveChangesAsync();
    }
}

public static class RepositoryConversionHelpers
{
    public static CompanyModel ToModel(this Company company, List<BasicEmployee> employees)
    {
        return new CompanyModel(company.Id, company.Type, company.Name, employees);
    }

    public static EmployeeModel ToModel(this Employee employee)
    {
        var companyIds = employee.CompanyEmployees.Select(e => e.CompanyId).ToList();
        return new EmployeeModel(employee.Id, employee.Name, companyIds);
    }
    public static BasicEmployee ToBasicModel(this Employee employee)
    {
        var companyIds = employee.CompanyEmployees.Select(e => e.CompanyId).ToList();
        return new BasicEmployee(employee.Id, employee.Name);
    }
}