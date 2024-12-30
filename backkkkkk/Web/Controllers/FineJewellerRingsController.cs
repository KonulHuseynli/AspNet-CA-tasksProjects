using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FineJewellerRingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
