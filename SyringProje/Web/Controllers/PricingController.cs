using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
