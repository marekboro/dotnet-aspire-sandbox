using AspireFun.Server.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireFun.Server.Infrastructure;

public class MyLocalDbContext : DbContext
{
    public MyLocalDbContext(DbContextOptions<MyLocalDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .ToTable("Companies");
        modelBuilder.Entity<Company>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Company>()
            .Property(e => e.Type);
        modelBuilder.Entity<Company>()
            .Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .ToTable("Employees");
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Employee>()
            .Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(100);

        modelBuilder.Entity<CompanyEmployee>()
            .ToTable("CompanyEmployees");
        modelBuilder.Entity<CompanyEmployee>()
            .HasKey(e => new { e.CompanyId, e.EmployeeId });
        modelBuilder.Entity<CompanyEmployee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId);
        modelBuilder.Entity<CompanyEmployee>()
            .HasOne(e => e.Employee)
            .WithMany(c => c.CompanyEmployees)
            .HasForeignKey(e => e.EmployeeId);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
}
