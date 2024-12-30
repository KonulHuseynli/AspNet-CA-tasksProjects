using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;

namespace Web.Controllers
{
        public class HighJewellerController : Controller
        {
            private readonly IHighJewellerService _highJewellerService;

            public HighJewellerController(IHighJewellerService highJewellerService)
            {
            _highJewellerService = highJewellerService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _highJewellerService.GetAllAsync();
                return View(model);
            }
        }
    
}
