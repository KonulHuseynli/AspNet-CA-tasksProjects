using Core.Entities.Base;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await   _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }
    }
}
