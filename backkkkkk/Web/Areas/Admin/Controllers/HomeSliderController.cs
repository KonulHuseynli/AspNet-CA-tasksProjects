using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HomeSlider;

namespace Web.Areas.Admin.Controllers
{
     [Area("Admin")]
        public class HomeSliderController : Controller
        {
            private readonly IHomeSliderService _homeSliderService;

            public HomeSliderController(IHomeSliderService homeSliderService)
            {

            _homeSliderService = homeSliderService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _homeSliderService.GetAllAsync();
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> Create(HomeSliderCreateVM model)
            {
                var isSucceeded = await _homeSliderService.CreateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                var model = await _homeSliderService.GetUpdateModelAsync(id);
                if (model == null) return NotFound();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Update(int id, HomeSliderUpdateVM model)
            {
                if (id != model.Id) return NotFound();

                var isSucceeded = await _homeSliderService.UpdateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));

                model = await _homeSliderService.GetUpdateModelAsync(id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceded = await _homeSliderService.DeleteAsync(id);
                if (isSucceded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();


            }
        }
    }
