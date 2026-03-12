using AspireFun.Server.Infrastructure;
using AspireFun.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireFun.Server.Controllers;

[ApiController]
[Route("/api")]
[Produces("application/json")]
public class CompanyController: ControllerBase
{
    private readonly ILogger<CompanyController> _logger;
    private readonly IMyRepository _repository;

    public CompanyController(IMyRepository repository)
    {
        _repository = repository;
        _logger = new  LoggerFactory().CreateLogger<CompanyController>();
    }
    
    /// <summary>
    /// Returns a Company with Employees
    /// </summary>
    /// <param name="id" example="43ddd5fd-081a-494e-823b-0b0bdbf1eaa6">The ID of the company to return details for.</param>
    /// <returns><see cref="Models.Company"/></returns>
    [HttpGet]
    [Route("companies/{id:guid}")]
    [ProducesResponseType<Models.Company>(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetCompany(Guid id)
    {
        _logger.LogInformation("GetCompanies");
        var company = await _repository.GetCompany(id);
        if (company is null)
        {
            return NotFound();
        }
        return Ok(company);
    }
    
    [HttpGet]
    [Route("companies")]
    [ProducesResponseType<CompaniesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetCompanies()
    {
        _logger.LogInformation("GetCompanies");
        var companies = await _repository.GetCompanies();
        var response = new CompaniesResponse(companies);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("employees")]
    [ProducesResponseType<EmployeesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetEmployees()
    {
        _logger.LogInformation("GetEmployees");
        var employeeEntities = await _repository.GetEmployees();
        var employees = employeeEntities.Select(e => e.ToModel()).ToList();
        var response = new EmployeesResponse(employees);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("get-test-one")]
    public Task<ActionResult<TestResponse>> GetTestOne()
    {
        _logger.LogInformation("GetTestOne");
        var response = TestResponse.CreateTestResponse();
        return Task.FromResult<ActionResult<TestResponse>>(Ok(response));
    }
    
    [HttpGet]
    [Route("get-test-two")]
    public Task<ActionResult<TestResponse>> GetTestTwo()
    {
        _logger.LogInformation("GetTestTwo");
        var response = TestResponse.CreateTestResponse();
        return Task.FromResult<ActionResult<TestResponse>>(Ok(response));
    }
}