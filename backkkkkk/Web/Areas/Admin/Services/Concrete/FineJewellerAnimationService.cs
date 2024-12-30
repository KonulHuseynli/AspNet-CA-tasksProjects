using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.FineJewellerAnimation;

namespace Web.Areas.Admin.Services.Concrete
{
    public class FineJewellerAnimationService:IFineJewellerAnimationService
    {
        private readonly IFineJewellerAnimationRepository _fineJewellerAnimationRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public FineJewellerAnimationService(IFineJewellerAnimationRepository fineJewellerAnimationRepository, IActionContextAccessor actionContextAccessor, IFileService fileService)
        {
            _fineJewellerAnimationRepository = fineJewellerAnimationRepository;

            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        #region FineJewellerCrud
        public async Task<FineJewellerAnimationIndexVM> GetAllAsync()
        {
            var model = new FineJewellerAnimationIndexVM
            {
                FineJewellerAnimations = await _fineJewellerAnimationRepository.GetAllAsync()
            };
            return model;

        }

        public async Task<bool> CreateAsync(FineJewellerAnimationCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _fineJewellerAnimationRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This title already exist");
                return false;
            }

            if (!_fileService.IsImage(model.MainPhoto))
            {
                _modelState.AddModelError("MainPhoto", "file isnt image format");
                return false;
            }
            if (!_fileService.CheckSize(model.MainPhoto, 1800))
            {
                _modelState.AddModelError("MainPhoto", "File size more than 1800Kb");
                return false;
            }



            var fineJewellerAnimation = new FineJewellerAnimation
            {
                Id = model.Id,
                Title = model.Title,
                CreatedAt = DateTime.Now,

                Photo = await _fileService.UploadAsync(model.MainPhoto),
            };

            await _fineJewellerAnimationRepository.CreateAsync(fineJewellerAnimation);
            return true;
        }

        public async Task<FineJewellerAnimationUpdateVM> GetUpdateModelAsync(int id)
        {


            var fineJewellerAnimation = await _fineJewellerAnimationRepository.GetAsync(id);

            if (fineJewellerAnimation == null) return null;

            var model = new FineJewellerAnimationUpdateVM
            {
                Id = fineJewellerAnimation.Id,
                Title = fineJewellerAnimation.Title,
                MainPhotoName = fineJewellerAnimation.Photo,

            };

            return model;

        }


        public async Task<bool> UpdateAsync(FineJewellerAnimationUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _fineJewellerAnimationRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This title already exist");
                return false;
            }
            if (model.MainPhoto != null)
            {
                if (!_fileService.IsImage(model.MainPhoto))
                {
                    _modelState.AddModelError("MainPhoto", "file isnt image format!");
                    return false;
                }
                if (!_fileService.CheckSize(model.MainPhoto, 1800))
                {
                    _modelState.AddModelError("MainPhoto", "File more than 1800kb");
                    return false;
                }
            }

            var fineJewellerAnimation = await _fineJewellerAnimationRepository.GetAsync(model.Id);




            if (fineJewellerAnimation != null)
            {
                fineJewellerAnimation.Id = model.Id;
                fineJewellerAnimation.Title = model.Title;
                fineJewellerAnimation.ModifiedAt = DateTime.Now;



                if (model.MainPhoto != null)
                {
                    fineJewellerAnimation.Photo = await _fileService.UploadAsync(model.MainPhoto);
                }

                await _fineJewellerAnimationRepository.UpdateAsync(fineJewellerAnimation);

            }
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var fineJewellerAnimation = await _fineJewellerAnimationRepository.GetAsync(id);
            if (fineJewellerAnimation != null)
            {
                _fileService.Delete(fineJewellerAnimation.Photo);




                await _fineJewellerAnimationRepository.DeleteAsync(fineJewellerAnimation);

                return true;

            }

            return false;
        }


        #endregion
    }
}
