using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class BasketProductRepository : Repository<BasketProduct>, IBasketProductRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public BasketProductRepository(AppDbContext context, UserManager<User> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<BasketProduct> GetBasketProduct(int productId, int basketId)
        {
            var basketProduct = await _context.basketProducts.FirstOrDefaultAsync(bp => bp.ProductId == productId && bp.BasketId == basketId);

            return basketProduct;
        }

        public async Task<List<BasketProduct>> GetAllBasketProduct(int basketId)
        {
            var basketProduct = await _context.basketProducts.Where(b => b.BasketId == basketId).ToListAsync();

            return basketProduct;
        }

        public async Task<int> GetUserBasketProductCount(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            if (user == null) return 0;


            return await _context.basketProducts.Where(b => b.Basket.UserId == user.Id).SumAsync(bp => bp.Quantity);
        }
    }
}
