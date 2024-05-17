using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Interfaces;

namespace Trendyol.Data.Repositories.Implementations
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{

	}
}
