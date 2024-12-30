using Microsoft.AspNetCore.Mvc;

namespace p323._2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
