using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamMemberController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment) 
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model = new TeamMemberIndexViewModel
            {
                teamMembers = await _appDbContext.TeamMembers.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if(!ModelState.IsValid) return View(teamMember);

            if (!teamMember.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "This file is not image format");
                return View(teamMember);
            }

            if(teamMember.Photo.Length / 1024 > 80)
            {
                ModelState.AddModelError("Photo", "File's length must be less than 80");
                return View(teamMember);
            }

            var fileName = $"{Guid.NewGuid()}_{teamMember.Photo.FileName}";

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await teamMember.Photo.CopyToAsync(fileStream);
            }
            teamMember.PhotoPath = fileName;
            await _appDbContext.TeamMembers.AddAsync(teamMember);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var teamMember = await _appDbContext.TeamMembers.FindAsync(id);

            if (teamMember == null) return NotFound();

            return View(teamMember);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteComponent(int id)
        {
            var teamMember = await _appDbContext.TeamMembers.FindAsync(id);

            if (teamMember == null) return NotFound();

            return View(teamMember);
        }
    }
}
