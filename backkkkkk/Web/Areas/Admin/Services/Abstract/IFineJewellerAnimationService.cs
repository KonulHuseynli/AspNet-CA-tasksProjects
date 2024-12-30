using Web.Areas.Admin.ViewModels.FineJewellerAnimation;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IFineJewellerAnimationService
    {
        Task<FineJewellerAnimationIndexVM> GetAllAsync();
        Task<bool> CreateAsync(FineJewellerAnimationCreateVM model);
        Task<FineJewellerAnimationUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(FineJewellerAnimationUpdateVM model);
        Task<bool> DeleteAsync(int id);
    }
}
