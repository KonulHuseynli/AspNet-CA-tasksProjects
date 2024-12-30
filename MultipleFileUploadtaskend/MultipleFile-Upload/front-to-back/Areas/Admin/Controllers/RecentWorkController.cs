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
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == recentWorkComponent.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda RecentWork artiq movcuddur");

                return View(recentWorkComponent);
            }

            await _appDbContext.RecentWorkComponents.AddAsync(recentWorkComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var recentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);
            if (recentWorkComponent == null) return NotFound();

            return View(recentWorkComponent);
           
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,RecentWorkComponent recentWorkComponent)
        {
            if (!ModelState.IsValid) return View(recentWorkComponent);

            if (id != recentWorkComponent.Id) return BadRequest();
            var dBrecentWorkComponent= await _appDbContext.RecentWorkComponents.FindAsync(id);
            if (dBrecentWorkComponent == null) return NotFound();

            bool isExist = await _appDbContext.RecentWorkComponents
                .AnyAsync(rcw => rcw.Title.ToLower().Trim() == recentWorkComponent.Title.ToLower().Trim() &&
                rcw.Id != recentWorkComponent.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda komponent movcuddur");
                return View(recentWorkComponent);
            }
            dBrecentWorkComponent.Title=recentWorkComponent.Title;
            dBrecentWorkComponent.Text = recentWorkComponent.Text;
            dBrecentWorkComponent.FilePath = recentWorkComponent.FilePath;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
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
            

            
            var dBrecentWorkComponent = await _appDbContext.RecentWorkComponents.FindAsync(id);
            if (dBrecentWorkComponent == null) return NotFound();


            _appDbContext.Remove(dBrecentWorkComponent);

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
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
