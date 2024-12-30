using Microsoft.AspNetCore.Mvc;

namespace FlowerProjectP323.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


            public IActionResult Details()
            {
                return View();
            }
    }
}