using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;
using Trendyol.App.Repositories.Implementations;
using Trendyol.App.Repositories.Interfaces;
using Trendyol.App.Services.Interfaces;

namespace Trendyol.App.Services.Implementations
{
    public class ShopService : IService<Shop>
    {
        private readonly IShopRepository _repository;
        public ShopService()
        {
            _repository = new ShopRepository();
        }
        public async Task AddAsync()
        {
            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Description:");
            string description = Console.ReadLine();

            await _repository.AddAsync(new Shop()
            {
                Name = name,
                Description = description,
            });
            await _repository.SaveAsync();

        }

        public async Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Shop> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
