using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<FineJewellerCategory> FineJewellerCategories { get; set; }
        public DbSet<HighJewellerCategory> HighJewellerCategories { get; set; }
        public DbSet<BespokeAnimation> BespokeAnimations { get; set; }
        public DbSet<BespokeInform> BespokeInformations { get; set; }   
        public DbSet<HomeAnimation> homeAnimations { get; set; }    
        public DbSet <FineJewellerAnimation> FineJewellerAnimations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FJProducts> FJProducts { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketProduct> basketProducts { get; set; }
        public DbSet<HomeSlider> homeSliders { get; set; }
        public DbSet<WeddingMain> weddingMains { get; set; }        
        public DbSet<HighJewellerMain> highJewellerMains { get; set; }  
    }
}

