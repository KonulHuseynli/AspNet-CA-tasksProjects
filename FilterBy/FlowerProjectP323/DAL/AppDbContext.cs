using FlowerProjectP323.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Graph;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.DAL
{
    public class AppDbContext :IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductPhoto> productPhotos { get; set; } 
        public DbSet<FlowerExpert> FlowerExperts { get; set; }
        
    }
}
//models d user.cs fullname
//pog.cs builder.services.addidentity<user,identityrole>(options=>
//options.password.
//options.user
//options.lockout
//  })
//   .addentityframeworkstores<AppDbContext>();
// controller account iactionreult register view al onnan view da account papka icinde register.cshtml
//viewmodel account papkasi icinde accountregistervm
//fullname email username password confirmpassword (email and password dataype(datatype.password,emailadress)
//view ,make
//controller