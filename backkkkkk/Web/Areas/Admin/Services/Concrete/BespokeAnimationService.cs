using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeAnimation;

namespace Web.Areas.Admin.Services.Concrete
{
    public class BespokeAnimationService:IBespokeAnimationService
    {
        private readonly IBespokeAnimationRepository _bespokeAnimationRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public BespokeAnimationService(IBespokeAnimationRepository bespokeAnimationRepository, IActionContextAccessor actionContextAccessor, IFileService fileService)
        {
            _bespokeAnimationRepository = bespokeAnimationRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }


        public async Task<BespokeAnimationIndexVM> GetAsync()
        {
            var model = new BespokeAnimationIndexVM
            {
                BespokeAnimation = await _bespokeAnimationRepository.GetAsync()
            };
            return model;

        }

        public async Task<bool> CreateAsync(BespokeAnimationCreateVM model)
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
            var bespokeAnimation = new BespokeAnimation
            {
                CreatedAt = DateTime.Now,
                CoverImg = await _fileService.UploadAsync(model.CoverPhoto),
                VideoUrl = model.VideoUrl


            };
            await _bespokeAnimationRepository.CreateAsync(bespokeAnimation);
            return true;
        }


        public async Task<BespokeAnimationUpdateVM> GetUpdateModelAsync(int id)
        {



            var bespokeAnimation = await _bespokeAnimationRepository.GetAsync(id);

            if (bespokeAnimation == null) return null;

            var model = new BespokeAnimationUpdateVM
            {
                Id = bespokeAnimation.Id,
                MainPhotoPath = bespokeAnimation.CoverImg,
                VideoUrl = bespokeAnimation.VideoUrl
            };

            return model;

        }
        public async Task<bool> UpdateAsync(BespokeAnimationUpdateVM model)
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

            var bespokeAnimation = await _bespokeAnimationRepository.GetAsync(model.Id);





            if (bespokeAnimation != null)
            {
                bespokeAnimation.Id = model.Id;
                bespokeAnimation.ModifiedAt = DateTime.Now;
                bespokeAnimation.VideoUrl = model.VideoUrl;


                if (model.CoverPhoto != null)
                {
                    bespokeAnimation.CoverImg = await _fileService.UploadAsync(model.CoverPhoto);
                }

                await _bespokeAnimationRepository.UpdateAsync(bespokeAnimation);

            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bespokeAnimation = await _bespokeAnimationRepository.GetAsync(id);
            if (bespokeAnimation != null)
            {
                _fileService.Delete(bespokeAnimation.CoverImg);
                await _bespokeAnimationRepository.DeleteAsync(bespokeAnimation);
                return true;
            }

            return false;
        }

    }
}

    