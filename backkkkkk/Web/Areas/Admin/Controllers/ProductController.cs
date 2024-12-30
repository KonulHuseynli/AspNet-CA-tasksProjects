using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.Services.Concrete;
using Web.Areas.Admin.ViewModels.Product;

namespace Web.Areas.Admin.Controllers
{
 
        [Area("Admin")]
        public class ProductController : Controller
        {
            private readonly IProductService _productService;

            public ProductController(IProductService productService)
            {

                _productService = productService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var model = await _productService.GetAllAsync();
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> Create(ProductCreateVM model)
            {
                var isSucceeded = await _productService.CreateAsync(model);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return View(model);
            }

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

                model = await _productService.GetUpdateModelAsync(id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceded = await _productService.DeleteAsync(id);
                if (isSucceded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();


            }
        }
}
