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
		private readonly IRestaurantRepository _restaurantRepository;
        public ProductService()
        {
			_productRepository = new ProductRepository();
			_restaurantRepository = new RestaurantRepository();
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

			Console.WriteLine("Enter a restaurant Id:");
			int.TryParse(Console.ReadLine(), out int resId);

			try
			{
				Restaurant restaurant = _restaurantRepository.GetById(resId);


				_productRepository.Add(new Product()
				{
					Name = name,
					Description = description,
					Price = price,
					CreatedAt = DateTime.Now,
					Restaurant = restaurant,
					Category = (ProductCategory)categoryNumber,
				});
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }

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

		public void GetById()
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

		public void GetProductsByRestaurantId()
		{
			List<Product> foundproduct = new List<Product>();
            Console.WriteLine("Enter restaurant ID:");
			int.TryParse(Console.ReadLine(), out int id);
			List<Product> products = _productRepository.GetAll();
			foreach(Product product in products)
			{
				if(product.Restaurant.Id == id)
				{
					foundproduct.Add(product);
				}
			}
			foreach(Product product in foundproduct)
			{
				Console.WriteLine(product);
			}

        }

		public void Update()
		{
            Console.WriteLine("Please enter a product id to update:");
			int.TryParse (Console.ReadLine(), out int id);

			Console.WriteLine("Enter the product name:");
			string name = Console.ReadLine();
			Console.WriteLine("Description: ");
			string description = Console.ReadLine();
			Console.WriteLine("Price: ");
			double.TryParse(Console.ReadLine(), out double price);
			var enums = Enum.GetValues(typeof(ProductCategory));
			foreach (var enum1 in enums)
			{
				Console.WriteLine((int)enum1 + "." + enum1);
			}
			Console.WriteLine("Category number: ");
			int.TryParse(Console.ReadLine(), out int categoryNumber);

			Console.WriteLine("Enter a restaurant Id:");
			int.TryParse(Console.ReadLine(), out int resId);

			try
			{
				Restaurant restaurant = _restaurantRepository.GetById(resId);

				Product findedProduct = _productRepository.GetById(id);


				findedProduct.Name = name;
				findedProduct.Price = price;
				findedProduct.Description = description;
				findedProduct.UpdatedAt = DateTime.Now;
				findedProduct.Restaurant = restaurant;
				findedProduct.Category = (ProductCategory)categoryNumber;

				_productRepository.Update(id,findedProduct);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
	}
}
