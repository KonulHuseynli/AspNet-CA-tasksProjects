using Web.Areas.Admin.ViewModels.HomeAnimation;

namespace Web.Areas.Admin.Services.Abstract
{
  
    public interface IHomeAnimationService
    {
        Task<HomeAnimationIndexVM> GetAsync();

        Task<bool> CreateAsync(HomeAnimationCreateVM model);
        Task<HomeAnimationUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(HomeAnimationUpdateVM model);
        Task<bool> DeleteAsync(int id);
    }
}
