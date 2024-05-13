using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Data.Repositories.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		public void Add(T entity);
		public void Update(T entity);
		public void Delete(int id);
		public T GetById(int id);
		public ICollection<T> GetAll();
	}
}
