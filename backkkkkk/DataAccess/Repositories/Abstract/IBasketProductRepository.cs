using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IBasketProductRepository : IRepository<BasketProduct>
    {
        Task<BasketProduct> GetBasketProduct(int productId, int basketId);
        Task<int> GetUserBasketProductCount(ClaimsPrincipal userClaims);
        Task<List<BasketProduct>> GetAllBasketProduct(int basketId);
    }
}
