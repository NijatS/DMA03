using BoltFood.Core.Models;
using BoltFood.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
	public class RestaurantRepository : IRestaurantRepository
	{
		private List<Restaurant> _restaurants;
        public RestaurantRepository()
        {
            _restaurants = new List<Restaurant>();
        }
        public void Add(Restaurant restaurant)
		{
			_restaurants.Add(restaurant);
		}

		public void Delete(int id)
		{
			Restaurant restaurant = GetById(id);
			if (restaurant != null)
			{
				_restaurants.Remove(restaurant);
			}
		}

		public List<Restaurant> GetAll()
		{
			return _restaurants;
		}

		public Restaurant GetById(int id)
		{
			foreach(var restaurant in _restaurants)
			{
				if(restaurant.Id == id)
				{
					return restaurant;
				}
			}
			throw new Exception("Restaurant not found");
		}

		public void Update(int id, Restaurant restaurant)
		{
			Restaurant findedRestaurant = GetById(id);
			if(findedRestaurant != null)
			{
				findedRestaurant = restaurant;
			}
		}
	}
}
