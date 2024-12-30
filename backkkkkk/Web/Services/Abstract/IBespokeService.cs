using Web.ViewModels.Bespoke;

namespace Web.Services.Abstract
{
    public interface IBespokeService
    {
        Task<BespokeIndexVM> GetAllAsync();

    }
}
