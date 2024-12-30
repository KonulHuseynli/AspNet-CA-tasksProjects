using Web.Areas.Admin.ViewModels.HighJewellerMain;
using Web.Areas.Admin.ViewModels.WeddingMain;
using Web.ViewModels.HighJeweller;

namespace Web.Services.Abstract
{
    public interface IHighJewellerService
    {
        Task<HighJewellerIndexVM> GetAllAsync();

    }
}
