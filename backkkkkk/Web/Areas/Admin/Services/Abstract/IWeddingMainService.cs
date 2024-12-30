using Web.Areas.Admin.ViewModels.FJProduct;
using Web.Areas.Admin.ViewModels.WeddingMain;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IWeddingMainService
    {
        Task<WeddingMainIndexVM> GetAllAsync();
        Task<bool> CreateAsync(WeddingMainCreateVM model);
        Task<bool> UpdateAsync(WeddingMainUpdateVM model);
        Task<bool> DeleteAsync(int id);
        Task<WeddingMainUpdateVM> GetUpdateModelAsync(int id);
    }

}
