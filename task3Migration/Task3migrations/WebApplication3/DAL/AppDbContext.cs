using front_to_back.Models;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ContactComponent> ContactComponent { get; set; }

        public DbSet<ContactMainComponent> ContactMainComponent { get; set; }
        public DbSet<ContactCommunucationComponent> ContactCommunucationComponents { get; set; }
    }
}