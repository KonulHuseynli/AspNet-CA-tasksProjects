using Core.Entities;
using WebApp.ViewModels.Product;

namespace WebApp.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductIndexVM> GetAllAsync();
        Task<bool> CreateAsync(ProductCreateVM model);
        Task<ProductCreateVM>GetCreateModelAsync();   
        Task<ProductUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(ProductUpdateVM model);
        Task DeleteAsync(int id);

    }
}
