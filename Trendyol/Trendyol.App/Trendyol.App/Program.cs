using Trendyol.Service.Services.Implementations;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.App
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			IMenuService menu = new MenuService();

			await menu.ShowMenuAsync();
		}
	}
}
