using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FaqPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
