using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Contexts;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IBespokeAnimationRepository:IRepository<BespokeAnimation>
    {
        Task<BespokeAnimation> GetAsync();
    }
}
