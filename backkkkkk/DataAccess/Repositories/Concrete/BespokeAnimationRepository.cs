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
    public class BespokeAnimationRepository : Repository<BespokeAnimation>, IBespokeAnimationRepository
    {
        private readonly AppDbContext _context;

        public BespokeAnimationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<BespokeAnimation> GetAsync()
        {
            return await _context.BespokeAnimations.FirstOrDefaultAsync();
        }
    }
}
