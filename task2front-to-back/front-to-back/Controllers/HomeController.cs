using front_to_back.Models;
using front_to_back.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace front_to_back.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var projectComponents = new List<ProjectComponent>
            {
new ProjectComponent{Title="UX/UI design",Text="UI/UX design text",FilePath="/assets/img/services-01.jpg"},
new ProjectComponent{Title="Social Media",Text="Social Media text",FilePath="/assets/img/services-02.jpg"},
new ProjectComponent{Title="Marketing",Text="Marketing text",FilePath="/assets/img/services-03.jpg"},
new ProjectComponent{Title="Graphic",Text="Graphic text",FilePath="/assets/img/services-04.jpg"}

            };
            var model = new HomeIndexViewModel
            {
                 ProjectComponents = projectComponents
            };
            return View(model);
        }
    }
}
