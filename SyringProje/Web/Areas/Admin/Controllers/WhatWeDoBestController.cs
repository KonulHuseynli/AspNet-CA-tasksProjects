using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Abstract;
using WebApp.ViewModels.OurVision;
using WebApp.ViewModels.WhatWeDoBest;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class WhatWeDoBestController : Controller
    {
        private readonly IWhatWeDoBestService _needService;
        private readonly IFileService _fileService;

        public WhatWeDoBestController(IWhatWeDoBestService needService, IFileService fileService)
        {
            _needService = needService;
            _fileService = fileService;
        }
        #region index
        public async Task<IActionResult> Index()
        {
            var model = await _needService.GetAllAsync();
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
        public async Task<IActionResult> Create(WhatWeDoBestCreateVM model)
        {
            var isSucceeded = await _needService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Update
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var model = await _needService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, WhatWeDoBestUpdateVM model)
        {

            if (id != model.Id) return NotFound();
            var isSucceeded = await _needService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _needService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
