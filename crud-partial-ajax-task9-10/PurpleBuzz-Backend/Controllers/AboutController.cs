using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_Backend.Models;
using PurpleBuzz_Backend.ViewModels.About;

namespace PurpleBuzz_Backend.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var strategyComponents = new List<StrategyComponent>
            {
                new StrategyComponent{Title="Our vision",Text="Our vision text",FilePath="display-4 bx bxs-bulb text-light"},
                new StrategyComponent{Title="Our mission",Text="Our mission text",FilePath="display-4 bx bx-revision text-light"},
                new StrategyComponent{Title="Our goal",Text="Our goal text",FilePath="display-4 bx bxs-select-multiple text-light"}
            };
            var model = new AboutIndexViewModel
            {
                StrategyComponents = strategyComponents
            };
            return View(model);
        }
    }
}
