using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Abstract;

using WebApp.ViewModels.HomeMainSlider;
using WebApp.ViewModels.OurVision;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class OurVisionController : Controller
    {
        private readonly IOurVisionService _visionService;
        private readonly IFileService _fileService;

        public OurVisionController(IOurVisionService visionService, IFileService fileService)
        {
            _visionService = visionService;
            _fileService = fileService;
        }
        #region index
        public async Task<IActionResult> Index()
        {
            var model = await _visionService.GetAllAsync();
            return View(model);
        }
        #endregion
        #region create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OurVisionCreateVM model)
        {
            var isSucceeded = await _visionService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Update
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var model = await _visionService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, OurVisionUpdateVM model)
        {

            if (id != model.Id) return NotFound();
            var isSucceeded = await _visionService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _visionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        #endregion

    }
}
