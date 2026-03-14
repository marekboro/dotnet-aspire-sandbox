namespace AspireFun.Server.Infrastructure.Entities;

public class CompanyEmployee
{
    public Guid CompanyId { get; set; }
    public Guid EmployeeId { get; set; }

    public virtual Company Company { get; set; }
    public virtual Employee Employee { get; set; }
}