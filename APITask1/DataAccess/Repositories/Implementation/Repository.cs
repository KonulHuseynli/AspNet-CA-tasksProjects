using Core.Entities.Base;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbTable;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbTable=context.Set<T>();  
        }
        public async Task<List<T>> GetAllAsync()
        {
          return await _dbTable.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbTable.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _dbTable.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
           _dbTable.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _dbTable.Update(entity);
            await _context.SaveChangesAsync();  
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbTable.AnyAsync(predicate);
        }



    }
}
