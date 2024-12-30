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
    public class FJProductRepository : Repository<FJProducts>, IFJProductRepository
    {
        private readonly AppDbContext _context;

        public FJProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            return product;
        }
    }
}
