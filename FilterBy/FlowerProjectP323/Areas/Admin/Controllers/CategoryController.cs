using FlowerProjectP323.Areas.Admin.ViewModels;
using FlowerProjectP323.DAL;
using FlowerProjectP323.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace FlowerProjectP323.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CategoryIndexViewModel
            {
                Categories = await _appDbContext.Categories.ToListAsync()
            };
            return View(model);
        }
        #region create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            bool isExist = await _appDbContext.Categories
                            .AnyAsync(c => c.Title.ToLower().Trim() == category.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "This title is already exist");
                return View(category);
            }
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
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
            var dbCategory = await _appDbContext.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            _appDbContext.Categories.Remove(dbCategory);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }
        #endregion
        #region update
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

            var dbCategory = await _appDbContext.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            bool isExist = await _appDbContext.Categories.AnyAsync(c => c.Title.ToLower().Trim() == category.Title.ToLower().Trim() && c.Id != category.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This title is already exist");
                return View(category);
            }
            dbCategory.Title = category.Title;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }
        #endregion
        #region details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var dbCategory = await _appDbContext.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }
        #endregion
    }
}

