using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;
using Web.ViewModels.Basket;

namespace Web.Controllers
{
   
        //[Authorize]
        public class BasketController : Controller
        {
            private readonly IBasketService _basketService;

            public BasketController(IBasketService basketService)
            {
                _basketService = basketService;
            }
            [HttpGet]
            public async Task<IActionResult> Index()

            {

                var model = await _basketService.GetAsync();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> AddProduct(BasketAddVm model)
            {
                var isSucceeded = await _basketService.Add(model);
                if (isSucceeded) return Ok();
                return BadRequest();
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var isSucceeded = await _basketService.DeleteBasketProduct(id);
                if (isSucceeded) return Ok();
                return BadRequest();

            }

            [HttpPost]
            public async Task<IActionResult> UpCountProduct(int id)
            {
                var isSucceeded = await _basketService.UpCount(id);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return BadRequest();

            }

            [HttpPost]
            public async Task<IActionResult> DownCountProduct(int id)
            {
                var isSucceeded = await _basketService.DownCount(id);
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return BadRequest();

            }

            [HttpPost]
            public async Task<IActionResult> Clear()
            {
                var isSucceeded = await _basketService.ClearBasketProduct();
                if (isSucceeded) return RedirectToAction(nameof(Index));
                return BadRequest();

            }


            [HttpGet]
            public async Task<IActionResult> MiniBasket()
            {
                var model = await _basketService.GetAsync();

                return PartialView("_MiniBasketPartial", model);

            }
        }
}
