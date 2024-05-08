using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Interfaces
{
	public interface IProductRepository
	{
		public void Add(Product product);
		public void Update(Product product, int id);
		public void Delete(int id);
		public Product GetById(int id);
		public List<Product> GetAll();
	}
}
