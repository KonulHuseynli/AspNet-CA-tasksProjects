using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.FineJewellerAnimation;

namespace Web.Areas.Admin.Controllers
{
    [Area("admin")]

    public class FineJewellerAnimationController : Controller
    {
      
        private readonly IFineJewellerAnimationService _fineJewellerAnimationService;

        public FineJewellerAnimationController(IFineJewellerAnimationService fineJewellerAnimationService)
        {
            _fineJewellerAnimationService = fineJewellerAnimationService;
        }

        #region OurVision


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _fineJewellerAnimationService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(FineJewellerAnimationCreateVM model)
        {
            var isSucceeded = await _fineJewellerAnimationService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _fineJewellerAnimationService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FineJewellerAnimationUpdateVM model)
        {
            if (id != model.Id) return NotFound();

            var isSucceeded = await _fineJewellerAnimationService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));

            model = await _fineJewellerAnimationService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSucceded = await _fineJewellerAnimationService.DeleteAsync(id);
            if (isSucceded)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

            #endregion
        }
    }
}
