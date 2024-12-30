using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
