using Microsoft.AspNetCore.Identity;

namespace FlowerProjectP323.Models
{
    public class User:IdentityUser
    {
        public string Fullname { get; set; } 
    }
}
