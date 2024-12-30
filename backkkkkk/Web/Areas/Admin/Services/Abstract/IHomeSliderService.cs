using Web.Areas.Admin.ViewModels.HomeSlider;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IHomeSliderService
    {
        Task<HomeSliderIndexVM> GetAllAsync();
        Task<bool> CreateAsync(HomeSliderCreateVM model);
        Task<bool> UpdateAsync(HomeSliderUpdateVM model);
        Task<bool> DeleteAsync(int id);
        Task<HomeSliderUpdateVM> GetUpdateModelAsync(int id);
    }
}
