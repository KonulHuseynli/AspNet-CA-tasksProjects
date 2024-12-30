using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Services.Abstract;
using Web.ViewModels.Bespoke;
namespace Web.Services.Concrete
{
    public class BespokeService:IBespokeService
    {
        private readonly IBespokeAnimationRepository _bespokeanimationRepository;
        private readonly IBespokeInformRepository _bespokeInformRepository;

        public BespokeService(IBespokeAnimationRepository bespokeAnimationrepository,IBespokeInformRepository bespokeInformRepository)
        {
            _bespokeanimationRepository = bespokeAnimationrepository;
            _bespokeInformRepository = bespokeInformRepository;
        }

        public async Task<BespokeIndexVM> GetAllAsync()
        {
            var model = new BespokeIndexVM
            {

                bespokeAnimation = await _bespokeanimationRepository.GetAsync(),
                bespokeInforms = await _bespokeInformRepository.GetAllAsync()
            };
            return model;

        }

       
    }
}
