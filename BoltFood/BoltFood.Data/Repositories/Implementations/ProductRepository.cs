using BoltFood.Core.Models;
using BoltFood.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(int id)
		{
			Product product =GetById(id);
			if (product != null)
			{
				_products.Remove(product);
			}
		}

		public List<Product> GetAll()
		{
			return _products;
		}

		public Product GetById(int id)
		{
			foreach (Product product in _products)
			{
				if (product.Id == id)
				{
					return product;
				}
			}
			throw new Exception("Product is not found!");
		}

		public void Update(Product product, int id)
		{
			Product product1 = GetById(id);
			if (product1 != null)
			{
				product1 = product;
			}
		}
	}
}
