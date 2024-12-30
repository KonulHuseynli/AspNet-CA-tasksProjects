using front_to_back.DAL;
using front_to_back.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Components
{
    public class RecentWorkViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public RecentWorkViewComponent(AppDbContext appDbContetx)
        {
            _appDbContext = appDbContetx;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HomeIndexViewModel
            {
                RecentWorkComponents = await _appDbContext.RecentWorkComponents.ToListAsync()
            };

            return View(model);
        
        }
    }
}
