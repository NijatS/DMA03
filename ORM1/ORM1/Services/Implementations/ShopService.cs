using ORM1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;
using Trendyol.App.Exceptions;
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
            Shop shop = await GetAsync();

            shop.isDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task GetAllAsync()
        {
            ICollection<Shop> shops = await _repository.GetAllAsync(c => !c.isDeleted);

            foreach (Shop s in shops)
            {
                Console.WriteLine("Id:" + s.Id + "  Name:" + s.Name + " Description:" + s.Description + "  Rating:" + s.Rating);
            }
        }

        public async Task<Shop> GetAsync()
        {
            Console.WriteLine("Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Shop shop = await _repository.GetAsync(x => x.Id == id && !x.isDeleted);
            if (shop == null) throw new EntityNotFoundException();
            Console.WriteLine("Id:" + shop.Id + "  Name:" + shop.Name + " Description:" + shop.Description + "  Rating:" + shop.Rating);
            return shop;
        }

        public async Task UpdateAsync()
        {
            Shop shop = await GetAsync();
            Console.WriteLine("Updated name:");
            shop.Name = Console.ReadLine();
            Console.WriteLine("Description:");
            shop.Description = Console.ReadLine();
            Console.WriteLine("Rating:");
            shop.Rating = Convert.ToDouble(Console.ReadLine());
            _repository.Update(shop);
            await _repository.SaveAsync();
        }
    }
}
