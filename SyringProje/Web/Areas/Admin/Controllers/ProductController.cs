using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Product;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileService _fileService;

        public ProductController(IProductService productService, IFileService fileService)
        {
            _productService = productService;
            _fileService = fileService;
        }
        #region index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetAllAsync();
            return View(model);
        }
        #endregion
        #region create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _productService.GetCreateModelAsync();
            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {

            var isSucceeded = await _productService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            
            return View(model);
        }
        #endregion
        #region delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        #endregion
        #region update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _productService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductUpdateVM model)
        {

            if (id != model.Id) return NotFound();
            var isSucceeded = await _productService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            return View(model);

        }
        #endregion

      
       
    }
}

