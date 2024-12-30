using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DoctorSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
