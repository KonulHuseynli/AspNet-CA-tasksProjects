using Web.Areas.Admin.ViewModels.FJProduct;
using Web.Areas.Admin.ViewModels.HighJewellerMain;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IHighJewellerMainService
    {
        Task<HighJewellerMainIndexVM> GetAllAsync();
        Task<bool> CreateAsync(HighJewellerMainCreateVM model);
        Task<bool> UpdateAsync(HighJewellerMainUpdateVM model);
        Task<bool> DeleteAsync(int id);
        Task<HighJewellerMainUpdateVM> GetUpdateModelAsync(int id);
    }
}
