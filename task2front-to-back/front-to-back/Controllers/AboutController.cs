using front_to_back.Models;
using front_to_back.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace front_to_back.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var categoryComponents = new List<CategoryComponent>
            {
new CategoryComponent{Title="Our Vision",Text=" Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse commodo viverra.",FilePath="display-4 bx bxs-bulb text-light"},
new CategoryComponent{Title="Our Mission",Text=" Eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam quis.",FilePath="display-4 bx bx-revision text-light"},
new CategoryComponent{Title="Our Goal",Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit,sed do eiusmod tempor.",FilePath="display-4 bx bxs-select-multiple text-light"}

            };
            var model = new HomeIndexViewModel
            {
                CategoryComponents = categoryComponents
            };
            return View(model);
        }
    }
}
