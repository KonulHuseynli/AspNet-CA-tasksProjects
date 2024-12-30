using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.FJProduct;
using Web.Areas.Admin.ViewModels.HighJewellerMain;

namespace Web.Areas.Admin.Controllers
{


        [Area("Admin")]
        public class HighJewellerMainController : Controller
        {
            private readonly IHighJewellerMainService _highJewellerMainService;

            public HighJewellerMainController(IHighJewellerMainService highJewellerMainService)
            {

            _highJewellerMainService = highJewellerMainService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _highJewellerMainService.GetAllAsync();
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> Create(HighJewellerMainCreateVM model)
            {
                var isSucceeded = await _highJewellerMainService.CreateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                var model = await _highJewellerMainService.GetUpdateModelAsync(id);
                if (model == null) return NotFound();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Update(int id, HighJewellerMainUpdateVM model)
            {
                if (id != model.Id) return NotFound();

                var isSucceeded = await _highJewellerMainService.UpdateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));

                model = await _highJewellerMainService.GetUpdateModelAsync(id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceded = await _highJewellerMainService.DeleteAsync(id);
                if (isSucceded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();


            }
        }
    }

