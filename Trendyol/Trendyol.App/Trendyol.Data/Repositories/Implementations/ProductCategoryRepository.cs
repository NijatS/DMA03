
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Interfaces;

namespace Trendyol.Data.Repositories.Implementations
{
	public class ProductCategoryRepository:GenericRepository<ProductCategory>,IProductCategoryRepository
	{
        public ProductCategoryRepository()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Shirt";
            productCategory.CreatedDate = DateTime.Now;

            _entities.Add(productCategory);
        }
    }
}
