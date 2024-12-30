using WebApp.ViewModels.Doctor;
namespace WebApp.Services.Abstract
{
    public interface IDoctorService
    {
        Task<DoctorIndexVM> GetAllAsync();
        Task<bool> CreateAsync(DoctorCreateVM model);

        Task<DoctorUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(DoctorUpdateVM model);
        Task DeleteAsync(int id);
    }
}
