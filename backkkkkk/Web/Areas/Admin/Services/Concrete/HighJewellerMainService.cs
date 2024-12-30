using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HighJewellerMain;

namespace Web.Areas.Admin.Services.Concrete
{
    public class HighJewellerMainService:IHighJewellerMainService
    {
        private readonly IHighJewellerMainRepository _highJewellerMainRepository;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;
        public HighJewellerMainService(IHighJewellerMainRepository highJewellerMainRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _highJewellerMainRepository = highJewellerMainRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<bool> CreateAsync(HighJewellerMainCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _highJewellerMainRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
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



            var jeweller = new HighJewellerMain
            {
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto)


            };

            await _highJewellerMainRepository.CreateAsync(jeweller);

            return true;
        }



        public async Task<bool> UpdateAsync(HighJewellerMainUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _highJewellerMainRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
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

            var jeweller = await _highJewellerMainRepository.GetAsync(model.Id);
            if (jeweller != null)
            {
                jeweller.Title = model.Title;
                jeweller.ModifiedAt = DateTime.Now;
                jeweller.Description = model.Description;

                if (model.MainPhoto != null)
                {
                    jeweller.PhotoName = await _fileService.UploadAsync(model.MainPhoto);
                }
                await _highJewellerMainRepository.UpdateAsync(jeweller);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _highJewellerMainRepository.GetAsync(id);
            if (product != null)
            {
                _fileService.Delete(product.PhotoName);
                await _highJewellerMainRepository.DeleteAsync(product);

                return true;
            }
            return false;
        }
        public async Task<HighJewellerMainIndexVM> GetAllAsync()
        {
            var model = new HighJewellerMainIndexVM
            {
                HighJewellerMains = await _highJewellerMainRepository.GetAllAsync()
            };
            return model;

        }
        public async Task<HighJewellerMainUpdateVM> GetUpdateModelAsync(int id)
        {


            var jeweller = await _highJewellerMainRepository.GetAsync(id);

            if (jeweller == null) return null;

            var model = new HighJewellerMainUpdateVM
            {
                Id = jeweller.Id,
                Title = jeweller.Title,
                Description = jeweller.Description,
                MainPhotoPath = jeweller.PhotoName,

            };

            return model;

        }


    }
}

