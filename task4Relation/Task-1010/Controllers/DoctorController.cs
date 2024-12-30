using Task_1010.DAL;
using Task_1010.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_1010.ViewModels.Department;

namespace Task_1010.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DoctorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var doctorFindComponent = await _appDbContext.DoctorProfilesComponents.ToListAsync();
            var model = new DoctorIndexViewModel
            {
                DoctorProfilesComponents = doctorFindComponent,
            };
            return View(model);
        }
    }
}
