using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppGiamSatNhanVien.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
