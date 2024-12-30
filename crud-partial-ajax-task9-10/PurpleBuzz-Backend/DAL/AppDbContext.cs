using Microsoft.EntityFrameworkCore;
using PurpleBuzz_Backend.Models;

namespace PurpleBuzz_Backend.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<RecentWorkComponent> RecentWorkComponents { get; set; }
        public DbSet<ContactIntroComponent> ContactIntroComponent { get; set; }
        public DbSet<ContactContextComponent> ContactContextComponent { get; set; }
        public DbSet<ContactCommunicationComponent>ContactCommunicationComponents  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryComponent> CategoryComponents { get; set; }
        public object PricingComponents { get; internal set; }
    }
}
