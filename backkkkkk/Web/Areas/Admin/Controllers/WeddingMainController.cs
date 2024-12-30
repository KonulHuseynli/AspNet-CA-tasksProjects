using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HighJewellerMain;
using Web.Areas.Admin.ViewModels.WeddingMain;

namespace Web.Areas.Admin.Controllers
{
 
        [Area("Admin")]
        public class WeddingMainController : Controller
        {
            private readonly IWeddingMainService _weddingMainService;

            public WeddingMainController(IWeddingMainService weddingMainService)
            {

            _weddingMainService = weddingMainService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _weddingMainService.GetAllAsync();
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> Create(WeddingMainCreateVM model)
            {
                var isSucceeded = await _weddingMainService.CreateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                var model = await _weddingMainService.GetUpdateModelAsync(id);
                if (model == null) return NotFound();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Update(int id, WeddingMainUpdateVM model)
            {
                if (id != model.Id) return NotFound();

                var isSucceeded = await _weddingMainService.UpdateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));

                model = await _weddingMainService.GetUpdateModelAsync(id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceded = await _weddingMainService.DeleteAsync(id);
                if (isSucceded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();


            }
        }
    }
