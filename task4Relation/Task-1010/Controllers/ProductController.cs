using Task_1010.DAL;
using Task_1010.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Task_1010.Controllers
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
            var product = await _appDbContext.Product.Include(x => x.ProductComponents).ToListAsync();
            var model = new ProductIndexViewModel
            {
                Product = product
            };
            return View(model);
        }
    }
}

