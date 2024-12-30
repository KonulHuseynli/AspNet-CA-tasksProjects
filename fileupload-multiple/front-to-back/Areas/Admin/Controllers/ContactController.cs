using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ContactIndexViewModel
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
            if (!contactIntroComponent.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File is not in image format ");
                return View(contactIntroComponent);
            }
            if (contactIntroComponent.Photo.Length / 1024 > 60)
            {
                ModelState.AddModelError("Photo", "Image size must be less than 70 kb");
                return View(contactIntroComponent);
            }

            var fileName = $"{Guid.NewGuid()}_{contactIntroComponent.Photo.FileName}";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await contactIntroComponent.Photo.CopyToAsync(fileStream);
            }

            contactIntroComponent.FilePath = fileName;
            await _appDbContext.ContactIntroComponent.AddAsync(contactIntroComponent);


            await _appDbContext.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactBanner = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (contactBanner == null) return NotFound();

            return View(contactBanner);

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
            var dbcontactIntro = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (dbcontactIntro == null) return NotFound();


            _appDbContext.Remove(dbcontactIntro);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var contactIntroComponent = await _appDbContext.ContactIntroComponent.FindAsync(id);

            if (contactIntroComponent == null) return NotFound();
            return View(contactIntroComponent);
        }
        [HttpPost]

        public async Task<IActionResult> Update(int id, ContactIntroComponent contactIntroComponent)
        {
            if (!ModelState.IsValid) return View(contactIntroComponent);
            if (id != contactIntroComponent.Id) return BadRequest();
            var dbcontactIntroComponent = await _appDbContext.ContactIntroComponent.FindAsync(id);
            if (dbcontactIntroComponent == null) return NotFound();


            bool isExist = await _appDbContext.ContactIntroComponent
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == contactIntroComponent.Title.
                                                   ToLower().Trim()
                                                   && c.Id != contactIntroComponent.Id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "This title declared");

                return View(contactIntroComponent);
            }

            dbcontactIntroComponent.Title = contactIntroComponent.Title;
            dbcontactIntroComponent.Description = contactIntroComponent.Description;
            dbcontactIntroComponent.FilePath = contactIntroComponent.FilePath;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}