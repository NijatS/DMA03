using Trendyol.Service.Services.Implementations;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.App
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
