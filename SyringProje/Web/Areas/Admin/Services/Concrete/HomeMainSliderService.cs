using Core.Entities;
using Core.Utilities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using WebApp.Services.Abstract;
using WebApp.ViewModels.HomeMainSlider;

using HomeMainSlider = Core.Entities.HomeMainSlider;

namespace WebApp.Services.Concrete
{
    public class HomeMainSliderService : IHomeMainSliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IHomeMainSliderPhotoRepsository _homeSliderPhotoRepsository;
        private readonly IHomeMainSliderRepository _homeSliderRepository;
        private readonly ModelStateDictionary _modelState;

        public HomeMainSliderService(AppDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IHomeMainSliderRepository homeSliderRepository,
            IHomeMainSliderPhotoRepsository homeSliderPhotoRepsository,
               IActionContextAccessor actionContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _homeSliderPhotoRepsository = homeSliderPhotoRepsository;
            _homeSliderRepository = homeSliderRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<HomeMainSliderIndexVM> GetAllAsync()
        {
            var model = new HomeMainSliderIndexVM()
            {
                HomeMainSliders = await _homeSliderRepository.GetAllAsync()
            };
            return model;
        }
        public async Task<bool> CreateAsync(HomeMainSliderCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _homeSliderRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Name", "This slider already is exist");
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

            var homeMainSlider = new HomeMainSlider
            {
                Title = model.Title,
                Description = model.Description,
                SubPhotoName = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath)

            };

            await _homeSliderRepository.CreateAsync(homeMainSlider);
            return true;
        }


        public async Task DeleteAsync(int id)
        {
            //var homeMainSlider = await _homeSliderRepository.GetAsync(id);
            //if (homeMainSlider != null)
            //{
            //    await _homeSliderRepository.DeleteAsync(homeMainSlider);
            //}

            var homeMainSlider = await _homeSliderRepository.GetAsync(id);
            if (homeMainSlider != null)
            {
                foreach (var photo in await _homeSliderPhotoRepsository.GetAllAsync())
                {
                    _fileService.Delete(photo.Name, _webHostEnvironment.WebRootPath);
                }

                await _homeSliderRepository.DeleteAsync(homeMainSlider);
            }
        }
        public async Task<bool> UpdateAsync(HomeMainSliderUpdateVM model)
        {
            var isExist = await _homeSliderRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This slider already is exist");
                return false;
            }
            var slider = await _homeSliderRepository.GetAsync(model.Id);
            if (slider == null) return false;

            slider.Title = model.Title;
            slider.Description = model.Description;
            await _homeSliderRepository.UpdateAsync(slider);
            if (model.SubPhoto != null)


                if (!_fileService.IsImage(model.SubPhoto))
                {
                    _modelState.AddModelError("Photo", "Image formatinda secin");
                    return false;
                }
            if (!_fileService.CheckSize(model.SubPhoto, 300))
            {
                _modelState.AddModelError("Photo", "Sekilin olcusu 300 kb dan boyukdur");
                return false;
            }

            _fileService.Delete(slider.SubPhotoName, _webHostEnvironment.WebRootPath);
            slider.SubPhotoName = await _fileService.UploadAsync(model.SubPhoto, _webHostEnvironment.WebRootPath);



            return true;
        }

        public async Task<HomeMainSliderUpdateVM> GetUpdateModelAsync(int id)
        {
            var slider = await _homeSliderRepository.GetAsync(id);

            if (slider != null)
            {


                var model = new HomeMainSliderUpdateVM
                {
                    Id = slider.Id,
                    Title = slider.Title,
                    Description=slider.Description
                };
                return model;

            }
            return null;
        }
    }
}
