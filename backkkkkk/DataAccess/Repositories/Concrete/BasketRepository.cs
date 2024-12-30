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
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public BasketRepository(AppDbContext context, UserManager<User> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<Basket> GetBasket(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            if (user == null) return null;

            return await _context.baskets.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).FirstOrDefaultAsync(b => b.UserId == user.Id);
        
    }
}
}
