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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> productphotos { get; set; }
        public  DbSet<HomeMainSlider> homeMainSliders { get; set; }
        public DbSet<HomeMainSliderPhoto> homeMainSliderPhotos { get; set; }    
        public DbSet<OurVision> OurVisions { get; set; } 
        public DbSet<OurVisionPhoto> OurVisionPhotos { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPhoto> DoctorPhotos { get; set; }
        public DbSet<WhatWeDoBest> WhatsWeDoBests { get; set; }
        public DbSet<WhatWeDoBestPhoto> WhatsWeDoBestPhotos { get; set; }
    }
}