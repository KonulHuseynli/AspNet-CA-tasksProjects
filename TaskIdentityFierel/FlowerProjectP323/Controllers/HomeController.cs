using FlowerProjectP323.DAL;
using FlowerProjectP323.ViewModel.Home;
using Microsoft.AspNetCore.Mvc;

namespace FlowerProjectP323.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
        
            return View();
        }
    }
}
