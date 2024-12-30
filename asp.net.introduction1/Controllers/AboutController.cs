using Microsoft.AspNetCore.Mvc;

namespace p323._2.Controllers
{
    public class AboutController:Controller

    {
        public IActionResult Index()
        {
            ViewBag.Name = "Konul";
            ViewBag.SurName = "Huseynli";
            return View();
        }
       /* public int ShowId(int id)
        {
            return id;
        }*/

        }
    }

