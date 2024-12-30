using front_to_back.Areas.Admin.ViewModels.CategoryComponent;
using front_to_back.DAL;
using front_to_back.Helpers;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryComponentController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryComponentController(AppDbContext appDbContext,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CategoryComponentIndexViewModel
            {
                CategoryComponents = await _appDbContext.CategoryComponents
                .Include(cc => cc.Category)
                .ToListAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CategoryComponentCreateViewModel
            {
                Categories = await _appDbContext.Categories.Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                })
                .ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryComponentCreateViewModel model)
        {
            model.Categories = await _appDbContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            })
            .ToListAsync();

            if (!ModelState.IsValid) return View(model);

            var category = await _appDbContext.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "Bu kateqoriya mövcud deyil");
                return View(model);
            }

            bool isExist = await _appDbContext.CategoryComponents
                                .AnyAsync(cc => cc.Title.ToLower().Trim() == model.Title.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda kateqoriya komponent mövcuddur");
                return View(model);
            }

            if (!_fileService.IsImage(model.Photo))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View(model);
            }

            var categoryComponent = new CategoryComponent
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                FilePath = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath)
            };

            await _appDbContext.CategoryComponents.AddAsync(categoryComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categoryComponent = await _appDbContext.CategoryComponents.FindAsync(id);
            if (categoryComponent == null) return NotFound();

            var model = new CategoryComponentUpdateViewModel
            {
                Title = categoryComponent.Title,
                Description = categoryComponent.Description,
                CategoryId = categoryComponent.CategoryId,
                Categories = await _appDbContext.Categories.Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                })
                .ToListAsync(),
                PhotoPath = categoryComponent.FilePath
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, CategoryComponentUpdateViewModel model)
        {
            model.Categories = await _appDbContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            })
            .ToListAsync();

            if (!ModelState.IsValid) return View(model);

            if (id != model.Id) return BadRequest();

            var categoryComponent = await _appDbContext.CategoryComponents.FindAsync(model.Id);
            if (categoryComponent == null) return NotFound();

            bool isExist = await _appDbContext.CategoryComponents
                            .AnyAsync(cc => cc.Title.ToLower().Trim() == model.Title.ToLower().Trim()
                                            && cc.Id != categoryComponent.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda kateqoriya komponent mövcuddur");
                return View(model);
            }

            categoryComponent.Title = model.Title;
            categoryComponent.Description = model.Description;

            if (model.Photo != null)
            {
                if (!_fileService.IsImage(model.Photo))
                {
                    ModelState.AddModelError("Photo", "Yüklənən fayl şəkil formatında olmalıdır");
                    return View(model);
                }

                if (!_fileService.CheckSize(model.Photo, 300))
                {
                    ModelState.AddModelError("Photo", "Şəklin ölçüsü 300 kb-dan aşağı olmalıdır");
                    return View(model);
                }

                _fileService.Delete(_webHostEnvironment.WebRootPath, categoryComponent.FilePath);
                categoryComponent.FilePath = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath);
            }

            var category = await _appDbContext.Categories.FindAsync(model.CategoryId);
            if (category == null) return NotFound();

            categoryComponent.CategoryId = category.Id;

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
