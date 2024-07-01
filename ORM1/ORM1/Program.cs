using ORM1.Context;
using Trendyol.App.Entities;
using Trendyol.App.Services.Implementations;
using Trendyol.App.Services.Interfaces;

namespace ORM1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            IService service = new CustomerService();

            await service.AddAsync();
        }
    }
}
