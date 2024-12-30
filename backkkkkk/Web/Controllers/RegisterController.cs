using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
