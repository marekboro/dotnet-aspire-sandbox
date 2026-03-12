namespace AspireFun.Server.Models;

public record Company(Guid Id, CompanyType Type, string Name, List<BasicEmployee> Employees);
