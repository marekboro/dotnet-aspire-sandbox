namespace AspireFun.Server.Models;

public record Employee(Guid Id, string Name, List<Guid> CompanyIds);
public record BasicEmployee(Guid Id, string Name);