using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HomeAnimation;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAnimationController : Controller
    {
        private readonly IHomeAnimationService _homeAnimationService;

        public HomeAnimationController(IHomeAnimationService homeAnimationService)
        {

            _homeAnimationService = homeAnimationService;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var model = await _homeAnimationService.GetAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bespokeAnimation = await _homeAnimationService.GetAsync();

            if (bespokeAnimation.HomeAnimation != null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeAnimationCreateVM model)
        {


            var isSucceeded = await _homeAnimationService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _homeAnimationService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, HomeAnimationUpdateVM model)
        {
            if (id != model.Id) return NotFound();

            var isSucceeded = await _homeAnimationService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));

            model = await _homeAnimationService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSucceded = await _homeAnimationService.DeleteAsync(id);
            if (isSucceded)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

        }

    }
}
