using BoltFood.Core.Models;
using BoltFood.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
	public class RestaurantRepository :GenericRepository<Restaurant> ,IRestaurantRepository
	{
		
	}
}
