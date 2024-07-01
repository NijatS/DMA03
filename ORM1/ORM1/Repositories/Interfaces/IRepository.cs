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
        Task<T> GetAsync(int id); 
        Task<ICollection<T>> GetAllAsync();
        Task<int> SaveAsync();
        int Save();
    }
}
