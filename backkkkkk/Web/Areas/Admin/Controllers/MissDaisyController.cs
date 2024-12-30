using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class MissDaisyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
