using WebApp.ViewModels.OurVision;


namespace WebApp.Services.Abstract
{
    public interface IOurVisionService
    {
        Task<OurVisionIndexVM> GetAllAsync();
        Task<bool> CreateAsync(OurVisionCreateVM model);
       
        Task<OurVisionUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(OurVisionUpdateVM model);
        Task DeleteAsync(int id);
    }
}
