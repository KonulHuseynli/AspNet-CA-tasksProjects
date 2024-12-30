using FlowerProjectP323.Areas.Admin.ViewModels.Product;
using FlowerProjectP323.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ProductIndexViewModel
            {
                Products = await _appDbContext.Products
                                    .OrderByDescending(p => p.Id)
                                    .Take(1)
                                    .ToListAsync()

            };
            return View(model);
        }
        public async Task <IActionResult> LoadMore(int skipRow )
        {
            var products = await _appDbContext.Products
                             .OrderByDescending(p => p.Id)
                             //.Skip(1*skipRow)
                              .Take(3)
                             .ToListAsync();
            return PartialView("_ProductPartial", products);
        }
    }
}

