using BoltFood.Service.Services.Implementations;
using BoltFood.Service.Services.Interfaces;

namespace BoltFood
{
	internal class Program
	{
		static void Main(string[] args)
		{

			IProductService service = new ProductService();
			service.Add();
			service.GetAll();
			IMenuService menu = new MenuService();
			menu.ShowMenu();

		}
	}
}
