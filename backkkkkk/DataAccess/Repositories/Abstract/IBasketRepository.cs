using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasket(ClaimsPrincipal userClaims);
    }
}
