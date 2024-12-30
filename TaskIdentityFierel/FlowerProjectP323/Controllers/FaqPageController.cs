using Microsoft.AspNetCore.Mvc;

namespace FlowerProjectP323.Controllers
{
    public class FaqPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
