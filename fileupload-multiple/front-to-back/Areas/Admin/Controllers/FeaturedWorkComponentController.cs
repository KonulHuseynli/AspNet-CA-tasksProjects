using front_to_back.Areas.Admin.ViewModels.FeaturedWorkComponent;
using front_to_back.Areas.Admin.ViewModels.FeaturedWorkComponent.FeaturedWorkComponentPhoto;
using front_to_back.DAL;
using front_to_back.Helpers;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedWorkComponentController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FeaturedWorkComponentController(AppDbContext appDbContext, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model = new FeaturedWorkComponentIndexViewModel
            {
                FeaturedWorkComponents = await _appDbContext.FeaturedWorkComponent.FirstOrDefaultAsync()
            };
            return View(model);
        }


        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var featuredWorkComponent = await _appDbContext.FeaturedWorkComponent.FirstOrDefaultAsync();
            if (featuredWorkComponent != null) return NotFound();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeaturedWorkComponentCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var featuredWorkComponent = new FeaturedWorkComponent
            {
                Title = model.Title,
                Description = model.Description
            };

            await _appDbContext.FeaturedWorkComponent.AddAsync(featuredWorkComponent);
            await _appDbContext.SaveChangesAsync();

            bool hasError = false;
            foreach (var photo in model.Photos)
            {
                if (!_fileService.IsImage(photo))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} is not required(image) format");
                    hasError = true;
                }
                else if (!_fileService.CheckSize(photo, 700))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} must be less than 700-kb");
                    hasError = true;
                }

            }

            if (hasError) { return View(model); }

            int order = 1;
            foreach (var photo in model.Photos)
            {
                var featuredWorkComponentPhoto = new FeaturedWorkComponentPhoto
                {
                    Name = await _fileService.UploadAsync(photo, _webHostEnvironment.WebRootPath),
                    Order = order,
                    FeaturedWorkComponentId = featuredWorkComponent.Id
                };
                await _appDbContext.FeaturedWorkComponentPhotos.AddAsync(featuredWorkComponentPhoto);
                await _appDbContext.SaveChangesAsync();

                order++;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var featuredWorkComponent = await _appDbContext.FeaturedWorkComponent
                                                .Include(fw => fw.FeaturedWorkComponentPhotos).FirstOrDefaultAsync();
            if (featuredWorkComponent == null) return NotFound();

            foreach (var photo in featuredWorkComponent.FeaturedWorkComponentPhotos)
            {
                _fileService.Delete(_webHostEnvironment.WebRootPath, photo.Name);
            }

            _appDbContext.FeaturedWorkComponent.Remove(featuredWorkComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var featuredWorkComponent = await _appDbContext.FeaturedWorkComponent.
                                                            Include(fwc => fwc.FeaturedWorkComponentPhotos)
                                                            .FirstOrDefaultAsync();


            if(featuredWorkComponent == null) return NotFound();

            var model = new FeaturedWorkComponentUpdateViewModel
            {
                Title = featuredWorkComponent.Title,
                Description = featuredWorkComponent.Description,
                FeaturedWorkComponentPhotos = featuredWorkComponent.FeaturedWorkComponentPhotos.ToList()
            };

            return View(model);
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> UpdatePhoto(int id)
        {
            var featuredWorkComponentPhoto = await _appDbContext.FeaturedWorkComponentPhotos.FindAsync(id);

            if (featuredWorkComponentPhoto == null) return NotFound();

            var model = new FeaturedWorkComponentPhotoUpdateViewModel
            {
                Order = featuredWorkComponentPhoto.Order 
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhoto(int id, FeaturedWorkComponentPhotoUpdateViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            if (id != model.Id) return BadRequest();

            var featuredWorkComponentPhoto = await _appDbContext.FeaturedWorkComponentPhotos.FindAsync(model.Id);

            if(featuredWorkComponentPhoto == null) return NotFound();

            featuredWorkComponentPhoto.Order = model.Order;

             await _appDbContext.SaveChangesAsync();
            return RedirectToAction("update", "featuredworkcomponent", new { id = featuredWorkComponentPhoto.FeaturedWorkComponentId});
        }
    }
}






