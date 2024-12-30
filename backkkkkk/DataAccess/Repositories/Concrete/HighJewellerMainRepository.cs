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
  
    public class HighJewellerMainRepository : Repository<HighJewellerMain>, IHighJewellerMainRepository
    {
        private readonly AppDbContext _context;

        public HighJewellerMainRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<HighJewellerMain> GetProduct(int jewellerId)
        {
            var jeweller = await _context.highJewellerMains.FirstOrDefaultAsync(p => p.Id == jewellerId);

            return jeweller;
        }
    }
}
