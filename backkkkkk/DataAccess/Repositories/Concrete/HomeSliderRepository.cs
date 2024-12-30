using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{

    public class HomeSliderRepository : Repository<HomeSlider>, IHomeSliderRepository
    {
        private readonly AppDbContext _context;

        public HomeSliderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<HomeSlider> GetHomeSlider(int homesliderId)
        {
            var homeslider = await _context.homeSliders.FirstOrDefaultAsync(p => p.Id == homesliderId);

            return homeslider;
        }
    }
}
