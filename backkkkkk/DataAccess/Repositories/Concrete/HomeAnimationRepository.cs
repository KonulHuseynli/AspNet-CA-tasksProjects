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

    public class HomeAnimationRepository : Repository<HomeAnimation>, IHomeAnimationRepository
    {
        private readonly AppDbContext _context;

        public HomeAnimationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<HomeAnimation> GetAsync()
        {
            return await _context.homeAnimations.FirstOrDefaultAsync();
        }
    }
}
