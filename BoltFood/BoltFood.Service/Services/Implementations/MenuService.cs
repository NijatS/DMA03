using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
	public class MenuService : IMenuService
	{
		public void ShowMenu()
		{
			bool isContinue = true;
			do
			{
				Console.WriteLine("Welcome to Bolt Food\n" +
			        "1.Restaurant Menu\n" +
			         "2.Product Menu\n" +
			          "0.Exit program");
				Console.Write("Enter step: ");
				int.TryParse(Console.ReadLine(), out int step);
				switch (step)
				{
					case 1:
						ShowRestaurantMenu();
						break;
					case 2:
						ShowProductMenu();
						break;
					case 0:
						isContinue = false;
						break;
					default:
						Console.WriteLine("Enter valid step!!!");
						break;
				}

			}
			while (isContinue);
		}
		private void ShowRestaurantMenu()
		{
			IRestaurantService restaurantService = new RestaurantService();
			bool keepGoing = true;

			while (keepGoing)
			{
				Console.WriteLine("1.Add a restaurant\n2.Get All restaurants\n3.Get a restaurant by Id\n4.Update a restaurant\n5.Delete a restaurant\n0.Exit ");

				Console.Write("Please enter a menu number:");
				int.TryParse(Console.ReadLine(), out int menuNumber);

				switch (menuNumber)
				{
					case 0:
						keepGoing = false;
						break;
					case 1:
						restaurantService.Add();
						break;
					case 2:
						restaurantService.GetAll();
						break;
					case 3:
						restaurantService.GetById();
						break;
					case 4:
						restaurantService.Update();
						break;
					case 5:
						restaurantService.Delete();
						break;
					default:
						Console.WriteLine("Enter a valid number");
						break;
				}

			}
		}
		private void ShowProductMenu()
		{
			IProductService productService = new ProductService();
			bool keepGoing = true;

			while (keepGoing)
			{
				Console.WriteLine("1.Add a product\n2.Get All products\n3.Get a product by Id\n4.Update a product\n5.Delete a product\n6.Get Products by Restaurant ID\n0.Exit ");

				Console.Write("Please enter a menu number:");
				int.TryParse(Console.ReadLine(), out int menuNumber);

				switch (menuNumber)
				{
					case 0:
						keepGoing = false;
						break;
					case 1:
						productService.Add();
						break;
					case 2:
						productService.GetAll();
						break;
					case 3:
						productService.GetById();
						break;
					case 4:
						productService.Update();
						break;
					case 5:
						productService.Delete();
						break;
					case 6:
						productService.GetProductsByRestaurantId();
						break;
					default:
						Console.WriteLine("Enter a valid number");
						break;
				}
			}

		}

	}
}
