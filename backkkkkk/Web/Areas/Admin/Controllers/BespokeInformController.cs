using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeInform;

namespace Web.Areas.Admin.Controllers
{

    [Area("admin")]
    public class BespokeInformController : Controller
    {
        private readonly IBespokeInformService _bespokeInformService;

        public BespokeInformController(IBespokeInformService bespokeInformService)
        {
            _bespokeInformService = bespokeInformService;
        }

        #region OurVision


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _bespokeInformService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BespokeInformCreateVM model)
        {
            var isSucceeded = await _bespokeInformService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _bespokeInformService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, BespokeInformUpdateVM model)
        {
            if (id != model.Id) return NotFound();

            var isSucceeded = await _bespokeInformService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));

            model = await _bespokeInformService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSucceded = await _bespokeInformService.DeleteAsync(id);
            if (isSucceded)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

            #endregion
        }
    }
}
