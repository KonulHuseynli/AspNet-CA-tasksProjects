using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.FJProduct;

namespace Web.Areas.Admin.Controllers
{
  

        [Area("Admin")]
        public class FJProductController : Controller
        {
            private readonly IFJProductService _fJProductService;

            public FJProductController(IFJProductService fJProductService)
            {

            _fJProductService = fJProductService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _fJProductService.GetAllAsync();
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> Create(FJProductCreateVM model)
            {
                var isSucceeded = await _fJProductService.CreateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                var model = await _fJProductService.GetUpdateModelAsync(id);
                if (model == null) return NotFound();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Update(int id, FJProductUpdateVM model)
            {
                if (id != model.Id) return NotFound();

                var isSucceeded = await _fJProductService.UpdateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));

                model = await _fJProductService.GetUpdateModelAsync(id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceded = await _fJProductService.DeleteAsync(id);
                if (isSucceded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();


            }
        }
    }

