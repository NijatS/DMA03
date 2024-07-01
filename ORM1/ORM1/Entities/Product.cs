using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities.BaseEntities;

namespace Trendyol.App.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock {  get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
        public int ShopId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
