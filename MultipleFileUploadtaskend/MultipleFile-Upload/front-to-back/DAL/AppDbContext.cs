using front_to_back.Models;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<RecentWorkComponent> RecentWorkComponents { get; set; }
        public DbSet<ContractIntroComponent> ContractIntroComponent { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryComponent> CategoryComponents { get; set; }
        public DbSet<ObjectiveComponent> ObjectiveComponents { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FeaturedWorkComponent> FeatureWorkComponent { get; set; }
        public DbSet<FeaturedWorkComponentPhoto> FeaturedWorkComponentPhotos { get; set; }
    }
}
