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
		public void Add()
		{

			if (_shopRepository.GetAll().Count == 0)
			{
				Console.WriteLine("Ilk once Shop daxil edin");
				_shopService.Add();
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
			ProductCategory category = _productCategoryRepository.GetById(categoryid);
			if (category == null) { Console.WriteLine("bu ID e uygun category yoxdu"); return; }
			Console.Write("ShopID:");
			int.TryParse(Console.ReadLine(), out int shopId);
			Shop shop = _shopRepository.GetById(shopId);
			if (shop == null) { Console.WriteLine("bu ID e uygun shop yocdur"); return; }

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

			_productRepository.Add(product);

		}

		public void Delete()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			_productRepository.Delete(productID);

		}

		public void Get()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			Product product = _productRepository.GetById(productID);
			if (product == null) { Console.WriteLine("product tapilmadi"); return; }
			Console.WriteLine(product);
		}

		public void GetAll()
		{
			List<Product> products = _productRepository.GetAll().ToList();
			foreach (var product in products)
			{
				Console.WriteLine(product);
			}
		}

		public void Update()
		{
			Console.WriteLine("id");
			int.TryParse(Console.ReadLine(), out int productID);
			Product product = _productRepository.GetById(productID);
			if (product == null) { Console.WriteLine("product tapilmadi"); return; }
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
			ProductCategory category = _productCategoryRepository.GetById(categoryid);
			if (category == null) { Console.WriteLine("bu ID e uygun category yoxdu"); return; }
			Console.Write("ShopID:");
			int.TryParse(Console.ReadLine(), out int shopId);
			Shop shop = _shopRepository.GetById(shopId);
			if (shop == null) { Console.WriteLine("bu ID e uygun shop yocdur"); return; }


			product.Name = name;
			product.Description = description;
			product.Stock = stock;
			product.Price = price;
			product.Category = category;
			product.UpdatedDate = DateTime.Now;
			product.Shop = shop;

			_productRepository.Update(product);

		}
	}
}
