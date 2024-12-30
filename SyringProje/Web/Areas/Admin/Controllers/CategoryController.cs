using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Category;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var model = await _categoryService.GetAllAsync();
            return View(model);
        }

        #endregion

        #region create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(CategoryCreateVM model)
        {
            if(!ModelState.IsValid) return View(model);
            var isSucceeded=await _categoryService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);

        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _categoryService.GetUpdateModelAsync(id);
            if (model == null) return BadRequest();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, CategoryUpdateVM model)
        {
            if (id != model.Id) return NotFound();
            var isSucceeded = await _categoryService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
        #endregion
    }
}