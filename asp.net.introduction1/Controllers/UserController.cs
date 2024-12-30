using Microsoft.AspNetCore.Mvc;

namespace p323._2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Konul";
            ViewBag.SurName = "Huseynli";
            ViewBag.Age = "19";
            ViewData["Country"] = "Azerbaijan";
            ViewData["Phone Number"] = "051-676-75-66";
            return View();
        }
    }
}
