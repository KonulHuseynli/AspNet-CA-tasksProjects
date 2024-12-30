using Web.Areas.Admin.ViewModels.FJProduct;
using Web.Areas.Admin.ViewModels.Product;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IFJProductService
    {
        Task<FJProductIndexVM> GetAllAsync();
        Task<bool> CreateAsync(FJProductCreateVM model);
        Task<bool> UpdateAsync(FJProductUpdateVM model);
        Task<bool> DeleteAsync(int id);
        Task<FJProductUpdateVM> GetUpdateModelAsync(int id);
    }
}
