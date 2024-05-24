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
		public async Task ShowMenuAsync()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.WriteLine(
					"1.Customer Menu\n" + 
					"2.Shop Menu\n" +
					"3.Product Menu\n"+
					"4.Product Category Menu\n"+
					"5.Order Menu\n" +
					"0.Exit Program");


				Console.Write("Enter operation number: ");
				int.TryParse(Console.ReadLine(), out int step);
				Console.Clear();


				switch (step)
				{
					case 1:
						ICustomerService customerService = new CustomerService();
						await SubMenuAsync(customerService);
						break;
					case 2:
						IShopService shopService = new ShopService();
						await SubMenuAsync(shopService);
						break;
					case 3:
						IProductService productService = new ProductService();
						await SubMenuAsync(productService);
						break;
					case 4:
						IProductCategoryService productCategoryService = new ProductCategoryService();
						await SubMenuAsync(productCategoryService);
						break;
					case 5:
						IOrderService orderService = new OrderService();
						await SubMenuAsync(orderService);
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
		private async Task SubMenuAsync(IService service)
		{
			bool isContinue = true;
			string type = service.GetType().Name.Split("Service")[0];
			bool result = service.GetType().ToString() == typeof(OrderService).ToString();

			while (isContinue)
			{
				Console.WriteLine($"1.Add {type}\n" +
					$"2.Update {type}\n" +
					$"3.Delete {type}\n" +
					$"4.Get {type} by Id\n" +
					$"5.Get All {type}s");

				if (result)
				{
                    Console.Write($"6.Change Status {type}s\n");
                }
                Console.WriteLine($"0.Exit {type} Menu");

                Console.Write("Enter operation number: ");
				int.TryParse(Console.ReadLine(), out int step);
				Console.Clear();

				switch (step)
				{
					case 1:
						await service.AddAsync();
						break;
					case 2:
						await service.UpdateAsync();
						break;
					case 3:
						await service.DeleteAsync();
						break;
					case 4:
						await service.GetAsync();
						break;
					case 5:
						await service.GetAllAsync();
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
