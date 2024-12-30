using Task_1010.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_1010.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<DoctorsProfilesComponents> DoctorProfilesComponents { get; set; }
        public DbSet<DepartmentComponents> DepartmentComponents { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<ProductsComponents> ProductsComponents { get; set; }

    }
}
