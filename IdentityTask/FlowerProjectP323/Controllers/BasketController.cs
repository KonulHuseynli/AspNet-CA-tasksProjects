using FlowerProjectP323.DAL;
using FlowerProjectP323.ViewModel.Basket;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace FlowerProjectP323.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        #region index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basketProducts = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);
            List<BasketListItemViewModel> model = new List<BasketListItemViewModel>();
            foreach (var basketProduct in basketProducts)
            {
                var dbProduct = await _context.Products.FindAsync(basketProduct.Id);
                if (dbProduct != null)
                {
                    model.Add(new BasketListItemViewModel
                    {
                        Id = dbProduct.Id,
                        Title = dbProduct.Name,
                        Price = dbProduct.Price,
                        Quantity = basketProduct.Count,
                        StockQuantity = dbProduct.Quantity,
                        PhotoName = dbProduct.MainPhotoName
                    });

                }
            }
            return View(model);
        }
        #endregion
        #region add
        [HttpPost]
        public async Task<IActionResult> Add(BasketAddViewModel model)
        {
            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketAddViewModel>();
            }
            var basketProduct = basket.Find(b => b.Id == model.Id);
            if (basketProduct != null)
            {
                basketProduct.Count++;
            }
            else
            {
                model.Count++;
                basket.Add(model);
            }
            var serializedBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", serializedBasket);
            return Ok();
        }
        #endregion

    }
}
