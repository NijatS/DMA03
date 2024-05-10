using BoltFood.Core.Models;
using BoltFood.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
	}
}
