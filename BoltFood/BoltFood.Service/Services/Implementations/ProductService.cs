using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Data.Repositories.Implementations;
using BoltFood.Data.Repositories.Interfaces;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
        public ProductService()
        {
			_productRepository = new ProductRepository();
        }
        public void Add()
		{
            Console.WriteLine("Enter the product name:");
			string name = Console.ReadLine();
            Console.WriteLine("Description: ");
			string description = Console.ReadLine();
            Console.WriteLine("Price: ");
			double.TryParse(Console.ReadLine(), out double price);
			var enums = Enum.GetValues(typeof(ProductCategory));
			foreach (var enum1 in enums) {
                Console.WriteLine((int)enum1 + "." + enum1);
            }
            Console.WriteLine("Category number: ");
			int.TryParse(Console.ReadLine(), out int categoryNumber);

			_productRepository.Add(new Product()
			{
				Name = name,
				Description = description,
				Price = price,
				CreatedAt = DateTime.Now,
				Category = (ProductCategory)categoryNumber,
			});

        }

		public void Delete()
		{
			Console.WriteLine("Please enter the id:");
			int.TryParse(Console.ReadLine(), out int id);
			try
			{
				_productRepository.Delete(id);
			}
			catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}

		public void GetAll()
		{
			List<Product>products = _productRepository.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }

		public void GetByID()
		{
            Console.WriteLine("Please enter the id:");
			int.TryParse(Console.ReadLine(), out int id);
			try
			{
				Product product = _productRepository.GetById(id);
				Console.WriteLine(product);
			}
			catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
