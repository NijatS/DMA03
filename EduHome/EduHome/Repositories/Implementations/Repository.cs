using EduHome.Context;
using EduHome.Models.BaseEntities;
using EduHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EduHome.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EduHomeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EduHomeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
           EntityEntry entityEntry =  _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<IQueryable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public int Save()
         => _context.SaveChanges();

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        public bool Update(T entity)
        {
            EntityEntry entityEntry= _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
