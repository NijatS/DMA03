using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;
using Trendyol.Data.Repositories.Interfaces;

namespace Trendyol.Data.Repositories.Implementations
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		public static ICollection<T> _entities = new List<T>();
		public async Task AddAsync(T entity)
			=> _entities.Add(entity);

		public async Task DeleteAsync(int id)
		{
			T? entity = await GetByIdAsync(id);
			if(entity != null)
				_entities.Remove(entity);
		}

		public async Task<ICollection<T>> GetAllAsync()
		   =>  _entities;

		public async Task<T?> GetByIdAsync(int id)
			=> _entities.FirstOrDefault(x => x.Id == id);

		public async Task UpdateAsync(T entity)
		{
			T? updatedEntity = await GetByIdAsync(entity.Id);
			if (updatedEntity != null)
				updatedEntity = entity;
		}
	}
}
