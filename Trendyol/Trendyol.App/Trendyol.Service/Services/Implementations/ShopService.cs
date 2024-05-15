using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Implementations;
using Trendyol.Data.Repositories.Interfaces;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.Service.Services.Implementations
{
	public class ShopService : IShopService
	{
		private readonly IShopRepository _repository;

		public ShopService()
		{
			_repository = new ShopRepository();
		}

		public void Add()
		{

			Console.Write("Enter shop's name: ");
			string name = Console.ReadLine();

			Console.Write("Description: ");
			string description = Console.ReadLine();

			Console.Write("Rating: ");

			double.TryParse(Console.ReadLine(), out double rating);

			Shop shop = new Shop() { Name = name, Description = description, Rating = rating, CreatedDate = DateTime.Now };

			_repository.Add(shop);

		}

		public void Delete()
		{
			Console.WriteLine("Enter the id of shop you'd like to delete.");

			int.TryParse(Console.ReadLine(), out int id);

			_repository.Delete(id);
		}

		public void Get()
		{
			Console.WriteLine("Enter the id of shop you'd like to get.");

			int.TryParse(Console.ReadLine(), out int id);

			Shop foundShop = _repository.GetById(id);

			if (foundShop != null)
			{
				Console.WriteLine(foundShop);
			}
			else Console.WriteLine($"Id: {id} - Shop not found");
		}

		public void GetAll()
		{
			foreach (Shop shop in _repository.GetAll())
			{
				Console.WriteLine(shop);
			}
		}

		public void Update()
		{
			Console.WriteLine("Enter the id of shop you'd like to update.");

			int.TryParse(Console.ReadLine(), out int id);

			Shop foundShop = _repository.GetById(id);

			Console.Write("Enter shop's name: ");
			string name = Console.ReadLine();

			Console.Write("Description: ");
			string description = Console.ReadLine();

			Console.Write("Rating: ");

			double.TryParse(Console.ReadLine(), out double rating);

			foundShop.Name = name;
			foundShop.Description = description;
			foundShop.Rating = rating;
			foundShop.UpdatedDate = DateTime.Now;

			_repository.Update(foundShop);
		}
	}
}
