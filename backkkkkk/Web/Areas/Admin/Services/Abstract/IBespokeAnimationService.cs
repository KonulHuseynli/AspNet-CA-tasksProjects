using Web.Areas.Admin.ViewModels.BespokeAnimation;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IBespokeAnimationService
    {
        Task<BespokeAnimationIndexVM> GetAsync();

        Task<bool> CreateAsync(BespokeAnimationCreateVM model);
        Task<BespokeAnimationUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(BespokeAnimationUpdateVM model);
        Task<bool> DeleteAsync(int id);
    }
}
