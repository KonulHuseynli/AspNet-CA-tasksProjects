using Web.Areas.Admin.ViewModels.BespokeInform;
using Web.Areas.Admin.ViewModels.Product;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductIndexVM> GetAllAsync();
        Task<bool> CreateAsync(ProductCreateVM model);
        Task<bool> UpdateAsync(ProductUpdateVM model);
        Task<bool> DeleteAsync(int id);
        Task<ProductUpdateVM> GetUpdateModelAsync(int id);

    }
}
