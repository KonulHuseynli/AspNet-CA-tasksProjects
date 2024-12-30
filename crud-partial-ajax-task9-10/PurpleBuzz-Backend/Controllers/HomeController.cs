using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_Backend.DAL;
using PurpleBuzz_Backend.Models;
using PurpleBuzz_Backend.ViewModels.Home;

namespace PurpleBuzz_Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                RecentWorkComponents = await _appDbContext.RecentWorkComponents
             .OrderByDescending(rwc => rwc.Id)
             .Take(3)
             .ToListAsync()
            };
            return View(model);
        }
        public async Task<IActionResult> LoadMore(int skipRow)
        {
            var recentWorkComponents = await _appDbContext.RecentWorkComponents
             .OrderByDescending(rwc => rwc.Id)
             .Take(3 * skipRow)
             .ToListAsync();
            return PartialView("_RecentWorkComponentPartial",recentWorkComponents);
        }
        
    }
}
