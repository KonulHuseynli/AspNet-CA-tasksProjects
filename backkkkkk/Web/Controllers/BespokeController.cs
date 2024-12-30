using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;

namespace Web.Controllers
{
    public class BespokeController : Controller
    {

        private readonly IBespokeService _bespokeService;

        public BespokeController(IBespokeService bespokeService)
        {
            _bespokeService = bespokeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _bespokeService.GetAllAsync();
            return View(model);
        }

    }
}
