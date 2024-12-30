using Core.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Category;


namespace WebApp.Services.Concrete
{
    public class CategoryService :ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ModelStateDictionary _modelState;

        public CategoryService(ICategoryRepository categoryRepository,
            IActionContextAccessor actionContextAccessor)
        {
          _categoryRepository = categoryRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public async Task<CategoryIndexVM> GetAllAsync()
        {
            var model = new CategoryIndexVM
            {
                Categories = await _categoryRepository.GetAllAsync()
        };
            return model;
           
        }
        public async Task<bool> CreateAsync(CategoryCreateVM model)
        {
         var isExist=   await _categoryRepository.AnyAsync(c=>c.Title.Trim().ToLower() ==model.Title.Trim().ToLower());
            if (isExist) {
                _modelState.AddModelError("Title", "This category already is exist");
                return false;
            }
            var category = new Category
            {
                Title = model.Title,
                CreatedAt= DateTime.Now   
            };
           await  _categoryRepository.CreateAsync(category);
            return true;
        }

        public async  Task<CategoryUpdateVM> GetUpdateModelAsync(int id)
        {
          var category= await _categoryRepository.GetAsync(id);
   
            if (category != null)
            {
                var model = new CategoryUpdateVM
                {
                    Id = category.Id,
                    Title = category.Title
                };
                return model;

            }return null;
            
        }

        public async Task<bool> UpdateAsync(CategoryUpdateVM model)
        {
            var isExist = await _categoryRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This category already is exist");
                return false;
            }
            var category = await _categoryRepository.GetAsync(model.Id);
            if (category == null) return false;

            category.Title = model.Title;
            category.ModifiedAt = DateTime.Now;
            await _categoryRepository.UpdateAsync(category);

            return true;
        }

        public async  Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if(category != null)
            {
                await _categoryRepository.DeleteAsync(category);    
            }
        }

   
    }
}
