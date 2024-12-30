using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeAnimation;
using Web.Areas.Admin.ViewModels.HomeAnimation;

namespace Web.Areas.Admin.Services.Concrete
{
    public class HomeAnimationService:IHomeAnimationService
    {
        private readonly IHomeAnimationRepository _homeAnimationRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public HomeAnimationService(IHomeAnimationRepository homeAnimationRepository, IActionContextAccessor actionContextAccessor, IFileService fileService)
        {
            _homeAnimationRepository = homeAnimationRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }


        public async Task<HomeAnimationIndexVM> GetAsync()
        {
            var model = new HomeAnimationIndexVM
            {
                HomeAnimation = await _homeAnimationRepository.GetAsync()
            };
            return model;

        }

        public async Task<bool> CreateAsync(HomeAnimationCreateVM model)
        {

            if (!_modelState.IsValid) return false;

            if (!_fileService.IsImage(model.CoverPhoto))
            {
                _modelState.AddModelError("CoverPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                return false;
            }
            if (!_fileService.CheckSize(model.CoverPhoto, 2000))
            {
                _modelState.AddModelError("CoverPhoto", "File olcusu 2000 kbdan boyukdur");
                return false;
            }
            var homeAnimation = new HomeAnimation
            {
                CreatedAt = DateTime.Now,
                CoverImg = await _fileService.UploadAsync(model.CoverPhoto),
                VideoUrl = model.VideoUrl


            };
            await _homeAnimationRepository.CreateAsync(homeAnimation);
            return true;
        }


        public async Task<HomeAnimationUpdateVM> GetUpdateModelAsync(int id)
        {



            var homeAnimation = await _homeAnimationRepository.GetAsync(id);

            if (homeAnimation == null) return null;

            var model = new HomeAnimationUpdateVM
            {
                Id = homeAnimation.Id,
                MainPhotoPath = homeAnimation.CoverImg,
                VideoUrl = homeAnimation.VideoUrl
            };

            return model;

        }
        public async Task<bool> UpdateAsync(HomeAnimationUpdateVM model)
        {
            if (!_modelState.IsValid) return false;


            if (model.CoverPhoto != null)
            {
                if (!_fileService.IsImage(model.CoverPhoto))
                {
                    _modelState.AddModelError("CoverPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                    return false;
                }
                if (!_fileService.CheckSize(model.CoverPhoto, 2000))
                {
                    _modelState.AddModelError("CoverPhoto", "File olcusu 2000 kbdan boyukdur");
                    return false;
                }
            }

            var homeAnimation = await _homeAnimationRepository.GetAsync(model.Id);
            if (homeAnimation != null)
            {
                homeAnimation.Id = model.Id;
                homeAnimation.ModifiedAt = DateTime.Now;
                homeAnimation.VideoUrl = model.VideoUrl;


                if (model.CoverPhoto != null)
                {
                    homeAnimation.CoverImg = await _fileService.UploadAsync(model.CoverPhoto);
                }

                await _homeAnimationRepository.UpdateAsync(homeAnimation);

            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var homeAnimation = await _homeAnimationRepository.GetAsync(id);
            if (homeAnimation != null)
            {
                _fileService.Delete(homeAnimation.CoverImg);
                await _homeAnimationRepository.DeleteAsync(homeAnimation);
                return true;
            }

            return false;
        }

      
    }
}
