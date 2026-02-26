using AspireFun.Server.Models;

namespace AspireFun.Server.Infrastructure.Entities;

public class Company
{
    public Guid Id { get; set; }
    public AccountType Type { get; set; }
    public string Name { get; set; }

    public virtual ICollection<CompanyEmployee> Employees { get; set; }
}