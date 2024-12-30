using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;

namespace Web.Controllers
{
    public class FineJewellerController : Controller
    {
        private readonly IFineJewellerService _fineJewellerService;

        public FineJewellerController(IFineJewellerService fineJewellerService )
        {
            _fineJewellerService = fineJewellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _fineJewellerService.GetAllAsync();
            return View(model);
        }
    }
}
