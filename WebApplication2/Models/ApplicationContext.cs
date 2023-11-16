using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
