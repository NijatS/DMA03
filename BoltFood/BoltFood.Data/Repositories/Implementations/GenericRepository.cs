using BoltFood.Core.Models;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
	public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
	{

		private static List<T> _entities = new List<T>();
		public void Add(T entity)
		{
			_entities.Add(entity);
		}

		public void Delete(int id)
		{
			T entity = GetById(id);
			if (entity != null)
			{
				_entities.Remove(entity);
			}
		}

		public List<T> GetAll()
		{
			return _entities;
		}

		public T GetById(int id)
		{
			foreach (T entity in _entities)
			{
				if (entity.Id == id)
				{
					return entity;
				}
			}
			throw new Exception($"{typeof(T)} is not found!");
		}

		public void Update(int id,T entity)
		{
			T updatedEntity = GetById(id);
			if (entity is not null)
			{
				updatedEntity = entity;
			}
		}
	}
}
