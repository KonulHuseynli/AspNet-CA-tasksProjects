using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeInform;
using Web.Areas.Admin.ViewModels.Product;

namespace Web.Areas.Admin.Services.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;
        public ProductService(IProductRepository productRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<bool> CreateAsync(ProductCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _productRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
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
            if (!_fileService.CheckSize(model.MainPhoto, 300))
            {
                _modelState.AddModelError("MainPhoto", "File olcusu 300 kbdan boyukdur");
                return false;
            }



            var product = new Product
            {
                Title = model.Title,
                CreatedAt = DateTime.Now,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto)


            };

            await _productRepository.CreateAsync(product);

            return true;
        }

        

        public async Task<bool> UpdateAsync(ProductUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _productRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
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
                if (!_fileService.CheckSize(model.MainPhoto, 300))
                {
                    _modelState.AddModelError("MainPhoto", "File olcusu 300 kbdan boyukdur");
                    return false;
                }
            }

            var product = await _productRepository.GetAsync(model.Id);
            if (product != null)
            {
                product.Title = model.Title;
                product.ModifiedAt = DateTime.Now;

                if (model.MainPhoto != null)
                {
                    product.PhotoName = await _fileService.UploadAsync(model.MainPhoto);
                }
                await _productRepository.UpdateAsync(product);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product != null)
            {
                _fileService.Delete(product.PhotoName);
                await _productRepository.DeleteAsync(product);

                return true;
            }
            return false;
        }
        public async Task<ProductIndexVM> GetAllAsync()
        {
            var model = new ProductIndexVM
            {
                Products = await _productRepository.GetAllAsync()
            };
            return model;

        }
        public async Task<ProductUpdateVM> GetUpdateModelAsync(int id)
        {


            var product = await _productRepository.GetAsync(id);

            if (product == null) return null;

            var model = new ProductUpdateVM
            {
                Id = product.Id,
                Title = product.Title,
                MainPhotoPath = product.PhotoName,

            };

            return model;

        }


    }
}
