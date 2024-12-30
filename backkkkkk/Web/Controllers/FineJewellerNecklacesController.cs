using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FineJewellerNecklacesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
