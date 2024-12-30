using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HomeSlider;

namespace Web.Areas.Admin.Services.Concrete
{

    public class HomeSliderService : IHomeSliderService
    {
        private readonly IHomeSliderRepository _homeSliderRepository;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;
        public HomeSliderService(IHomeSliderRepository homeSliderRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _homeSliderRepository = homeSliderRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<bool> CreateAsync(HomeSliderCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _homeSliderRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "Bu adda Product mövcuddur");
                return false;
            }

            if (!_fileService.IsImage(model.MainPhoto))
            {
                _modelState.AddModelError("MainPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                return false;
            }
            if (!_fileService.CheckSize(model.MainPhoto, 1800))
            {
                _modelState.AddModelError("MainPhoto", "File olcusu 1800 kbdan boyukdur");
                return false;
            }



            var slider = new HomeSlider
            {
                Title = model.Title,
                CreatedAt = DateTime.Now,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto)


            };

            await _homeSliderRepository.CreateAsync(slider);

            return true;
        }



        public async Task<bool> UpdateAsync(HomeSliderUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _homeSliderRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "Bu adda Product mövcuddur");
                return false;
            }
            if (model.MainPhoto != null)
            {
                if (!_fileService.IsImage(model.MainPhoto))
                {
                    _modelState.AddModelError("MainPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                    return false;
                }
                if (!_fileService.CheckSize(model.MainPhoto, 1800))
                {
                    _modelState.AddModelError("MainPhoto", "File olcusu 1800 kbdan boyukdur");
                    return false;
                }
            }

            var slider = await _homeSliderRepository.GetAsync(model.Id);
            if (slider != null)
            {
                slider.Title = model.Title;
                slider.ModifiedAt = DateTime.Now;

                if (model.MainPhoto != null)
                {
                    slider.PhotoName = await _fileService.UploadAsync(model.MainPhoto);
                }
                await _homeSliderRepository.UpdateAsync(slider);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var slider = await _homeSliderRepository.GetAsync(id);
            if (slider != null)
            {
                _fileService.Delete(slider.PhotoName);
                await _homeSliderRepository.DeleteAsync(slider);

                return true;
            }
            return false;
        }
        public async Task<HomeSliderIndexVM> GetAllAsync()
        {
            var slider = new HomeSliderIndexVM
            {
                homeSliders = await _homeSliderRepository.GetAllAsync()
            };
            return slider;

        }
        public async Task<HomeSliderUpdateVM> GetUpdateModelAsync(int id)
        {


            var slider = await _homeSliderRepository.GetAsync(id);

            if (slider == null) return null;

            var model = new HomeSliderUpdateVM
            {
                Id = slider.Id,
                Title = slider.Title,
                MainPhotoPath = slider.PhotoName,

            };

            return model;

        }


    }
}
