using FlowerProjectP323.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductPhoto> productPhotos { get; set; }
        public DbSet<FlowerExpert> FlowerExperts { get; set; }  
        public DbSet<Blog> Blogs { get; set; }

    }
}
