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

		public async Task AddAsync()
		{

			Console.Write("Enter shop's name: ");
			string? name = Console.ReadLine();

			Console.Write("Description: ");
			string? description = Console.ReadLine();

			Console.Write("Rating: ");

			double.TryParse(Console.ReadLine(), out double rating);

			Shop shop = new Shop() { Name = name, Description = description, Rating = rating, CreatedDate = DateTime.Now };

			await _repository.AddAsync(shop);

		}

		public async Task DeleteAsync()
		{
			Console.WriteLine("Enter the id of shop you'd like to delete.");

			int.TryParse(Console.ReadLine(), out int id);

			await _repository.DeleteAsync(id);
		}

		public async Task GetAsync()
		{
			Console.WriteLine("Enter the id of shop you'd like to get.");

			int.TryParse(Console.ReadLine(), out int id);

			Shop foundShop = await _repository.GetByIdAsync(id);

			if (foundShop != null)
			{
				Console.WriteLine(foundShop);
			}
			else Console.WriteLine($"Id: {id} - Shop not found");
		}

		public async Task GetAllAsync()
		{
			foreach (Shop shop in await _repository.GetAllAsync())
			{
				Console.WriteLine(shop);
			}
		}

		public async Task UpdateAsync()
		{
			Console.WriteLine("Enter the id of shop you'd like to update.");

			int.TryParse(Console.ReadLine(), out int id);

			Shop foundShop = await _repository.GetByIdAsync(id);
			 
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

			await _repository.UpdateAsync(foundShop);
		}
	}
}
