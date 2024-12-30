using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_Backend.DAL;
using PurpleBuzz_Backend.ViewModels.Pricing;

namespace PurpleBuzz_Backend.Controllers
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
                pricingComponents = await _appDbContext.PricingComponents
                                                                .OrderByDescending(rwc => rwc.Id)
                                                                .Take(3)
                                                                .ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> loadMore(int skipRow)
        {

            var pricingComponents = await _appDbContext.PricingComponents
                                                            .OrderByDescending(rwc => rwc.Id)
                                                            .Skip(skipRow + 3)
                                                            .Take(1)
                                                            .ToListAsync();
            return PartialView("_PricingComponentPartial", pricingComponents);
        }

    }
}