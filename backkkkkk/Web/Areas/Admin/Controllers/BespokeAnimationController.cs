using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeAnimation;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BespokeAnimationController : Controller
    {
        private readonly IBespokeAnimationService _bespokeAnimationService;

        public BespokeAnimationController(IBespokeAnimationService bespokeAnimationService)
        {

            _bespokeAnimationService = bespokeAnimationService;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var model = await _bespokeAnimationService.GetAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bespokeAnimation = await _bespokeAnimationService.GetAsync();

            if (bespokeAnimation.BespokeAnimation != null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BespokeAnimationCreateVM model)
        {


            var isSucceeded = await _bespokeAnimationService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _bespokeAnimationService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, BespokeAnimationUpdateVM model)
        {
            if (id != model.Id) return NotFound();

            var isSucceeded = await _bespokeAnimationService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));

            model = await _bespokeAnimationService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSucceded = await _bespokeAnimationService.DeleteAsync(id);
            if (isSucceded)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

        }

    }
}
