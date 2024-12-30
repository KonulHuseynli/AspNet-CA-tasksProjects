using Web.Areas.Admin.ViewModels.BespokeInform;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IBespokeInformService
    {
        Task<BespokeInformIndexVM> GetAllAsync();
        Task<bool> CreateAsync(BespokeInformCreateVM model);
        Task<BespokeInformUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(BespokeInformUpdateVM model);
        Task<bool> DeleteAsync(int id);
    }
}
