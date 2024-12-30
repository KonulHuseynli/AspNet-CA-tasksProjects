using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Services.Abstract;
using Web.ViewModels.Home;

namespace Web.Services.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IHomeAnimationRepository _homeAnimationRepository;
        private readonly IHomeSliderRepository _homeSliderRepository;

        public HomeService(IHomeAnimationRepository homeAnimationRepository,IHomeSliderRepository homeSliderRepository)
        {
            _homeAnimationRepository = homeAnimationRepository;
            _homeSliderRepository = homeSliderRepository;
        }

        public async Task<HomeIndexVM> GetAllAsync()
        {
            var model = new HomeIndexVM
            {

                homeAnimation = await _homeAnimationRepository.GetAsync(),
                homeSliders=await _homeSliderRepository.GetAllAsync(),
            };
            return model;

        }
    }
}
