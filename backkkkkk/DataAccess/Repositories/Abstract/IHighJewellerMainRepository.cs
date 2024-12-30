using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
   
    public interface IHighJewellerMainRepository : IRepository<HighJewellerMain>
    {
        Task<HighJewellerMain> GetProduct(int jewellerId);
    }
}
