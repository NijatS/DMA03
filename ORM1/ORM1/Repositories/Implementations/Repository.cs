using Microsoft.EntityFrameworkCore;
using ORM1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;
using Trendyol.App.Entities.BaseEntities;
using Trendyol.App.Repositories.Interfaces;

namespace Trendyol.App.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TrendyolDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            _context = new TrendyolDbContext();
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
          => await _dbSet.AddAsync(entity);

        public void Delete(T entity)
           => _dbSet.Remove(entity);

        public async Task<ICollection<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T,bool>> predicate)
        {
           return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).AsQueryable().FirstOrDefaultAsync();

        public int Save()
            => _context.SaveChanges();

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public void Update(T entity)
           => _dbSet.Update(entity);
    }
}
