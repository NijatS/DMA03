using EduHome.Models.BaseEntities;

namespace EduHome.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync();
        int Save();
    }
}
