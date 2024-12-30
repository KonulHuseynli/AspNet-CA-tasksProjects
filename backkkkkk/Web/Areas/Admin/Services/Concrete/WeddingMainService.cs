using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HighJewellerMain;
using Web.Areas.Admin.ViewModels.WeddingMain;

namespace Web.Areas.Admin.Services.Concrete
{
    public class WeddingMainService:IWeddingMainService
    {
        private readonly IWeddingMainRepository _weddingMainRepository;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;
        public WeddingMainService(IWeddingMainRepository weddingMainRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _weddingMainRepository = weddingMainRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<bool> CreateAsync(WeddingMainCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _weddingMainRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
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



            var wedding = new WeddingMain
            {
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto)


            };

            await _weddingMainRepository.CreateAsync(wedding);

            return true;
        }



        public async Task<bool> UpdateAsync(WeddingMainUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _weddingMainRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
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

            var wedding = await _weddingMainRepository.GetAsync(model.Id);
            if (wedding != null)
            {
                wedding.Title = model.Title;
                wedding.ModifiedAt = DateTime.Now;
                wedding.Description = model.Description;

                if (model.MainPhoto != null)
                {
                    wedding.PhotoName = await _fileService.UploadAsync(model.MainPhoto);
                }
                await _weddingMainRepository.UpdateAsync(wedding);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wedding = await _weddingMainRepository.GetAsync(id);
            if (wedding != null)
            {
                _fileService.Delete(wedding.PhotoName);
                await _weddingMainRepository.DeleteAsync(wedding);

                return true;
            }
            return false;
        }
        public async Task<WeddingMainIndexVM> GetAllAsync()
        {
            var model = new WeddingMainIndexVM
            {
                WeddingMains = await _weddingMainRepository.GetAllAsync()
            };
            return model;

        }
        public async Task<WeddingMainUpdateVM> GetUpdateModelAsync(int id)
        {


            var wedding = await _weddingMainRepository.GetAsync(id);

            if (wedding == null) return null;

            var model = new WeddingMainUpdateVM
            {
                Id = wedding.Id,
                Title = wedding.Title,
                Description = wedding.Description,
                MainPhotoPath = wedding.PhotoName,

            };

            return model;

        }
    }
}
