using Microsoft.AspNetCore.Mvc;

namespace FlowerProjectP323.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
