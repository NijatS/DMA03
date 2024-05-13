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
		private static ICollection<T> _entities = new List<T>();
		public void Add(T entity)
			=> _entities.Add(entity);

		public void Delete(int id)
		{
			T entity = GetById(id);
			if(entity != null)
				_entities.Remove(entity);
		}

		public ICollection<T> GetAll()
		   => _entities;

		public T GetById(int id)
			=> _entities.FirstOrDefault(x => x.Id == id);

		public void Update(T entity)
		{
			T updatedEntity = GetById(entity.Id);
			if (updatedEntity != null)
				updatedEntity = entity;
		}
	}
}
