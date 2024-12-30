using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SideBarLeft : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
