using Core.Entities;
using Core.Utilities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Services.Abstract;
using WebApp.ViewModels.HomeMainSlider;
using WebApp.ViewModels.OurVision;
using WebApp.ViewModels.Product;

namespace WebApp.Services.Concrete
{
    public class OurVisionService : IOurVisionService
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IOurVisionRepository _ourVisionRepository;
        private readonly IOurVisionPhotoRepository _ourVisionPhotoRepository;
        private readonly ModelStateDictionary _modelState;

        public OurVisionService(AppDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IOurVisionRepository ourVisionRepository,
          IOurVisionPhotoRepository ourVisionPhotoRepository,
               IActionContextAccessor actionContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _ourVisionRepository = ourVisionRepository;
            _ourVisionPhotoRepository = ourVisionPhotoRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<OurVisionIndexVM> GetAllAsync()
        {
            var model = new OurVisionIndexVM()
            {
                OurVisions = await _ourVisionRepository.GetAllAsync()
            };
            return model;
        }

        public async Task<bool> CreateAsync(OurVisionCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _ourVisionRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Name", "This vision already is exist");
                return false;
            }
            if (!_fileService.IsImage(model.Photo))
            {
                _modelState.AddModelError("MainPhotoName", "File must be img formatt");
                return false;

            }
            if (!_fileService.CheckSize(model.Photo, 500))
            {
                _modelState.AddModelError("MainPhoto", "fILE SIZE IS MOREN THAN REQUESTED");
                return false;

            }

            var ourVision = new OurVision
            {
                Title = model.Title,
                Description = model.Description,
                Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath)

            };

            await _ourVisionRepository.CreateAsync(ourVision);
            return true;
        }

        public async  Task DeleteAsync(int id)
        {
            var ourVision = await _ourVisionRepository.GetAsync(id);
            if (ourVision != null)
            {
                foreach (var photo in await _ourVisionPhotoRepository.GetAllAsync())
                {
                    _fileService.Delete(photo.Name, _webHostEnvironment.WebRootPath);
                }

                await _ourVisionRepository.DeleteAsync(ourVision);
            }
        }

        public async Task<OurVisionUpdateVM> GetUpdateModelAsync(int id)
        {
            var vision = await _ourVisionRepository.GetAsync(id);

            if (vision != null)
            {


                var model = new OurVisionUpdateVM
                {
                    Id = vision.Id,
                    Title = vision.Title,
                    Description = vision.Description
                };
                return model;

            }
            return null;
        }

        public async Task<bool> UpdateAsync(OurVisionUpdateVM model)
        {
            var isExist = await _ourVisionRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This vision already is exist");
                return false;
            }
            var slider = await _ourVisionRepository.GetAsync(model.Id);
            if (slider == null) return false;

            slider.Title = model.Title;
            slider.Description = model.Description;
            await _ourVisionRepository.UpdateAsync(slider);
            if (model.Photo != null)


                if (!_fileService.IsImage(model.Photo))
                {
                    _modelState.AddModelError("Photo", "Image formatinda secin");
                    return false;
                }
            if (!_fileService.CheckSize(model.Photo, 300))
            {
                _modelState.AddModelError("Photo", "Sekilin olcusu 300 kb dan boyukdur");
                return false;
            }

            _fileService.Delete(slider.Photo, _webHostEnvironment.WebRootPath);
            slider.Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath);



            return true;
        }
    }
}
