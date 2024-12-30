using Core.Entities;
using WebApp.ViewModels.Category;

namespace WebApp.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryIndexVM> GetAllAsync();
        Task<bool> CreateAsync(CategoryCreateVM model);
        Task<CategoryUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(CategoryUpdateVM model);   
        Task DeleteAsync(int id);
    }
}
