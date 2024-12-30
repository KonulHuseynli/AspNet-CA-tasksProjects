using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FindDoctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
