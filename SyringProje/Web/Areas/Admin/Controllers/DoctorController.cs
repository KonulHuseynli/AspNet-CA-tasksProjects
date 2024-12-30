using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Doctor;
using WebApp.ViewModels.OurVision;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IFileService _fileService;

        public DoctorController(IDoctorService doctorService, IFileService fileService)
        {
            _doctorService = doctorService;
            _fileService = fileService;
        }
        #region index
        public async Task<IActionResult> Index()
        {
            var model = await _doctorService.GetAllAsync();
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
        public async Task<IActionResult> Create(DoctorCreateVM model)
        {
            var isSucceeded = await _doctorService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Update
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var model = await _doctorService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, DoctorUpdateVM model)
        {

            if (id != model.Id) return NotFound();
            var isSucceeded = await _doctorService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        #endregion

    }
}
