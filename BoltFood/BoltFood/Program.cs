using BoltFood.Service.Services.Implementations;
using BoltFood.Service.Services.Interfaces;

namespace BoltFood
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IMenuService menu = new MenuService();
			menu.ShowMenu();

		}
	}
}
