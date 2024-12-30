using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactIntroComponentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactIntroComponentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async  Task<IActionResult> Index()
        {
            var model = new ContactIntroComponentViewModel
            {
                ContractIntroComponent = await _appDbContext.ContractIntroComponent.FirstOrDefaultAsync() 
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create() {
             
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContractIntroComponent contractIntroComponent)
        {
            if (!ModelState.IsValid) return View(contractIntroComponent);


            await _appDbContext.ContractIntroComponent.AddAsync(contractIntroComponent);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
