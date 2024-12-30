using DataAccess.Repositories.Abstract;
using Web.Services.Abstract;
using Web.ViewModels.FineJeweller;

namespace Web.Services.Concrete
{
    public class FineJewellerService:IFineJewellerService
    {
        private readonly IFineJewellerAnimationRepository _fineJewellerAnimationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFJProductRepository _fJProductRepository;

        public FineJewellerService(IFineJewellerAnimationRepository fineJewellerAnimationRepository, IProductRepository productRepository,IFJProductRepository fJProductRepository)
        {
            _fineJewellerAnimationRepository = fineJewellerAnimationRepository;
            _productRepository = productRepository;
            _fJProductRepository = fJProductRepository;
        }

        public async Task<FineJewellerIndexVM> GetAllAsync()
        {
            var model = new FineJewellerIndexVM
            {
                fineJewellerAnimations = await _fineJewellerAnimationRepository.GetAllAsync(),
                products = await _productRepository.GetAllAsync(),
                FJProducts=await _fJProductRepository.GetAllAsync(),    
                
            };
            return model;

        }
    }
}
