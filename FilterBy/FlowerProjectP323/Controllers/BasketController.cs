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
        public async Task<IActionResult> Index()
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


            List<BasketListItemViewModel> model = new List<BasketListItemViewModel>();

            foreach (var basketProduct in basket)
            {
                var dbProduct = await _context.Products.FindAsync(basketProduct.Id);

                if (dbProduct != null)
                {
                    model.Add(new BasketListItemViewModel
                    {
                        Id = dbProduct.Id,
                        Title = dbProduct.Name,
                        Price = dbProduct.Price,
                        StockQuantity = dbProduct.Quantity,
                        Quantity = basketProduct.Count,
                        PhotoName = dbProduct.MainPhotoName
                    });
                }
            }
            return View(model);
        }

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

        [HttpPost]
        public async Task<IActionResult> UpCount(int id)
        {

            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] == null) return NotFound();

            basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);

            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            var basketProduct = basket.Find(b => b.Id == dbProduct.Id);
            if (basketProduct != null)
            {
                basketProduct.Count++;
            }
            var serializedBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", serializedBasket);


            return Ok();



        }


        [HttpPost]
        public async Task<IActionResult> DownCount(int id)
        {

            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] == null) return NotFound();

            basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);

            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            var basketProduct = basket.Find(b => b.Id == dbProduct.Id);
            if (basketProduct != null)
            {
                basketProduct.Count--;
            }
            var serializedBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", serializedBasket);


            return Ok();



        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] == null) return NotFound();

            basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);

            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            var basketProduct = basket.Find(b => b.Id == dbProduct.Id);
            if (basketProduct != null)
            {
                basket.Remove(basketProduct);
            }
            var serializedBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", serializedBasket);


            return Ok();

        }



    }
}