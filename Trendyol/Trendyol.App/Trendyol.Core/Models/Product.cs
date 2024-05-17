using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Core.Models
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Stock { get; set; }
		public double Price { get; set; }
		public Shop Shop { get; set; }
		public ProductCategory Category { get; set; }
		public override string ToString()
		{
			return "name:"+Name+" Description:"+ Description+"Stock:"+Stock+"Price:"+Price+"Shop:"+Shop.Name+"Category:"+Category.Name;
		}
	}
}
