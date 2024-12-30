using FlowerProjectP323.DAL;
using FlowerProjectP323.ViewModel.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public  async Task <IActionResult> Index()
        {
           
            return View();
        }
    }
}
