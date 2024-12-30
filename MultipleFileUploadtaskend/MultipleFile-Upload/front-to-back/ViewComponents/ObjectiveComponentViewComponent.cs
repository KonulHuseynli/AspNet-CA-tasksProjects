using front_to_back.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.ViewComponents
{
    public class ObjectiveComponentViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public ObjectiveComponentViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var objectiveComponents = await _appDbContext.ObjectiveComponents.ToListAsync();
            return View(objectiveComponents);
        }
    }
}
