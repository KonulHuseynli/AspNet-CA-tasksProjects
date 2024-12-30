using front_to_back.Areas.Admin.ViewModels;
using front_to_back.Areas.Admin.ViewModels.TeamMember;
using front_to_back.DAL;
using front_to_back.Helpers;
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
        private readonly IFileService _fileService;

        public TeamMemberController(AppDbContext appDbContext,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TeamMemberIndexViewModel
            {
                TeamMembers = await _appDbContext.TeamMembers.ToListAsync()
            };

            return View(model);
        }

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (!ModelState.IsValid) return View(teamMember);

            if (!_fileService.IsImage(teamMember.Photo))
            {
                ModelState.AddModelError("Photo", "Yüklənən fayl image formatında olmalıdır.");
                return View(teamMember);
            }

            int maxSize = 100;

            if (!_fileService.CheckSize(teamMember.Photo, maxSize))
            {
                ModelState.AddModelError("Photo", $"Şəkilin ölçüsü {maxSize} kb-dan böyükdür");
                return View(teamMember);
            }

            teamMember.PhotoPath = await _fileService.UploadAsync(teamMember.Photo, _webHostEnvironment.WebRootPath);

            await _appDbContext.TeamMembers.AddAsync(teamMember);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        #endregion

        #region Update

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var teamMember = await _appDbContext.TeamMembers.FindAsync(id);
            if (teamMember == null) return NotFound();

            var model = new TeamMemberUpdateViewModel
            {
                Id = teamMember.Id,
                Name = teamMember.Name,
                Surname = teamMember.Surname,
                Position = teamMember.Position,
                PhotoPath = teamMember.PhotoPath
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TeamMemberUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (id != model.Id) return BadRequest();

            var teamMember = await _appDbContext.TeamMembers.FindAsync(model.Id);
            if (teamMember is null) return NotFound();

            teamMember.Name = model.Name;
            teamMember.Surname = model.Surname;
            teamMember.Position = model.Position;

            if (model.Photo != null)
            {
                _fileService.Delete(_webHostEnvironment.WebRootPath, teamMember.PhotoPath);
                teamMember.PhotoPath = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath);
            }

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }

        #endregion

        #region Delete

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
            var teamMember = await _appDbContext.TeamMembers.FirstOrDefaultAsync(tm => tm.Id == id);
            if (teamMember == null) return NotFound();

            _fileService.Delete(_webHostEnvironment.WebRootPath, teamMember.PhotoPath);

            _appDbContext.TeamMembers.Remove(teamMember);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        #endregion
    }
}
