namespace AspireFun.Server.Infrastructure.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Employee(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; } // one Employee works at multiple companies as it is 2026.
}