using FlowerProjectP323.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerProjectP323.ViewComponents
{
	public class FlowerExpertViewComponent :ViewComponent
	{
		private readonly AppDbContext _appDbContext;

		public FlowerExpertViewComponent(AppDbContext appDbContext)
		{
		_appDbContext = appDbContext;
		}
		public async  Task <IViewComponentResult> InvokeAsync()
		{
			var flowerExperts = await _appDbContext.FlowerExperts.ToListAsync();
			return View(flowerExperts);
		}
	}
}
