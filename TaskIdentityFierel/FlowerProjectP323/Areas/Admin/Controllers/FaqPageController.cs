using FlowerProjectP323.Areas.Admin.ViewModels.FaqPage;
using FlowerProjectP323.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FlowerProjectP323.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqPageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public FaqPageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var  model= new FaqPageIndexViewModel

            return View();
        }
    }
}
