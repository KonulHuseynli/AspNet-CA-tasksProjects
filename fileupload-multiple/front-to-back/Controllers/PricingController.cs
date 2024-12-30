using front_to_back.DAL;
using front_to_back.ViewModels.Pricing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PricingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new PricingIndexViewModel
            {
                PricingComponents = await _appDbContext.PricingComponents.OrderByDescending(prc => prc.Id).Take(3).ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> LoadMore(int skipRowSecond)
        {
            var pricingComponent = await _appDbContext.PricingComponents.OrderByDescending(prc => prc.Id).Skip(3 * skipRowSecond).Take(1).ToListAsync();
            return PartialView("_PricingComponentPartial", pricingComponent);

        }
    }
}