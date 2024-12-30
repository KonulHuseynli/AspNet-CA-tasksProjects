using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller

    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CategoryIndexViewModel
            {
                Categories = await _appDbContext.Categories.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            bool isExist = await _appDbContext.Categories.AnyAsync(rwc => rwc.Title.ToLower().Trim() == category.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "This category declared");
                return View(category);
            }

            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, Category category)
        {
            if (!ModelState.IsValid) return View(category);
            if (id != category.Id) return BadRequest();
            var dbcategory = await _appDbContext.Categories.FindAsync(id);
            if (dbcategory == null) return NotFound();


            bool isExist = await _appDbContext.Categories
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == category.Title.
                                                   ToLower().Trim()
                                                   && c.Id != category.Id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "This title declared");

                return View(category);
            }

            dbcategory.Title = category.Title;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var dbcategory = await _appDbContext.Categories.FindAsync(id);
            if (dbcategory == null) return NotFound();


            _appDbContext.Remove(dbcategory);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();
            return View(category);
        }
    }
}
