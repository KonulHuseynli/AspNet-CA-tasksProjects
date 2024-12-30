using DataAccess.Repositories.Abstract;
using Web.Areas.Admin.ViewModels.HighJewellerMain;
using Web.Services.Abstract;
using Web.ViewModels.FineJeweller;
using Web.ViewModels.HighJeweller;

namespace Web.Services.Concrete
{

    public class HighJewellerService : IHighJewellerService
    {
        private readonly IHighJewellerMainRepository _highJewellerMainRepository;


        public HighJewellerService( IHighJewellerMainRepository highJewellerMainRepository )
        {
            _highJewellerMainRepository = highJewellerMainRepository;
   
        }

        public async Task<HighJewellerIndexVM> GetAllAsync()
        {
            var model = new HighJewellerIndexVM
            {
                highJewellerMains = await _highJewellerMainRepository.GetAllAsync(),
          

            };
            return model;

        }

    }
}
