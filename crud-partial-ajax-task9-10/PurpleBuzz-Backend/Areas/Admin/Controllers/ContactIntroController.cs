using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_Backend.Areas.Admin.ViewModels;
using PurpleBuzz_Backend.DAL;
using PurpleBuzz_Backend.Models;

namespace PurpleBuzz_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactIntroController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactIntroController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ContactIntroIndexViewModel
            {
                ContactIntroComponents = await _appDbContext.ContactIntroComponent.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactIntroComponent contactIntroComponent)
        {
            if (!ModelState.IsValid) return View(contactIntroComponent);
            bool isExist = await _appDbContext.ContactIntroComponent.AnyAsync(c => c.Title.ToLower().Trim() == contactIntroComponent.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "This title is already exist");
                return View(contactIntroComponent);
            }

            await _appDbContext.ContactIntroComponent.AddAsync(contactIntroComponent);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Update (int id)
        {
            var contactIntroComponent = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if(contactIntroComponent == null) return NotFound();
            return View(contactIntroComponent);
        }

        [HttpPost]
        public async Task<IActionResult> Update (int id, ContactIntroComponent contactIntroComponent)
        {
            if (!ModelState.IsValid) return View(contactIntroComponent);
            bool isExist = await _appDbContext.ContactIntroComponent.AnyAsync(c => c.Title.ToLower().Trim() == contactIntroComponent.Title.ToLower().Trim() && c.Id!=contactIntroComponent.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This title is already exist");
                return View(contactIntroComponent);
            }
            if (id != contactIntroComponent.Id) return BadRequest();

            var dbContactIntroComponent= await _appDbContext.ContactIntroComponent.FindAsync(id);
            if(dbContactIntroComponent==null) return NotFound();
            dbContactIntroComponent.Title=contactIntroComponent.Title;
            dbContactIntroComponent.Description=contactIntroComponent.Description;
            dbContactIntroComponent.FilePath=contactIntroComponent.FilePath;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contactIntroComponent = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (contactIntroComponent == null) return NotFound();
            return View(contactIntroComponent);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var contactIntroComponent = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (contactIntroComponent == null) return NotFound();
             _appDbContext.Remove(contactIntroComponent);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactIntroComponent =await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (contactIntroComponent == null) return NotFound();
            return View(contactIntroComponent);
        }
    }
}
