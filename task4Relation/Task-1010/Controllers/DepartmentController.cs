using Task_1010.DAL;
using Task_1010.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Task_1010.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var departamentServicesComponent = await _appDbContext.DepartmentComponents.ToListAsync();

            var model = new DepartmentIndexViewModel
            {
                DepartmentComponents = departamentServicesComponent
            };
            return View(model);
        }
    }
}
