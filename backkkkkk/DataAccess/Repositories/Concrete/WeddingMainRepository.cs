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
  
    public class WeddingMainRepository : Repository<WeddingMain>, IWeddingMainRepository
    {
        private readonly AppDbContext _context;

        public WeddingMainRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<WeddingMain> GetProduct(int weddingId)
        {
            var weddingmains = await _context.weddingMains.FirstOrDefaultAsync(p => p.Id == weddingId);

            return weddingmains;
        }
    }
}
