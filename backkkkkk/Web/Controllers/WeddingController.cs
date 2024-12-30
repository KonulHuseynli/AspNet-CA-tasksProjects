using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;

namespace Web.Controllers
{
  
        public class WeddingController : Controller
        {
            private readonly IWeddingService _weddingService;

            public WeddingController(IWeddingService weddingService)
            {
            _weddingService = weddingService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _weddingService.GetAllAsync();
                return View(model);
            }
        
    }
}
