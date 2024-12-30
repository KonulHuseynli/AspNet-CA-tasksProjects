using DataAccess.Repositories.Abstract;
using Web.Services.Abstract;
using Web.ViewModels.HighJeweller;
using Web.ViewModels.Wedding;

namespace Web.Services.Concrete
{
   
    public class WeddingService : IWeddingService
    {
        private readonly IWeddingMainRepository _weddingMainRepository;


        public WeddingService(IWeddingMainRepository weddingMainRepository)
        {
            _weddingMainRepository = weddingMainRepository;

        }

        public async Task<WeddingIndexVM> GetAllAsync()
        {
            var model = new WeddingIndexVM
            {
                weddingMains = await _weddingMainRepository.GetAllAsync(),


            };
            return model;

        }

    }
}
