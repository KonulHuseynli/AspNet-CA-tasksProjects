using Web.Areas.Admin.ViewModels.WeddingMain;
using Web.ViewModels.FineJeweller;
using Web.ViewModels.Wedding;

namespace Web.Services.Abstract
{
    public interface IWeddingService
    {
        Task<WeddingIndexVM> GetAllAsync();

    }
}
