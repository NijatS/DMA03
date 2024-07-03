using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities.BaseEntities;

namespace Trendyol.App.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate); 
        Task<ICollection<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync();
        int Save();
    }
}
