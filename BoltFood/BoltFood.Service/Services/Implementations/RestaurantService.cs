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
	public class RestaurantService : IRestaurantService
	{
		private readonly IRestaurantRepository _repository;
		public RestaurantService()
		{
			_repository = new RestaurantRepository();
		}
		public void Add()
		{
			Console.Write("Add Restaurant Name: ");
			string name = Console.ReadLine();
			Console.Write("Address:");
			string address = Console.ReadLine();
			Console.Write("Phone : ");
			string phone = Console.ReadLine();

			Restaurant restaurant = new Restaurant()
			{
				Name = name,
				Address = address,
				Phone = phone,
				CreatedAt = DateTime.Now,
			};
			_repository.Add(restaurant);
		}

		public void Delete()
		{
			Console.Write("Enter deleted Restaurant Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			try
			{
				_repository.Delete(id);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetAll()
		{
			List<Restaurant> restaurants = _repository.GetAll();
			foreach (var restaurant in restaurants)
			{
				Console.WriteLine(restaurant);
			}
		}

		public void GetById()
		{
			Console.Write("Enter Restaurant Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			try
			{
				Restaurant restaurant =  _repository.GetById(id);
                Console.WriteLine(restaurant);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Update()
		{
            Console.Write("Enter updated Restaurant Id : ");
			int.TryParse(Console.ReadLine(), out int id);

			Console.Write("Add Restaurant Name: ");
			string name = Console.ReadLine();
			Console.Write("Address:");
			string address = Console.ReadLine();
			Console.Write("Phone : ");
			string phone = Console.ReadLine();

			Restaurant findedRestaurant = _repository.GetById(id);
			findedRestaurant.Name = name;
			findedRestaurant.Address = address;
			findedRestaurant.Phone = phone;
			findedRestaurant.UpdatedAt = DateTime.Now;	

			try
			{
				_repository.Update(id, findedRestaurant);
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }

		}
	}
}
