using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.Service.Services.Implementations
{
	public class MenuService : IMenuService
	{
		public void ShowMenu()
		{
			bool isContinue = true;
			while (isContinue)
			{

				Console.WriteLine(
					"1.Customer Menu\n" + 
					"2.Shop Menu\n" +
					"0.Exit Program");

				Console.Write("Enter operation number: ");
				int.TryParse(Console.ReadLine(), out int step);

				switch (step)
				{
					case 1:
						ICustomerService customerService = new CustomerService();
						SubMenu(customerService);
						break;
					case 2:
						IShopService shopService = new ShopService();
						SubMenu(shopService);
						break;
					case 3:
						break;
					case 4:
						break;
					case 0:
						isContinue =false;
						break;
					default:
						Console.WriteLine("Enter valid operation number!!!");
						break;

				}
			}

		}
		private void SubMenu(IService service)
		{
			bool isContinue = true;
			string type = service.GetType().Name.Split("Service")[0];

            while (isContinue)
			{
				Console.WriteLine($"1.Add {type}\n" +
					$"2.Update {type}\n" +
					$"3.Delete {type}\n" +
					$"4.Get {type} by Id\n" +
					$"5.Get All {type}s\n" +
					$"0.Exit {type} Menu");

				Console.Write("Enter operation number: ");
				int.TryParse(Console.ReadLine(), out int step);

				switch (step)
				{
					case 1:
						service.Add();
						break;
					case 2:
						service.Update();
						break;
					case 3:
						service.Delete();
						break;
					case 4:
						service.Get();
						break;
					case 5:
						service.GetAll();
						break;
					case 0:
						isContinue = false;
						break;
					default:
						Console.WriteLine("Enter valid operation number!!!");
						break;

				}
			}

		}
	}
}
