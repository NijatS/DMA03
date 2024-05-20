using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Interfaces;

namespace Trendyol.Data.Repositories.Implementations
{
	public class ShopRepository : GenericRepository<Shop>, IShopRepository
	{
        public ShopRepository()
        {
            Shop shop = new Shop();
            shop.Name = "Shop1";
            shop.Description = "Desc";
            shop.CreatedDate = DateTime.Now;
            shop.Rating = 5;

            _entities.Add(shop);
        }
    }
}
