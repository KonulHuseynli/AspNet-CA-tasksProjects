using Web.ViewModels.Bespoke;
using Web.ViewModels.FineJeweller;

namespace Web.Services.Abstract
{
    public interface IFineJewellerService
    {
        Task<FineJewellerIndexVM> GetAllAsync();

    }
}
