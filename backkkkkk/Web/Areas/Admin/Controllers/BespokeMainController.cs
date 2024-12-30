using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class BespokeMainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
