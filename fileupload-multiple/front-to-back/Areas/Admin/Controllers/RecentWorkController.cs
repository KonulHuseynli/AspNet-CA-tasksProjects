using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public RecentWorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new RecentWorkIndexViewModel
            {

                RecentWorkComponents = await _appDbContext.RecentWorkComponents.ToListAsync()

            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecentWorkComponent recentWorkComponent)
        {
            if (!ModelState.IsValid) return View(recentWorkComponent);

            bool isExist = await _appDbContext.RecentWorkComponents
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == recentWorkComponent.Title.
                                                   ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "This work declared");

                return View(recentWorkComponent);
            }

            await _appDbContext.RecentWorkComponents.AddAsync(recentWorkComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");

        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var recentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);

            if (recentWorkComponent == null) return NotFound();
            return View(recentWorkComponent);
        }
        [HttpPost]

        public async Task<IActionResult> Update(int id, RecentWorkComponent recentWorkComponent)
        {
            if (!ModelState.IsValid) return View(recentWorkComponent);
            if (id != recentWorkComponent.Id) return BadRequest();
            var dbrecentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);
            if (dbrecentWorkComponent == null) return NotFound();


            bool isExist = await _appDbContext.RecentWorkComponents
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == recentWorkComponent.Title.
                                                   ToLower().Trim()
                                                   && c.Id != recentWorkComponent.Id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "This title declared");

                return View(recentWorkComponent);
            }

            dbrecentWorkComponent.Title = recentWorkComponent.Title;
            dbrecentWorkComponent.Text = recentWorkComponent.Text;
            dbrecentWorkComponent.FilePath = recentWorkComponent.FilePath;
           await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var recentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);

            if (recentWorkComponent == null) return NotFound();
            return View(recentWorkComponent);
        }
        [HttpPost]

        public async Task<IActionResult> DeleteComponent(int id)
        {
            var dbrecentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);
            if (dbrecentWorkComponent == null) return NotFound();


            _appDbContext.Remove(dbrecentWorkComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var recentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);

            if (recentWorkComponent == null) return NotFound();
            return View(recentWorkComponent);
        }



    }


}



