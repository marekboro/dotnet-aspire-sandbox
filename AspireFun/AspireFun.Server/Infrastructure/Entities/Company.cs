using AspireFun.Server.Models;

namespace AspireFun.Server.Infrastructure.Entities;

public class Company
{
    public Guid Id { get; set; }
    public CompanyType Type { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }

    public Company(CompanyType type, string name)
    {
        Id = Guid.NewGuid();    
        Type = type;
        Name = name;
    }
}