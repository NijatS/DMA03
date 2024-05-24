using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Implementations;
using Trendyol.Data.Repositories.Interfaces;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.Service.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductCategoryRepository _productCategoryRepository;
		private readonly IProductRepository _productRepository;
		private readonly IShopRepository _shopRepository;
		private readonly IShopService _shopService;
		public ProductService()
		{
			_productCategoryRepository = new ProductCategoryRepository();
			_productRepository = new ProductRepository();
			_shopRepository = new ShopRepository();
			_shopService = new ShopService();
		}
		public async Task AddAsync()
		{

			if ((await _shopRepository.GetAllAsync()).Count == 0)
			{
				Console.WriteLine("Ilk once Shop daxil edin");
				await _shopService.AddAsync();
			}

			Console.Write("Enter Product Name:");
			string name = Console.ReadLine();

			Console.Write("Description:");
			string description = Console.ReadLine();

			Console.Write("Stock:");
			int.TryParse(Console.ReadLine(), out int stock);

			Console.Write("Price:");
			double.TryParse(Console.ReadLine(), out double price);
			Console.Write("CategoryID:");
			int.TryParse(Console.ReadLine(), out int categoryid);
			ProductCategory category = await _productCategoryRepository.GetByIdAsync(categoryid);
			if (category == null)
			{
				Console.WriteLine("bu ID e uygun category yoxdu");
				return;
			}
			Console.Write("ShopID:");
			int.TryParse(Console.ReadLine(), out int shopId);
			Shop shop = await _shopRepository.GetByIdAsync(shopId);
			if (shop == null)
			{
				Console.WriteLine("bu ID e uygun shop yocdur");
				return;
			}

			Product product = new()
			{
				Category = category,
				Name = name,
				Price = price,
				Shop = shop,
				Stock = stock,
				Description = description,
				CreatedDate = DateTime.Now
			};

			await _productRepository.AddAsync(product);

		}

		public async Task DeleteAsync()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			await _productRepository.DeleteAsync(productID);

		}

		public async Task GetAsync()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			Product product = await _productRepository.GetByIdAsync(productID);
			if (product == null) { Console.WriteLine("product tapilmadi"); return; }
			Console.WriteLine(product);
		}

		public async Task GetAllAsync()
		{
			List<Product> products = (await _productRepository.GetAllAsync()).ToList();
			foreach (var product in products)
			{
				Console.WriteLine(product);
			}
		}

		public async Task UpdateAsync()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			Product product = await _productRepository.GetByIdAsync(productID);
			if (product == null)
			{
				Console.WriteLine("product tapilmadi");
				return;
			}
			Console.Write("Enter Product Name:");
			string name = Console.ReadLine();

			Console.Write("Description:");
			string description = Console.ReadLine();

			Console.Write("Stock:");
			int.TryParse(Console.ReadLine(), out int stock);

			Console.Write("Price:");
			double.TryParse(Console.ReadLine(), out double price);
			Console.Write("CategoryID:");
			int.TryParse(Console.ReadLine(), out int categoryid);
			ProductCategory category = await _productCategoryRepository.GetByIdAsync(categoryid);
			if (category == null)
			{
				Console.WriteLine("bu ID e uygun category yoxdu");
				return;
			}
			Console.Write("ShopID:");
			int.TryParse(Console.ReadLine(), out int shopId);
			Shop shop = await _shopRepository.GetByIdAsync(shopId);
			if (shop == null)
			{
				Console.WriteLine("bu ID e uygun shop yocdur");
				return;
			}


			product.Name = name;
			product.Description = description;
			product.Stock = stock;
			product.Price = price;
			product.Category = category;
			product.UpdatedDate = DateTime.Now;
			product.Shop = shop;

			await _productRepository.UpdateAsync(product);

		}
	}
}
