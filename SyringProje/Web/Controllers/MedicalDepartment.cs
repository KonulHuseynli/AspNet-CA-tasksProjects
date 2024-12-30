using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MedicalDepartment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
