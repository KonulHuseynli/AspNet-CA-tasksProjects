using FlowerProjectP323.DAL;
using FlowerProjectP323.ViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext  appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task <IActionResult> Index()
        {
            Response.Cookies.Append("test", "data", new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(10)
            });
            var model = new HomeIndexViewModel
            { 
             Products= await _appDbContext.Products.OrderByDescending(p =>p.Id).Take(8).ToListAsync()
            };
            return View(model);
        }
    }
}
