using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.FJProduct;
using Web.Areas.Admin.ViewModels.Product;

namespace Web.Areas.Admin.Services.Concrete
{
 
    public class FJProductService : IFJProductService
    {
        private readonly IFJProductRepository _fJProductRepository;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;
        public FJProductService(IFJProductRepository fJProductRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _fJProductRepository = fJProductRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<bool> CreateAsync(FJProductCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _fJProductRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
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



            var product = new FJProducts
            {
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto)


            };

            await _fJProductRepository.CreateAsync(product);

            return true;
        }



        public async Task<bool> UpdateAsync(FJProductUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _fJProductRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
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

            var product = await _fJProductRepository.GetAsync(model.Id);
            if (product != null)
            {
                product.Title = model.Title;
                product.ModifiedAt = DateTime.Now;
                product.Description = model.Description;

                if (model.MainPhoto != null)
                {
                    product.PhotoName = await _fileService.UploadAsync(model.MainPhoto);
                }
                await _fJProductRepository.UpdateAsync(product);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _fJProductRepository.GetAsync(id);
            if (product != null)
            {
                _fileService.Delete(product.PhotoName);
                await _fJProductRepository.DeleteAsync(product);

                return true;
            }
            return false;
        }
        public async Task<FJProductIndexVM> GetAllAsync()
        {
            var model = new FJProductIndexVM
            {
                FJProducts = await _fJProductRepository.GetAllAsync()
            };
            return model;

        }
        public async Task<FJProductUpdateVM> GetUpdateModelAsync(int id)
        {


            var product = await _fJProductRepository.GetAsync(id);

            if (product == null) return null;

            var model = new FJProductUpdateVM
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                MainPhotoPath = product.PhotoName,

            };

            return model;

        }


    }
}
