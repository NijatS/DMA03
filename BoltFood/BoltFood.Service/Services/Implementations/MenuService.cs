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
			Console.WriteLine("Welcome to Bolt Food\n" +
				"1.Restaurant Menu\n" +
				"2.Product Menu\n" +
				"0.Exit program");

		
			bool isContinue = true;


			do
			{
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
            Console.WriteLine("Restaurant");

        }
		private void ShowProductMenu() { }

	}
}
